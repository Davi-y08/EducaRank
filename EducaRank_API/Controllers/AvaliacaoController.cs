using EducaRank.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducaRank_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacoesService _avaliacao;

        public AvaliacaoController(IAvaliacoesService avaliacao)
        {
            _avaliacao = avaliacao;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var avaliacao = await _avaliacao.GetById(id);

            if (avaliacao == null)
                return NotFound("Avaliação não encontrada");

            return Ok(avaliacao);
        }


    }
}
