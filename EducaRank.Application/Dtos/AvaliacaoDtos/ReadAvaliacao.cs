namespace EducaRank.Application.Dtos.AvaliacaoDtos
{
    public class ReadAvaliacao
    {
        public string Id { get; set; } = string.Empty;
        public int PontuacaoAlterada { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
    }
}
