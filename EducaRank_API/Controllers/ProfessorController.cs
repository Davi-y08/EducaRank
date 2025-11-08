using EducaRank.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducaRank_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessor([FromRoute] string id)
        {
            var professor = await _professorService.GetById(id);

            if(professor == null)
                return NotFound();

            return Ok(professor);
        }
    }
}
