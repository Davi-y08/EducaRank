namespace EducaRank.Infrastructure.Data.ConsultasDto
{
    public class AlunoConsulta
    {
        public int RM { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public string Turma { get; set; } = string.Empty;
        public string Etec { get; set; } = string.Empty;
        public int Idade { get; set; }
    }

    public class ProfessorConsulta
    {
        public int RM { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Disciplina { get; set; } = string.Empty;
        public string Etec { get; set; } = string.Empty;
    }
}