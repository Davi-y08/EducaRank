using System.ComponentModel.DataAnnotations.Schema;

namespace EducaRank.Infrastructure.Data.ConsultasDto
{
    public class AlunoConsulta
    {
        [Column("rm")]
        public int RM { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; } = string.Empty;

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
        [Column("rm")]
        public int RM { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("cpf")]
        public string Cpf { get; set; } = string.Empty;
    }

    public class MateriaConsulta
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("materia")]
        public string Nome { get; set; } = string.Empty;
    }

    public class ProfessorMateriaConsulta
    {
        [Column("professor_rm")]
        public int RMProfessor { get; set; }

        [Column("materia_id")]
        public int IdMateria { get; set; }
    }

    public class SalaConsulta
    {
        public int Id { get; set; }
        public string NomeSala { get; set; } = string.Empty;
    }
}