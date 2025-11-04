using EducaRank.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducaRank_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAluno([FromRoute] string id)
        {
            var aluno = await _alunoService.GetById(id);
            if (aluno == null) return NotFound();
            return Ok(aluno);
        }
    }
}
