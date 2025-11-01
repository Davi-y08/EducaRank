namespace EducaRank.Domain.Models
{
    public class ProfessorCredencial
    {
        public string ProfessorId { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;

        private ProfessorCredencial() { }

        public ProfessorCredencial(string professorId, string senhaHash)
        {
            ProfessorId = professorId;
            SenhaHash = senhaHash;
        }
    }
}