using EducaRank.Domain.Interfaces;
using EducaRank.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EducaRank.Domain.Exceptions
{
    public class AlunoException
    {
        private readonly IAlunoService _alunoService;

        public AlunoException(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        public async Task<List<Aluno>> GetAlunos()
        {
            return await _alunoService.GetAlunos();
        }

        public async Task<Aluno> CreateAluno(Aluno aluno_model)
        {
            if (string.IsNullOrWhiteSpace(aluno_model.Nome))
                throw new ValidationException("Nome do aluno é obrigatório.");

            if (aluno_model.Idade <= 0)
                throw new ValidationException("Idade inválida.");

            if (string.IsNullOrWhiteSpace(aluno_model.Foto))
                aluno_model.Foto = "path/fotopadrao.png";


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

        public async Task<Aluno> ChangePfp(string pfp)
        {
            if (string.IsNullOrWhiteSpace(pfp))
                throw new ValidationException("A foto de perfil deve existir");

            return await _alunoService.ChangePfp(pfp);
        }

        public async Task<Aluno> ChangeEmail(string new_email)
        {
            if (string.IsNullOrWhiteSpace(new_email))
                throw new ValidationException("O email é obrigatório!");

            return await _alunoService.ChangeEmail(new_email);
        }

    }
}
