using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;
using EducaRank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;

namespace EducaRank.Infrastructure.Repositories
{
    public class ProfessorRepo : IProfessorService
    {
        private readonly AppDbContext _appDbContext;
        private readonly LegadoEscolaDbContext _legadoEscolaDbContext;

        public ProfessorRepo(AppDbContext appDbContext, LegadoEscolaDbContext legadoEscolaDbContext)
        {
            _appDbContext = appDbContext;
            _legadoEscolaDbContext = legadoEscolaDbContext;
        }

        public async Task<Professor> Create(int rm, string senha, string cpf)
        {
            var professorExistente = await _appDbContext.Professores.FirstOrDefaultAsync(a => a.Rm == rm);

            if (professorExistente != null)
                throw new InvalidOperationException("O professor já está cadastrado no sistema");

            var professor_legado = await _legadoEscolaDbContext.ProfessorBdEtec.FirstOrDefaultAsync(a => a.RM == rm);

            if(professor_legado == null)
                throw new KeyNotFoundException("Professor não encontrado na base da Etec.");

            if (professor_legado.Cpf != cpf)
                throw new UnauthorizedAccessException("Identidade não reconhecida (CPFs diferentes)");

            var materiaNomes = await _legadoEscolaDbContext.ProfessorMateriaBdEtec
                .Where(p => p.RMProfessor == rm) 
                .Join(
                    _legadoEscolaDbContext.MateriaBdEtec, // 
                    pm => pm.IdMateria, // chave da matéria na tabela 'professor_materia'
                    m => m.Id, // id da tabela 'tb_materia'
                    (pm, m) => m.Nome // dado que eu quero
                )
                .ToListAsync();

            /*
            SELECT m.Nome
            FROM ProfessorMateriaBdEtec pm
            INNER JOIN MateriaBdEtec m
            ON pm.IdMateria = m.Id
            WHERE pm.RMProfessor = @rm
             */

            var novo_professor = Professor.Criar(
                rm: professor_legado.RM,
                nome: professor_legado.Nome,
                materias: materiaNomes,
                senha: senha
            );

            _appDbContext.Professores.Add(novo_professor);
            await _appDbContext.SaveChangesAsync();

            return novo_professor;
        }


        public async Task<bool> Delete(string professorId)
        {
            var professor = await _appDbContext.Professores.FindAsync(professorId);

            if (professor == null)
                return false;

            _appDbContext.Professores.Remove(professor);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Professor>> GetAll()
        {
            IEnumerable<Professor> professores = await _appDbContext.Professores.ToListAsync();
            return professores;
        }

        public async Task<Professor> GetById(string professorId)
        {
            var professor = await _appDbContext.Professores.FindAsync(professorId);

            if (professor == null)
                return null!;

            return professor;
        }

        public async Task<int> GetNrAvaliacoes(string professorId)
        {
            int avaliacoes = await _appDbContext.Professores.Where(x => x.Id == professorId)
                .Select(x => x.AvaliacoesFeitas)
                .FirstOrDefaultAsync();

            if (avaliacoes == 0)
                throw new KeyNotFoundException("Professor não encontrado ou nenhuma avaliação feita");

            return avaliacoes;
        }

        public async Task<IEnumerable<Professor>> Search(string query)
        {
            query = query.Trim();

            return await _appDbContext.Professores.Where(a => EF.Functions.Like(a.Nome.ToLower(), $"%{query}%"))
                .OrderBy(a => a.Nome.ToLower().StartsWith(query) ? 0 : 1)
                .ThenBy(a => a.Nome)
                .ToListAsync();
        }

        public Task<Professor> Update(Professor professorModel, string professorId)
        {
            throw new NotImplementedException();
        }
    }
}
