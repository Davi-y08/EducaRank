namespace EducaRank.Domain.Models
{
    public class Professor
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public int Rm { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public List<Materia> Materias { get; private set; } = new();
        public List<Sala> Salas { get; private set; } = new();
        public string Foto { get; private set; } = string.Empty;
        public int AvaliacoesFeitas { get; private set; }

        public ProfessorCredencial? Credencial { get; private set; }

        private Professor() { }

        public Professor(string id, int rm, string nome, List<Materia> materias, List<Sala> salas, string foto, int avaliacoesFeitas)
        {
            Rm = rm;
            Nome = nome;
            Materias = materias;
            Salas = salas;
            Foto = foto;
            AvaliacoesFeitas = avaliacoesFeitas;
        }

        public void AtribuirCredencial(ProfessorCredencial credencial)
        {
            Credencial = credencial;
        }

        public void AdicionarMateria(Materia materia)
        {

        }
    }
}
