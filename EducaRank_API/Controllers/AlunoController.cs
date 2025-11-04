using EducaRank.Application.Dtos.AlunoDtos;
using EducaRank.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EducaRank_API.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _aluno_service;

        public AlunoController(IAlunoService aluno_service)
        {
            _aluno_service = aluno_service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlunoTeste([FromForm] CreateAluno dto)
        {
            int rm = dto.Rm;
            string senha = dto.Senha;

            var response = await _aluno_service.Create(rm, senha);

            if (response == null)
            {
                return BadRequest("Erro ao criar usuário");
            }

            return Ok(response);
        }
    }
}
