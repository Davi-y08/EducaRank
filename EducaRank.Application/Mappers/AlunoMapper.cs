using EducaRank.Application.Dtos.AlunoDtos;
using EducaRank.Domain.Models;

namespace EducaRank.Application.Mappers
{
    public static class AlunoMapper
    {
        public static Aluno ToCreateAluno(this CreateAluno dto, string? caminho_foto = null)
        {
            var aluno = Aluno.Criar(
                dto.Rm,
                dto.Nome,
                dto.Curso,
                dto.Sala,
                dto.Etec,
                dto.Idade,
                dto.Senha
            );

            if (!string.IsNullOrEmpty(caminho_foto))
                aluno.DefinirFoto(caminho_foto);

            return aluno;
        }

        public static ReadAluno ToReadAluno(this Aluno aluno)
        {
            return new ReadAluno
            {
                Id = aluno.Id,
                Rm = aluno.Rm,
                Nome = aluno.Nome,
                Curso = aluno.Curso,
                Sala = aluno.Sala,
                Etec = aluno.Etec,
                Idade = aluno.Idade,
                Foto = aluno.Foto,
                Pontuacao = aluno.Pontuacao,
                NrAvaliacoes = aluno.NrAvaliacoes
            };
        }

        public static void ToUpdateAluno(this Aluno aluno, UpdateAluno dto)
        {
            aluno.Atualizar(dto.Nome, dto.Senha);
        }
    }
}
