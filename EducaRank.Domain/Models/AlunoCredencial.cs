using System.Security.Cryptography;
using System.Text;
using EducaRank.Domain.Exceptions;

namespace EducaRank.Domain.Models
{
    public class AlunoCredencial
    {
        public string AlunoId { get; private set; }
        public string SenhaHash { get; private set; }

        private AlunoCredencial() { }

        private AlunoCredencial(string aluno_id, string senhaHash)
        {
            AlunoId = aluno_id;
            SenhaHash = senhaHash;
        }

        public static AlunoCredencial Criar(string aluno_id, string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new DomainException("A senha é obrigatória.");

            var senhaHash = GerarHash(senha);
            return new AlunoCredencial(aluno_id, senhaHash);
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
