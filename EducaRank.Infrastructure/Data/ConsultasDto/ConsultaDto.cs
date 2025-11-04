using System.ComponentModel.DataAnnotations.Schema;

namespace EducaRank.Infrastructure.Data.ConsultasDto
{
    public class AlunoConsulta
    {
        [Column("rm")]
        public int RM { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("sala_id")]
        public int SalaId { get; set; }

        [Column("dt_nascimento")] 
        public DateTime DataNascimento { get; set; }

        [Column("etec")]
        public string Etec { get; set; } = string.Empty;
    }

    public class ProfessorConsulta
    {
        public int RM { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Disciplina { get; set; } = string.Empty;
    }

    public class SalaConsulta
    {
        public int Id { get; set; }
        public string NomeSala { get; set; } = string.Empty;
    }
}