namespace EducaRank.Domain.Models
{
    public class Aluno
    {
        public string Id { get; set; } = string.Empty;
        public int Rm { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public string Sala { get; set; } = string.Empty;
        public string Etec { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string SenhaHash { get; set; } = string.Empty;
        public int Pontuacao { get; set; }
        public int NrAvaliacoes { get; set; }
        public string Foto { get; set; } = string.Empty;
    }
}
