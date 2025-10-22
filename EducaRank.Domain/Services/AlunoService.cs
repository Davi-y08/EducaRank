using EducaRank.Domain.Interfaces;

namespace EducaRank.Domain.Services
{
    public class AlunoService
    {
        private readonly IAlunoService _alunoService;

        public AlunoService(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        
    }
}
