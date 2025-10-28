using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;

namespace EducaRank.Domain.Services
{
    public class ProfessorService
    {
        private readonly IProfessorService _professorService;

        public ProfessorService(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        public async Task<List<Professor>> GetProfessores()
        {
            return await _professorService.GetProfessores();
        }

        public async Task<Professor> CreateProfessor(Professor professor_model)
        {
            var new_professor = new Professor
            {
                Id = professor_model.Id,
                Rm = professor_model.Rm,
                Nome = professor_model.Nome,
                Materias = professor_model.Materias,
                Salas = professor_model.Salas,
                Foto = professor_model.Foto,
                SenhaHash = professor_model.SenhaHash,
                AvaliacoesFeitas = professor_model.AvaliacoesFeitas
            };

            return await _professorService.CreateProfessor(new_professor);
        }

        public async Task<Professor> GetProfessorById(int id_professor)
        {
            return await _professorService.GetProfessorById(id_professor);
        }

        public async Task<Professor> ChangePfp(string pfp)
        {
            return await _professorService.ChangePfp(pfp);
        }

        public async Task<Professor> GetNrAvaliacoes(int id_professor)
        {
            return await _professorService.GetNrAvaliacoes(id_professor);
        }

        public async Task<bool> DeleteProfessorFromEducaRank(int id_professor)
        {
            return await _professorService.DeleteProfessorFromEducaRank(id_professor);
        }

        public async Task<List<Avaliacao>> GetAvaliacoesFeitas(int id_professor)
        {
            return await _professorService.GetAvaliacoesFeitas(id_professor);
        }

        public async Task<List<Professor>> SearchProfessores(string query)
        {
            return await _professorService.SearchProfessores(query);
        }

        public async Task<Professor> ChangeEmail(string new_email)
        {
            return await _professorService.ChangeEmail(new_email);
        }

        public async Task<Professor> ChangePass(string old_pass, string new_pass)
        {
            return await _professorService.ChangePassword(old_pass, new_pass);
        }
    }
}
