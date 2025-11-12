namespace EducaRank.Application.Dtos.ProfessorDtos
{
    public class CreateAvaliacaoDto
    {
        public string AlunoId { get; set; } = string.Empty;
        public int Pontuacao { get; set; }
        public string Comentário { get; set; } = string.Empty;
    }
}
