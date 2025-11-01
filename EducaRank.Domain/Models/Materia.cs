namespace EducaRank.Domain.Models
{
    public class Materia
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;

        private Materia() { }

        public Materia(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
