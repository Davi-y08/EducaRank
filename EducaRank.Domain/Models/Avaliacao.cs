namespace EducaRank.Domain.Models
{
    public class Avaliacoes
    {
        public int Id { get; set; }
        public Professor Professor { get; set; } = new Professor();
        public int Rm_professor { get; set; }
        public Aluno Aluno { get; set; } = new Aluno();
        public int Rm_aluno { get; set; }
        public int Pontuacao_alterada { get; set; }
        public List<string> Bases { get; set; } = new List<string>();
    }
}
