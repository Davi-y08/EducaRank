namespace EducaRank.Application.Dtos.Aluno
{
    public class ReadPontuacaoAluno
    {
        public string Id { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public int Pontuacao { get; set; }
        public int NrAvaliacoes { get; set; }
    }
}
