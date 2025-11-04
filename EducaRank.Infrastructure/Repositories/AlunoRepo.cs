using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;
using EducaRank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        public Task<bool> DeleteAlunoFromEducaRank(string aluno_id)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno?> GeById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aluno>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> GetPontuacao(string aluno_id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aluno>> SearchAlunos(string query_str)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> Update(Aluno aluno_model, string aluno_id)
        {
            throw new NotImplementedException();
        }
    }
}
