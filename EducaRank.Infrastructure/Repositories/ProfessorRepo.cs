using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;

namespace EducaRank.Infrastructure.Repositories
{
    public class ProfessorRepo : IProfessorService
    {
        public Task<Professor> Create(Professor professorModel)
        {
            throw new NotImplementedException();
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
