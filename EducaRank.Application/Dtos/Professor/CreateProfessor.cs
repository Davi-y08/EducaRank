using EducaRank.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EducaRank.Application.Dtos.Professor
{
    public class CreateProfessor
    {
        public int Rm { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public List<Materia> Materias { get; set; } = new List<Materia>();
        [Required]
        public List<Sala> Salas { get; set; } = new List<Sala>();

        public string Foto { get; set; } = string.Empty;
        public int AvaliacoesFeitas { get; set; } = 0;

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 digitos")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirmar senha é obrigatório")]
        [Compare("Senha", ErrorMessage = "Senhas não coincidem")]
        public string ConfirmarSenha { get; set; } = string.Empty;
    }
}
