namespace EducaRank.Domain.Models
{
    public class AlunoCredencial
    {
        public string AlunoId { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;

        private AlunoCredencial() { }

        public AlunoCredencial(string alunoId, string senhaHash)
        {
            AlunoId = alunoId;
            SenhaHash = senhaHash;
        }
    }
}