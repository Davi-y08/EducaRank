namespace EducaRank.Domain.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public int Rm { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<string> Materias { get; set; } = new();
        public List<string> Salas { get; set; } = new();
        public string Foto { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public int AvaliacoesFeitas { get; set; }
    }
}
