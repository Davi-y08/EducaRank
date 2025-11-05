using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno?> GetById(string id);
        Task<int> GetPontuacao(string aluno_id);
        Task<Aluno> Update(Aluno aluno_model, string aluno_id);
        Task<IEnumerable<Aluno>> PontuacaoComFiltos(string? etec = null, int? sala = null, int? idadeMin = null, int? idadeMax = null, int page = 1, int pageSize = 10);
        Task<Aluno> Create(int rm, string senha);
        Task<bool> DeleteAlunoFromEducaRank(string aluno_id);
        Task<IEnumerable<Aluno>> SearchAlunos(string query_str, int page, int pageSize);
    }
}
