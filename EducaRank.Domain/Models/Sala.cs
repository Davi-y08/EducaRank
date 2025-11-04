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

        public static Sala Criar(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da sala é obrigatório.");

            return new Sala { NomeSala = nome.Trim() };
        }
    }
}
