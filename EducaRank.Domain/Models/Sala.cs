namespace EducaRank.Domain.Models
{
    public class Sala
    {
        public int Id { get; private set; }
        public string NomeSala { get; private set; } = string.Empty;
        public List<Aluno> Alunos { get; private set; } = new();

        private Sala() { }

        public Sala(int id, string nome)
        {
            Id = id;
            NomeSala = nome;
        }
    }
}
