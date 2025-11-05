using EducaRank.Application.Dtos.ProfessorDtos;
using EducaRank.Application.Mappers;
using EducaRank.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducaRank_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IAlunoService _aluno_service;
        private readonly IEscolaIntegrationService _escolaIntegrationService;
        private readonly IProfessorService _professorService;

        public UsuarioController(IAlunoService aluno_service, IEscolaIntegrationService escolaIntegrationService, IProfessorService professorService)
        {
            _aluno_service = aluno_service;
            _escolaIntegrationService = escolaIntegrationService;
            _professorService = professorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromForm] CreateUserDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                int rm = dto.Rm;
                string senha = dto.Senha;
                string cpf = dto.Cpf;
                string tipoUsuario = await _escolaIntegrationService.VerificarTipoUsuarioAoCadastro(dto.Rm);

                if (tipoUsuario == "aluno")
                {
                    var aluno = await _aluno_service.Create(rm, senha, cpf);
                    var readAluno = aluno.ToReadAluno();

                    return CreatedAtAction(
                        actionName: nameof(AlunoController.GetAluno),
                        controllerName: "Aluno",
                        routeValues: new { id = aluno.Id },
                        value: new
                        {
                            success = true,
                            data = readAluno,
                            message = "Aluno criado com sucesso."
                        }
                    );
                }
                else if (tipoUsuario == "professor")
                {
                    var professor = await _professorService.Create(rm, senha);
                    var readProfessor = professor.ToReadProfessor();

                    return CreatedAtAction(
                        actionName: "GetById",
                        controllerName: "Professor",
                        routeValues: new { id = professor.Id },
                        value: new
                        {
                            success = true,
                            data = readProfessor,
                            message = "Professor criado com sucesso."
                        }
                    );
                }

                return BadRequest(new
                {
                    success = false,
                    message = "Tipo de usuário desconhecido."
                });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    success = false,
                    message = ex.Message
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
