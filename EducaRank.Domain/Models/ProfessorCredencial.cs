using EducaRank.Domain.Exceptions;
using System.Text;
using System.Security.Cryptography;

namespace EducaRank.Domain.Models
{
    public class ProfessorCredencial
    {
        public string ProfessorId { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;
        public string Salt { get; private set; }

        private ProfessorCredencial() { }

        private ProfessorCredencial(string professorId, string senhaHash, string salt)
        {
            ProfessorId = professorId;
            SenhaHash = senhaHash;
            Salt = salt;
        }

        public static ProfessorCredencial Criar(string professor_id, string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new DomainException("A senha é obrigatória.");

            var saltBytes = RandomNumberGenerator.GetBytes(16);
            var salt = Convert.ToBase64String(saltBytes);

            var senhaHash = GerarHash(senha, salt);

            return new ProfessorCredencial(professor_id, senhaHash, salt);
        }

        private static string GerarHash(string senha, string salt)
        {
            using var deriveBytes = new Rfc2898DeriveBytes(
               senha,
               Convert.FromBase64String(salt),
               10000,
               HashAlgorithmName.SHA256
           );
            return Convert.ToBase64String(deriveBytes.GetBytes(32));
        }

        public bool VerificarSenha(string senha)
        {
            var hashTentativa = GerarHash(senha, Salt);
            return SenhaHash == hashTentativa;
        }
    }
}