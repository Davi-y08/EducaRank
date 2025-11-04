using System.ComponentModel.DataAnnotations;
using EducaRank.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace EducaRank.Application.Dtos.AlunoDtos
{
    public class CreateAluno
    {
        [Required(ErrorMessage = "Rm necessário")]
        public int Rm { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 digitos")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirmar senha é obrigatório")]
        [Compare("Senha", ErrorMessage = "Senhas não coincidem")]
        public string ConfirmarSenha { get; set; } = string.Empty;

        public IFormFile? Foto { get; set; }
    }
}
