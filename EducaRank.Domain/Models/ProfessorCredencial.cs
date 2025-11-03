using EducaRank.Domain.Exceptions;
using System.Text;
using System.Security.Cryptography;

namespace EducaRank.Domain.Models
{
    public class ProfessorCredencial
    {
        public string ProfessorId { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;

        private ProfessorCredencial() { }

        private ProfessorCredencial(string professorId, string senhaHash)
        {
            ProfessorId = professorId;
            SenhaHash = senhaHash;
        }

        public static ProfessorCredencial Criar(string professor_id, string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new DomainException("A senha é obrigatória.");

            var senhaHash = GerarHash(senha);
            return new ProfessorCredencial(professor_id, senhaHash);
        }

        private static string GerarHash(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return Convert.ToBase64String(bytes);
        }

        public bool VerificarSenha(string senha)
        {
            var hashTentativa = GerarHash(senha);
            return SenhaHash == hashTentativa;
        }
    }
}