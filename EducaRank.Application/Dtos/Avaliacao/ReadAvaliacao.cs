namespace EducaRank.Application.Dtos.Avaliacao
{
    public class ReadAvaliacao
    {
        public string Id { get; set; } = string.Empty;
        public int PontuacaoAlterada { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
    }
}
