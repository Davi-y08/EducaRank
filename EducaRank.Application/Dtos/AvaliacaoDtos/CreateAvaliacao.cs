namespace EducaRank.Application.Dtos.AvaliacaoDtos
{
    public  class CreateAvaliacao
    {
        public int PontuacaoAlterada { get; set; }
        public string AlunoId { get; set; } = string.Empty;
        public string ProfessorId { get; set; } = string.Empty;
        public DateTime Data { get; set; }
    }
}
