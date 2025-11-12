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
            var aluno = await _context.Alunos.FindAsync(aluno_id);
            var professor = await _context.Professores.FindAsync(professor_id);

            if (aluno == null || professor == null)
                throw new KeyNotFoundException("Aluno ou professor não encontrado na base de dados do EducaRank.");

            aluno.AlterarPontuacao(nova_pontuacao);

            var nova_avaliacao = Avaliacao.Criar(
                professor: professor,
                aluno: aluno,
                pontuacao: nova_pontuacao,
                comentario: comentario
            );

            _context.Update(aluno);
            _context.Avaliacoes.Add(nova_avaliacao);
            await _context.SaveChangesAsync();

            return nova_avaliacao;
        }

        public async Task<bool> DeleteAvaliacao(string avaliacao_id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(avaliacao_id);

            if (avaliacao == null)
                throw new KeyNotFoundException("avaliacao não encontrada");

            var aluno = await _context.Alunos.FindAsync(avaliacao.AlunoId);

            if (aluno == null)
                throw new KeyNotFoundException("Aluno não encontrado na base de dados do EducaRank.");

            aluno.AlterarPontuacao(avaliacao.PontuacaoAlterada * -1);

            _context.Update(aluno);
            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Avaliacao>> GetAll()
        {
            var avaliacoes = await _context.Avaliacoes.ToListAsync();
            return avaliacoes;
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
