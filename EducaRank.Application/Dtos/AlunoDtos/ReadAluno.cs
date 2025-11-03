namespace EducaRank.Application.Dtos.AlunoDtos
{
    public class ReadAluno
    {
        public string Id { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public string Sala { get; set; } = string.Empty;
        public int Rm { get; set; }
        public int Idade { get; set; }
        public string Foto { get; set; } = string.Empty;
        public int Pontuacao { get; set; }
        public string Etec { get; set; } = string.Empty;
        public int NrAvaliacoes { get; set; }
    }
}
