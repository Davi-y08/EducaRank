using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;

namespace EducaRank.Infrastructure.Repositories
{
    public class AlunoRepo : IAlunoService
    {


        public Task<Aluno> Create(Aluno aluno_model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAlunoFromEducaRank(string aluno_id)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno?> GeById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aluno>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> GetPontuacao(string aluno_id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aluno>> SearchAlunos(string query_str)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> Update(Aluno aluno_model, string aluno_id)
        {
            throw new NotImplementedException();
        }
    }
}
