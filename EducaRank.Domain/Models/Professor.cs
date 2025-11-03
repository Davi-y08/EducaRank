using EducaRank.Domain.Exceptions;

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

        public Professor(int rm, string nome, List<Materia> materias, List<Sala> salas, int avaliacoesFeitas, ProfessorCredencial credencial)
        {
            Rm = rm;
            Nome = nome;
            Materias = materias;
            Salas = salas;
            AvaliacoesFeitas = avaliacoesFeitas;
            Credencial = credencial;
        }

        public void AtribuirCredencial(ProfessorCredencial credencial)
        {
            Credencial = credencial;
        }

        public static Professor Criar(int rm, string nome, List<Materia> materias, List<Sala> salas, int avaliacoes_feitas, string senha)
        {
            var professor = new Professor(rm, nome, materias, salas, avaliacoes_feitas, null!);
            var credencial = ProfessorCredencial.Criar(professor.Id, senha);
            professor.AtribuirCredencial(credencial);
            return professor;
        }

        public void Atualizar(string nome, string? senha = null)
        {
            if (!string.IsNullOrWhiteSpace(nome))
                Nome = nome;

            if (!string.IsNullOrWhiteSpace(senha))
            {
                var credencialAtualizada = ProfessorCredencial.Criar(Id, senha);
                AtribuirCredencial(credencialAtualizada);
            }
        }

        public void DefinirFoto(string caminho_foto)
        {
            if (string.IsNullOrWhiteSpace(caminho_foto))
                throw new DomainException("Caminho de foto inválido");

            Foto = caminho_foto;
        }
    }
}
