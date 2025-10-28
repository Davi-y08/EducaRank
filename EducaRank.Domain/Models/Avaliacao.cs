namespace EducaRank.Domain.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }

        //
        public Professor Professor { get; set; } = null!;
        public int RmProfessor { get; set; }
        //

        //
        public Aluno Aluno { get; set; } = null!;
        public int Rm_aluno { get; set; }
        //

        public int Pontuacao_alterada { get; set; }
        public List<BaseAvaliacao> Bases { get; set; } = new();
        public string? Comentario { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
    }
}
-