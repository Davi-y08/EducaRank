using System.ComponentModel.DataAnnotations;

namespace EducaRank.Application.Dtos.MainDto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O rm é necessário para fazer login")]
        public int Rm { get; set; }

        [Required(ErrorMessage = "A senha é necessária para fazer login")]
        public string Senha { get; set; } = string.Empty;
    }
}
