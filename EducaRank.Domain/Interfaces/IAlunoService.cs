using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IAlunoService
    {
        Task<List<Aluno>> GetAlunos(); // listar alunos do banco de dados do educa rank
        Task<Aluno> GetAlunoById(int aluno_id);
        Task<Aluno> CreateAluno(Aluno aluno_model);
        Task<Aluno> ChangePfp(string pfp);
        Task<Aluno> GetPontuacao(int aluno_id);
        Task<Aluno> GetNrAvaliacoes(int aluno_id);
        Task<bool> DeleteAlunoFromEducaRank(int aluno_id);
        Task<List<Avaliacao>> GetAvaliacoes(int aluno_id);
        Task<List<Aluno>> SearchAlunos(string query_str);
        Task<Aluno> ChangeEmail(string new_email);
        Task<Aluno> ChangePassword(string old_password, string new_password);
    }
}
