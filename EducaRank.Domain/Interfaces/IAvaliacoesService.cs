using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IAvaliacoesService
    {
        Task<IEnumerable<Avaliacao>> GetAll();
        Task<Avaliacao> GetById(string id);
        Task<Avaliacao> CreateAvaliacao(string aluno_id, string professor_id, string comentario, int nova_pontuacao);
        Task<IEnumerable<Avaliacao>> GetAvaliacoesByAluno(string aluno_id);
        Task<IEnumerable<Avaliacao>> GetAvaliacoesByProfessor(string aluno_id);
        Task<bool> DeleteAvaliacao(string avaliacao_id);
    }
}
