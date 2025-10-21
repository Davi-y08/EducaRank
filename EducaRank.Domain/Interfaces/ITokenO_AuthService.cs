using EducaRank.Domain.Models;

namespace EducaRank.Domain.Interfaces
{
    public interface ITokenO_AuthService
    {
        public string CreateToken_Aluno(Aluno aluno_model);
        public string CreateToken_Professor(Professor professor_model);
    }
}
