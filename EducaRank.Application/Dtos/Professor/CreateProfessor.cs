using EducaRank.Domain.Models;

namespace EducaRank.Application.Dtos.Professor
{
    public class CreateProfessor
    {
        public int Rm { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<Materia> Materias { get; set; } = new List<Materia>();
        public List<Sala> Salas { get; set; } = new List<Sala>();
        public string Foto { get; set; } = string.Empty;
        public int AvaliacoesFeitas { get; set; } = 0;
        public string Senha { get; set; } = 
    }
}
