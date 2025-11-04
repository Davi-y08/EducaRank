using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno?> GetById(string id);
        Task<int> GetPontuacao(string aluno_id);
        Task<Aluno> Update(Aluno aluno_model, string aluno_id);
        Task<Aluno> Create(int rm, string senha);
        Task<bool> DeleteAlunoFromEducaRank(string aluno_id);
        Task<IEnumerable<Aluno>> SearchAlunos(string query_str);
    }
}
