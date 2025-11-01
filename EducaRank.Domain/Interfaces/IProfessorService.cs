using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> GetAll();
        Task<Professor> GetById(string professorId);
        Task<int> GetNrAvaliacoes(string professorId);

        Task<Professor> Create(Professor professorModel);
        Task<Professor> Update(Professor professorModel, string professorId);
        Task<IEnumerable<Professor>> Search(string query);
        Task<bool> Delete(string professorId);
    }
}
