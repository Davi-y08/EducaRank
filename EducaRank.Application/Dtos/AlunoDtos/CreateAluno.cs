using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EducaRank.Application.Dtos.AlunoDtos
{
    public class CreateAluno
    {
        [Required(ErrorMessage = "Rm necessário")]
        public int Rm { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Curso { get; set; } = string.Empty;

        [Required]
        public string Sala { get; set; } = string.Empty;

        [Required]
        public string Etec { get; set; } = string.Empty;

        [Required]
        [Range(13, 100)]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 digitos")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirmar senha é obrigatório")]
        [Compare("Senha", ErrorMessage = "Senhas não coincidem")]
        public string ConfirmarSenha { get; set; } = string.Empty;

        public IFormFile? Foto { get; set; }
    }
}
