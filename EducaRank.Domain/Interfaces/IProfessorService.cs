using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface IProfessorService
    {
        Task<List<Professor>> GetProfessores(); // listar professores do banco de dados do educarank
        Task<Professor> GetProfessorById(string professor_id);
        Task<Professor> CreateProfessor(Professor professor_model);
        Task<Professor> GetNrAvaliacoes(string professor_id);
        Task<Professor> EditProfessor(Professor professor_model, int professor_id);
        Task<bool> DeleteProfessorFromEducaRank(string professor_id);
        Task<List<Avaliacao>> GetAvaliacoesFeitas(string professor_id);
        Task<List<Professor>> SearchProfessores(string query_str);
        Task<Professor> ChangePassword(string old_password, string new_password);
    }
}
