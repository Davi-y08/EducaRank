using EducaRank.Application.Dtos.MainDto;
using EducaRank.Application.Dtos.ProfessorDtos;
using EducaRank.Application.Mappers;
using EducaRank.Domain.Interfaces;
using EducaRank.Infrastructure.Data;
using EducaRank.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

namespace EducaRank_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IAlunoService _aluno_service;
        private readonly IEscolaIntegrationService _escolaIntegrationService;
        private readonly IProfessorService _professorService;
        private readonly TokenService _tokenService;
        private readonly AppDbContext _context;
        public UsuarioController(IAlunoService aluno_service, IEscolaIntegrationService escolaIntegrationService, IProfessorService professorService, TokenService tokenService, AppDbContext context)
        {
            _aluno_service = aluno_service;
            _escolaIntegrationService = escolaIntegrationService;
            _professorService = professorService;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("login")]
        [EnableRateLimiting("LoginPolicy")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var aux_aluno = await _context.Alunos.FirstOrDefaultAsync(x => x.Rm == dto.Rm);

            if (aux_aluno != null && aux_aluno.Credencial != null && aux_aluno.Credencial.VerificarSenha(dto.Senha))
            {
                var jwt = _tokenService.GenerateTokenAluno(aux_aluno);
                return Ok(new { jwt });
            }

            var aux_professor = await _context.Professores.FirstOrDefaultAsync(x => x.Rm == dto.Rm);

            if (aux_professor != null && aux_professor.Credencial != null && aux_professor.Credencial.VerificarSenha(dto.Senha))
            {
                var jwt = _tokenService.GenerateTokenProfessor(aux_professor);
                return Ok(new { jwt });
            }

            return Unauthorized("Login não autorizado");
        }

        
        [HttpPost("createuser")]
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
                    var jwt = _tokenService.GenerateTokenAluno(aluno);

                    return CreatedAtAction(
                        actionName: nameof(AlunoController.GetAluno),
                        controllerName: "Aluno",
                        routeValues: new { id = aluno.Id },
                        value: new
                        {
                            success = true,
                            data = readAluno,
                            message = "Aluno criado com sucesso.",
                            token = jwt
                        }
                    );
                }
                else if (tipoUsuario == "professor")
                {
                    var professor = await _professorService.Create(rm, senha, cpf);
                    var readProfessor = professor.ToReadProfessor();
                    var jwt = _tokenService.GenerateTokenProfessor(professor);

                    return CreatedAtAction(
                        actionName: "GetById",
                        controllerName: "Professor",
                        routeValues: new { id = professor.Id },
                        value: new
                        {
                            success = true,
                            data = readProfessor,
                            message = "Professor criado com sucesso.",
                            token = jwt
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
