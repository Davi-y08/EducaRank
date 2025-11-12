using EducaRank.Application.Dtos.AvaliacaoDtos;
using EducaRank.Domain.Models;

namespace EducaRank.Application.Mappers
{
    public static class AvaliacaoMapper
    {
        public static ReadAvaliacao ToReadAvaliacao(this Avaliacao avaliacao)
        {
            return new ReadAvaliacao
            {
                Id = avaliacao.Id,
                PontuacaoAlterada = avaliacao.PontuacaoAlterada,
                Data = avaliacao.Data,
            };
        }
    }
}
