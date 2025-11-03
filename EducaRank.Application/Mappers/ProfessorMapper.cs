using EducaRank.Application.Dtos.ProfessorDtos;
using EducaRank.Domain.Models;

namespace EducaRank.Application.Mappers
{
    public static class ProfessorMapper
    {
        public static Professor ToCreateProfessor(this CreateProfessor dto, string? caminho_foto = null)
        {
            var professor = Professor.Criar(
                dto.Rm,
                dto.Nome,
                dto.Materias,
                dto.Salas,
                dto.AvaliacoesFeitas,
                dto.Senha
                );

            if (!string.IsNullOrEmpty(caminho_foto))
                professor.DefinirFoto(caminho_foto);

            return professor;
        }


    }
}
