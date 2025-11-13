namespace EducaRank.Application.Dtos.AlunoDtos
{
    public class FiltrosRankingDto
    {
        public string Etec { get; set; } = string.Empty;
        public int? SalaId { get; set; } 
        public int? IdadeMinima { get; set; } 
        public int? IdadeMaxima { get; set; } 
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
