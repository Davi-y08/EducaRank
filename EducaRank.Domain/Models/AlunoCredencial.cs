using System.Security.Cryptography;
using System.Text;
using EducaRank.Domain.Exceptions;

namespace EducaRank.Domain.Models
{
    public class AlunoCredencial
    {
        public string AlunoId { get; private set; }
        public string SenhaHash { get; private set; }
        public string Salt { get; private set; }

        private AlunoCredencial() { }

        private AlunoCredencial(string aluno_id, string senhaHash, string salt)
        {
            AlunoId = aluno_id;
            SenhaHash = senhaHash;
            Salt = salt;
        }

        public static AlunoCredencial Criar(string aluno_id, string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new DomainException("A senha é obrigatória.");

            var saltBytes = RandomNumberGenerator.GetBytes(16);
            var salt = Convert.ToBase64String(saltBytes);

            var senhaHash = GerarHash(senha, salt);

            return new AlunoCredencial(aluno_id, senhaHash, salt);
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
