using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;
using EducaRank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducaRank.Infrastructure.Repositories
{
    public class EscolaRepo : IEscolaIntegrationService
    {
        private readonly LegadoEscolaDbContext _context;

        public EscolaRepo(LegadoEscolaDbContext context)
        {
            _context = context;
        }

        public Task<Aluno?> GetAlunoFromEscolaByRM(int RM)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aluno>> GetAlunosFromEscola()
        {
            throw new NotImplementedException();
        }

        public async Task<string> VerificarTipoUsuarioAoCadastro(int rm)
        {
            var aluno = await _context.AlunoBdEtec.FirstOrDefaultAsync(x => x.RM == rm);
            var professor = await _context.ProfessorBdEtec.FirstOrDefaultAsync(_ => _.RM == rm);

            if (aluno != null)
            {
                return "aluno";
            }

            else if(professor != null)
            {
                return "professsor";
            }

            return "notExist";
        }
    }
}
