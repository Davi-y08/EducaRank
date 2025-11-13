using EducaRank.Application.Dtos.AlunoDtos;
using EducaRank.Domain.Interfaces;
using EducaRank.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducaRank_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        private readonly LegadoEscolaDbContext _context;
        public AlunoController(IAlunoService alunoService, LegadoEscolaDbContext context)
        {
            _alunoService = alunoService;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAluno([FromRoute] string id)
        {
            var aluno = await _alunoService.GetById(id);
            if (aluno == null) return NotFound();
            return Ok(aluno);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<EducaRank.Domain.Models.Aluno> alunos = await _alunoService.GetAll();

            if(alunos == null) return NotFound();

            return Ok(alunos);
        }

        [HttpGet("ranking")]
        public async Task<IActionResult> GetRankingWithFiltersAndPagination([FromQuery] FiltrosRankingDto ranking_dto) 
        {
            var alunos = await _alunoService.PontuacaoComFiltos(ranking_dto.Etec, 
                ranking_dto.SalaId, 
                ranking_dto.IdadeMinima, 
                ranking_dto.IdadeMaxima, 
                ranking_dto.Page, 
                ranking_dto.PageSize);

            if(alunos == null) return NotFound("Nenhum aluno encontrado"); 
            
            return Ok( new {
                success = true,
                total = alunos.Count(),
                page = ranking_dto.Page,
                pageSize = ranking_dto.PageSize,
                data = alunos
            });
        }

        //[HttpPut("mudanças")]
        //public async Task<IActionResult> AlterarEtec()
        //{
        //    var alunos_legado = await _context.AlunoBdEtec.ToListAsync();

        //    for (int i = 0; i < alunos_legado.Count(); i++)
        //    {
        //        alunos_legado[i].Etec = "Sede";
        //    }

        //    for (int i = 0; i < alunos_legado.Count(); i+=2)
        //    {
        //        alunos_legado[i].Etec = "Extensão";
        //    }

        //    await _context.SaveChangesAsync();

        //    return Ok("Alterações concluidas com sucesso!");
        //}
    }
}
