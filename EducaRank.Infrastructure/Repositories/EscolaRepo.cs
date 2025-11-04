using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;
using EducaRank.Infrastructure.Data;

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
    }
}
