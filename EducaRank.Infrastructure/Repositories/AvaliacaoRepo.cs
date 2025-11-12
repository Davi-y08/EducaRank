using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;
using EducaRank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducaRank.Infrastructure.Repositories
{
    public class AvaliacaoRepo : IAvaliacoesService
    {
        private readonly AppDbContext _context;

        public AvaliacaoRepo(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Avaliacao> CreateAvaliacao(string aluno_id, string professor_id, string comentario, int nova_pontuacao)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == aluno_id);
            var professor = await _context.Professores.FirstOrDefaultAsync(x => x.Id == professor_id);

            if (aluno == null || professor == null)
                throw new KeyNotFoundException("Aluno ou professor não encontrado na base de dados do EducaRank.");

            aluno.AlterarPontuacao(nova_pontuacao);

            var nova_avaliacao = Avaliacao.Criar(
                professor: professor,
                aluno: aluno,
                pontuacao: nova_pontuacao,
                comentario: comentario
            );

            _context.Add(nova_avaliacao);
            await _context.SaveChangesAsync();

            return nova_avaliacao;
        }

        public Task<bool> DeleteAvaliacao(string avaliacao_id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Avaliacao>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Avaliacao>> GetAvaliacoesByAluno(string aluno_id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Avaliacao>> GetAvaliacoesByProfessor(string aluno_id)
        {
            throw new NotImplementedException();
        }

        public Task<Avaliacao> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
