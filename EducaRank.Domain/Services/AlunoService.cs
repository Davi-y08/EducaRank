using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;
using System.Runtime.CompilerServices;

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

        public async Task<Aluno> GetAlunoById(int id_aluno)
        {
            return await _alunoService.GetAlunoById(id_aluno);
        }

        public async Task<Aluno> ChangePfp(string pfp)
        {
            return await _alunoService.ChangePfp(pfp);
        }

        public async Task<Aluno> GetPontuacao(int id_aluno)
        {
            return await _alunoService.GetPontuacao(id_aluno);
        }

        public async Task<Aluno> GetNrAvaliacoes(int id_aluno)
        {
            return await _alunoService.GetNrAvaliacoes(id_aluno);
        }

        public async Task<bool> DeleteAlunoFromEducaRank(int id_aluno)
        {
            return await _alunoService.DeleteAlunoFromEducaRank(id_aluno);
        }

        public async Task<List<Avaliacao>> GetAvaliacoes(int id_aluno)
        {
            return await _alunoService.GetAvaliacoes(id_aluno);
        }

        public async Task<List<Aluno>> SearchAlunos(string query)
        {
            return await _alunoService.SearchAlunos(query);
        }

        public async Task<Aluno> ChangeEmail(string new_email)
        {
            return await _alunoService.ChangeEmail(new_email);
        }

        public async Task<Aluno> ChangePass(string old_pass, string new_pass)
        {
            return await _alunoService.ChangePassword(old_pass, new_pass);
        }

    }
}
