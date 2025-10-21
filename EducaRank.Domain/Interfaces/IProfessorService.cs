using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IProfessorService
    {
        Task<List<Professor>> GetProfessores(); // listar professores do banco de dados do educarank
        Task<Professor> GetProfessorById(int professor_id);
        Task<Professor> CreateAluno(Professor professor);
        Task<Professor> ChangePfp(string pfp);
        Task<Professor> GetNrAvaliacoes(int professor_id);
        Task<bool> DeleteProfessorFromEducaRank(int professor_id);
        Task<List<Avaliacao>> GetAvaliacoesFeitas(int professor_id);
        Task<List<Professor>> SearchProfessores(string query_str);
        Task<Professor> ChangeEmail(string new_email);
        Task<Professor> ChangePassword(string old_password, string new_password);
    }
}
