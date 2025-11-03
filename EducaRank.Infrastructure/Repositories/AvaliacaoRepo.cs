using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;

namespace EducaRank.Infrastructure.Repositories
{
    public class AvaliacaoRepo : IAvaliacoesService
    {
        public Task<Avaliacao> Create(Avaliacao avaliacao_model)
        {
            throw new NotImplementedException();
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
