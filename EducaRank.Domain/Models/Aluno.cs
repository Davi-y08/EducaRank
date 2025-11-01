﻿namespace EducaRank.Domain.Models
{
    public class Aluno
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public int Rm { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Curso { get; private set; } = string.Empty;
        public string Sala { get; private set; } = string.Empty;
        public string Etec { get; private set; } = string.Empty;
        public int Idade { get; private set; } 
        public string Foto { get; private set; } = string.Empty;

        public int Pontuacao { get; private set; }
        public int NrAvaliacoes { get; private set; }

        public AlunoCredencial? Credencial { get; private set; }

        private Aluno() { }

        public Aluno(int rm, string nome, string curso, string sala, string etec, int idade)
        {
            Rm = rm;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Curso = curso ?? throw new ArgumentNullException(nameof(curso));
            Sala = sala ?? throw new ArgumentNullException(nameof(sala));
            Etec = etec ?? throw new ArgumentNullException(nameof(etec));
            Idade = idade;
            Pontuacao = 0;
            NrAvaliacoes = 0;
        }

        public void AtribuirCredencial(AlunoCredencial credencial)
        {
            Credencial = credencial;
        }
    }
}
