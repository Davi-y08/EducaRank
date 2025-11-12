using EducaRank.Application.Dtos.AvaliacaoDtos;
using EducaRank.Application.Dtos.ProfessorDtos;
using EducaRank.Application.Mappers;
using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace EducaRank_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        private readonly IAvaliacoesService _avaliacoesService;
        public ProfessorController(IProfessorService professorService, IAvaliacoesService avaliacoesService)
        {
            _professorService = professorService;
            _avaliacoesService = avaliacoesService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessor([FromRoute] string id)
        {
            var professor = await _professorService.GetById(id);

            if(professor == null)
                return NotFound("Professor não encontrado");

            return Ok(professor);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReadProfessor>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProfessores()
        {
            var professores = await _professorService.GetAll();
            var dtos = professores.Select(p => p.ToReadProfessor()).ToList();

            return Ok(dtos);
        }

        [Authorize(Policy = "Professor")]
        [HttpPost("createavaliacao")]
        public async Task<IActionResult> CreateAvaliacao([FromBody] CreateAvaliacaoDto dto)
        {
            try
            {
                string? professor_id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if  (string.IsNullOrEmpty(professor_id))
                    return Unauthorized("Professor não encontrado");

                var nova_avaliacao = await _avaliacoesService.CreateAvaliacao(dto.AlunoId, professor_id, dto.Comentário, dto.Pontuacao);

                if (nova_avaliacao == null)
                    return BadRequest(new { message = "Não foi possível criar a avaliação." });

                var read_avaliacao = nova_avaliacao.ToReadAvaliacao();

                return CreatedAtAction(
                    actionName: nameof(AvaliacaoController.GetById),
                    controllerName: "Avaliacao",
                    routeValues: new { id = nova_avaliacao.Id },
                    value: new
                    {
                        sucess = true,
                        data = read_avaliacao,
                        message = "Avaliação criada com sucesso"
                    }
                );
            }

            catch(InvalidOperationException ex)
            {
                return Conflict(new
                {
                    sucess = false,
                    message = ex.Message,
                });
            }

            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    success = false,
                    message = ex.Message
                });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Erro interno no servidor.",
                    detalhe = ex.Message
                });
            }
        }
    }
}
