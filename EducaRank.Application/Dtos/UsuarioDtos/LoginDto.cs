using System.ComponentModel.DataAnnotations;

namespace EducaRank.Application.Dtos.UsuarioDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O Rm é obrigatório no login")]
        public int Rm { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória no login")]
        public string Senha { get; set; } = string.Empty;
    }
}
