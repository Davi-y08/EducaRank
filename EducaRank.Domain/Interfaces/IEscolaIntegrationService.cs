using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IEscolaIntegrationService
    {
        Task<Aluno?> GetAlunoFromEscolaByRM(int RM);
        Task<IEnumerable<Aluno>> GetAlunosFromEscola();
    }
}
