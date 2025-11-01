using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno?> GeById(string id);
        Task<Aluno> GetPontuacao(string aluno_id);

        Task<Aluno> Update(Aluno aluno_model, string aluno_id);
        Task<Aluno> Create(Aluno aluno_model);
        Task<bool> DeleteAlunoFromEducaRank(string aluno_id);
        Task<List<Aluno>> SearchAlunos(string query_str);
    }
}
