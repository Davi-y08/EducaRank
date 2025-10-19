using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IAvaliacoesService
    {
        Task<List<Avaliacao>> GetAvaliacoes();
        Task<Avaliacao> GetAvaliacaoById(int id);
        Task<Avaliacao> CreateAvaliacao(Avaliacao avaliacao_model);
        Task<List<Avaliacao>> GetAvaliacoesByAluno(int rm);
        Task<List<Avaliacao>> GetAvaliacoesByProfessor(int rm);
        Task<bool> DeleteAvaliacao(int id);
    }
}
