using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IAlunoService
    {
        Task<List<Aluno>> GetAlunos(); // listar alunos do banco de dados do educa rank
        Task<Aluno> GetAlunoById(string aluno_id);
        Task<Aluno> EdiAluno(Aluno aluno_model, string aluno_id)
        Task<Aluno> CreateAluno(Aluno aluno_model);
        Task<Aluno> GetPontuacao(string aluno_id);
        Task<Aluno> GetNrAvaliacoes(string aluno_id);
        Task<bool> DeleteAlunoFromEducaRank(string aluno_id);
        Task<List<Avaliacao>> GetAvaliacoes(string aluno_id);
        Task<List<Aluno>> SearchAlunos(string query_str);
    }
}
