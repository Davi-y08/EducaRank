using EducaRank.Domain.Models;
using System.Reflection.Metadata.Ecma335;

namespace EducaRank.Application.Dtos.ProfessorDtos
{
    public class ReadProfessor
    {
        public string Id { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public IEnumerable<Sala> Salas { get; set; } = new List<Sala>();
        public string Foto { get; set; } = string.Empty;
        public int AvaliacoesFeitas { get; set; }
        public IEnumerable<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }
}
