using EducaRank.Domain.Exceptions;

namespace EducaRank.Domain.Models
{
    public class Aluno
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public int Rm { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Curso { get; private set; } = string.Empty;
        public Sala? Sala { get; private set; }
        public int SalaId { get; private set; }
        public string Etec { get; private set; } = string.Empty;
        public int Idade { get; private set; } 
        public string Foto { get; private set; } = string.Empty;

        public int Pontuacao { get; private set; }
        public int NrAvaliacoes { get; private set; }
        public List<Avaliacao> Avaliacoes { get; private set; } = new();

        public AlunoCredencial? Credencial { get; private set; }

        private Aluno() { }

        public Aluno(int rm, string nome, string curso, Sala sala, string etec, int idade, AlunoCredencial credencial)
        {
            Rm = rm;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Curso = curso ?? throw new ArgumentNullException(nameof(curso));
            SalaId = sala.Id;
            Sala = sala;
            Etec = etec ?? throw new ArgumentNullException(nameof(etec));
            Idade = idade;
            Pontuacao = 0;
            NrAvaliacoes = 0;
            Credencial = credencial;
        }

        public void AtribuirCredencial(AlunoCredencial credencial)
        {
            Credencial = credencial;
        }

        public static Aluno Criar(int rm, string nome, string curso, Sala sala, string etec, int idade, string senha)
        {
            var aluno = new Aluno(rm, nome, curso, sala, etec, idade, null!);
            var credencial = AlunoCredencial.Criar(aluno.Id, senha);
            aluno.AtribuirCredencial(credencial);
            return aluno;
        }

        public void Atualizar(string nome, string? senha = null)
        {
            if (!string.IsNullOrWhiteSpace(nome))
                Nome = nome;

            if (!string.IsNullOrWhiteSpace(senha))
            {
                var credencialAtualizada = AlunoCredencial.Criar(Id, senha);
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
