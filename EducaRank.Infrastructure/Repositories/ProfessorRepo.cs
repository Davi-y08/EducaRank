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

        public async Task<Professor> Create(int rm, string senha)
        {
            var professorExistente = await _appDbContext.Professores.FirstOrDefaultAsync(a => a.Rm == rm);

            if (professorExistente != null)
                throw new InvalidOperationException("O professor já está cadastrado no sistema");

            var professor_legado = await _legadoEscolaDbContext.ProfessorBdEtec.FirstOrDefaultAsync(a => a.RM == rm);

            if(professor_legado == null)
                throw new KeyNotFoundException("Professor não encontrado na base da Etec.");

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

            return novo_professor;
        }

        public Task<bool> Delete(string professorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Professor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Professor> GetById(string professorId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNrAvaliacoes(string professorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Professor>> Search(string query)
        {
            throw new NotImplementedException();
        }

        public Task<Professor> Update(Professor professorModel, string professorId)
        {
            throw new NotImplementedException();
        }
    }
}
