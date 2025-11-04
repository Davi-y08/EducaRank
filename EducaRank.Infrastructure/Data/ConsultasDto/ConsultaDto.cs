namespace EducaRank.Infrastructure.Data.ConsultasDto
{
    public class AlunoConsulta
    {
        public int RM { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sala { get; set; } = string.Empty;
        public string Etec { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
    }

    public class ProfessorConsulta
    {
        public int RM { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Disciplina { get; set; } = string.Empty;
    }
}