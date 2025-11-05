    using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;
using EducaRank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EducaRank.Infrastructure.Repositories
{
    public class AlunoRepo : IAlunoService
    {
        private readonly AppDbContext _appDbContext;
        private readonly LegadoEscolaDbContext _legadoEscolaDbContext;
        public AlunoRepo(AppDbContext appDbContext, LegadoEscolaDbContext legadoEscolaDbContext)
        {
            _appDbContext = appDbContext;
            _legadoEscolaDbContext = legadoEscolaDbContext;
        }

        public async Task<Aluno> Create(int rm, string senha)
        {
            var aluno_existente = await _appDbContext.Alunos.FirstOrDefaultAsync(a => a.Rm == rm);

            if (aluno_existente != null)
                throw new InvalidOperationException("O aluno já existe no EducaRank");

            var aluno_legado = await _legadoEscolaDbContext.AlunoBdEtec 
                .FirstOrDefaultAsync(a => a.RM == rm);

            if (aluno_legado == null)
                throw new KeyNotFoundException("Aluno não encontrado na base da Etec.");

            var sala_existente = await _appDbContext.Salas.FirstOrDefaultAsync(s => s.NomeSala == aluno_legado.SalaId.ToString());
            var sala = sala_existente ?? Sala.Criar(aluno_legado.SalaId.ToString());

            if (sala_existente == null)
            {
                _appDbContext.Salas.Add(sala);
                await _appDbContext.SaveChangesAsync();
            }
                
            var idade = DateTime.Now.Year - aluno_legado.DataNascimento.Year;
            if (DateTime.Now.DayOfYear < aluno_legado.DataNascimento.DayOfYear)
                idade--;

            var novo_aluno = Aluno.Criar(
                rm: aluno_legado.RM,
                nome: aluno_legado.Nome,
                sala: sala,
                etec: aluno_legado.Etec,
                idade: idade,
                senha: senha
            );

            _appDbContext.Add(novo_aluno);
            await _appDbContext.SaveChangesAsync();

            return novo_aluno;
        }

        public async Task<bool> DeleteAlunoFromEducaRank(string aluno_id)
        {
            var aluno = await _appDbContext.Alunos.FindAsync(aluno_id);

            if (aluno != null)
            {
                _appDbContext.Alunos.Remove(aluno);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Aluno?> GetById(string id)
        {
            var aluno = await _appDbContext.Alunos.FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
            {
                return null;
            }

            return aluno;
        }

        public async Task<IEnumerable<Aluno>> GetAll()
        {
            var alunos = await _appDbContext.Alunos.ToListAsync();
            return alunos;
        }



        public async Task<int> GetPontuacao(string aluno_id)
        {
            var aluno = await _appDbContext.Alunos.FirstOrDefaultAsync(x => x.Id == aluno_id);

            if (aluno == null)
            {
                return -1;
            }

            return aluno.Pontuacao;
        }

        public async Task<IEnumerable<Aluno>> SearchAlunos(string query_str, int page, int pageSize)
        {
            query_str = query_str.Trim();

            return await _appDbContext.Alunos.Where(a => EF.Functions.Like(a.Nome.ToLower(), $"%{query_str}%"))
                .OrderBy(a => a.Nome.ToLower().StartsWith(query_str) ? 0 : 1)
                .ThenBy(a => a.Nome)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public Task<Aluno> Update(Aluno aluno_model, string aluno_id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Aluno>> PontuacaoComFiltos(string? etec = null, int? salaId = null, int? idadeMin = null, int? idadeMax = null, int page = 1, int pageSize = 10)
        {
            var query = _appDbContext.Alunos.AsQueryable();

            if (!string.IsNullOrEmpty(etec))
                query = query.Where(a => a.Etec == etec);

            if (salaId.HasValue)
                query = query.Where(a => a.SalaId == salaId);

            if (idadeMin.HasValue)
                query = query.Where(a => a.Idade >= idadeMin);

            if(idadeMax.HasValue)
                query = query.Where(a => a.Idade <= idadeMax);

            var alunos = await query.OrderByDescending(a => a.Pontuacao).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return alunos;
        }
    }
}
