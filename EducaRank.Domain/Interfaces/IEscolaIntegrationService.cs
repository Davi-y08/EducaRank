using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IEscolaIntegrationService
    {
        Task<Aluno?> GetAlunoFromEscolaByRM(int RM);
        Task<List<Aluno>> GetAlunosFromEscola(); // Listar alunos da banco de dados da escola
    }
}
