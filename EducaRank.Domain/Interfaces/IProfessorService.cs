using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> GetAll();
        Task<Professor> GetById(string professorId);
        Task<Professor> Create(int rm, string senha, string cpf);
        Task<Professor> Update(Professor professorModel, string professorId);
        Task<IEnumerable<Professor>> Search(string query, int page = 1, int pageSize = 15);
        Task<bool> Delete(string professorId);
    }
}
