namespace EducaRank.Domain.Models
{
    public class Avaliacao
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        public Professor? Professor { get; private set; }
        public string ProfessorId { get; private set; } = string.Empty;

        public Aluno? Aluno { get; private set; }
        public string AlunoId { get; private set; } = string.Empty;

        public int PontuacaoAlterada { get; private set; }
        public string? Comentario { get; private set; } = string.Empty;
        public DateTime Data { get; private set; }

        private Avaliacao() { }

        public Avaliacao(Professor professor, Aluno aluno, int pontuacaoAlterada, string? comentario = null)
        {
            Professor = professor ?? throw new ArgumentNullException(nameof(professor));
            ProfessorId = professor.Id;

            Aluno = aluno ?? throw new ArgumentNullException(nameof(aluno));
            AlunoId = aluno.Id;

            PontuacaoAlterada = pontuacaoAlterada;
            Comentario = comentario;
            Data = DateTime.UtcNow;
        }

        public static Avaliacao Criar(Professor professor, Aluno aluno, int pontuacao, string? comentario = null)
        {
            return new Avaliacao(professor, aluno, pontuacao, comentario);
        }
    }
}
