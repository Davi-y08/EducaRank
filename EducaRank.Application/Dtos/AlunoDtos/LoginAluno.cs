using System.ComponentModel.DataAnnotations;

namespace EducaRank.Application.Dtos.AlunoDtos
{
    public class LoginAluno
    {
        [Required(ErrorMessage = "O rm é necessário para fazer login")]
        public int Rm { get; set; }

        [Required(ErrorMessage = "A senha é necessária para fazer login")]
        public string Senha { get; set; } = string.Empty;
    }
}
