using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;

namespace EducaRank.Domain.Services
{
    public class AlunoService
    {
        private readonly IAlunoService _alunoService;

        public AlunoService(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        public async Task<List<Aluno>> GetAlunos()
        {
            return await _alunoService.GetAlunos();
        }

        public async Task<Aluno> CreateAluno(Aluno aluno_model)
        {
            var new_aluno = new Aluno();
            new_aluno.Curso = aluno_model.Curso;
            new_aluno.Etec = aluno_model.Etec;
            new_aluno.Sala = aluno_model.Sala;
            new_aluno.Pontuacao = aluno_model.Pontuacao;
            new_aluno.Nome = aluno_model.Nome;
            new_aluno.Rm = aluno_model.Rm;
            new_aluno.Idade = aluno_model.Idade;
            new_aluno.Foto = aluno_model.Foto;
            new_aluno.Id = aluno_model.Id;
            new_aluno.SenhaHash = aluno_model.SenhaHash;
            new_aluno.NrAvaliacoes = aluno_model.NrAvaliacoes;

            return await _alunoService.CreateAluno(new_aluno);
        }

        public async Task<Aluno> GetAlunoById()
        {

        }
    }
}
