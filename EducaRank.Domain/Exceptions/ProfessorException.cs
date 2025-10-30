using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EducaRank.Domain.Exceptions
{
    public class ProfessorException
    {
        private readonly IProfessorService _professorService;

        public ProfessorException(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        public async Task<Professor> CreateProfessor(Professor professor_model)
        {
            if (string.IsNullOrWhiteSpace(professor_model.Nome))
                throw new ValidationException("Nome do professor é obrigatório.");

            if (string.IsNullOrWhiteSpace(professor_model.Foto))
                professor_model.Foto = "path/fotopadrao.png";

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
