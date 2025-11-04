using EducaRank.Application.Dtos.AlunoDtos;
using EducaRank.Domain.Models;

namespace EducaRank.Application.Mappers
{
    public static class AlunoMapper
    {
        public static ReadAluno ToReadAluno(this Aluno aluno)
        {
            return new ReadAluno
            {
                Id = aluno.Id,
                Rm = aluno.Rm,
                Nome = aluno.Nome,
                SalaId = aluno.SalaId,
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
