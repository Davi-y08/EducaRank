package application

import (
	"context"
	"educarank/internal/domain/aluno"
	"educarank/internal/domain/legado"
	"educarank/internal/domain/sala"
	"errors"
	"strconv"
	"time"

	"golang.org/x/crypto/bcrypt"
)

type alunoUseCase struct {
	alunoRepo  aluno.AlunoRepository
	legadoRepo legado.LegadoRepository
	salaRepo sala.SalaRepository
}

// GetByRm implements aluno.AlunoUseCase.


func NewAlunoUseCase(repo aluno.AlunoRepository, legadoRepo legado.LegadoRepository, salaRepo sala.SalaRepository) aluno.AlunoUseCase {
	return &alunoUseCase{
		alunoRepo:  repo,
		legadoRepo: legadoRepo,
		salaRepo: salaRepo,
	}
}

func (u *alunoUseCase) GetById(ctx context.Context, id string) (*aluno.Aluno, error) {
	aluno_encontrado, erro := u.alunoRepo.GetByID(ctx, id)

	if erro != nil {
		return nil, erro
	}

	if aluno_encontrado == nil {
		return nil, aluno.ErroNotFound
	}

	return aluno_encontrado, nil
}

func (u *alunoUseCase) Create(ctx context.Context, rm int, senha string, cpf string) (*aluno.Aluno, error) {
	aluno_existente, erro := u.alunoRepo.GetByRm(ctx, rm)

	if erro != nil{
		return nil, erro
	}

	if aluno_existente != nil{
		return nil, errors.New("O aluno já existe na base de dados do educarank")
	}

	aluno_legado, erro := u.legadoRepo.GetAlunoLegadoByRM(ctx, rm)
	
	if erro != nil{
		return nil, erro
	}

	if aluno_legado == nil{
		return nil, legado.AlunoNotFound
	}

	if aluno_legado.CPF != cpf{
		return nil, legado.CpfNaoCoincide
	}

	sala_legado, erro := u.legadoRepo.GetSalaById(ctx, aluno_legado.SalaId)

	if erro != nil{
		return nil, erro
	}

	if sala_legado == nil{
		return nil, legado.SalaNotFound
	}

	var sala_final *sala.Sala

	sala_existente, erro := u.salaRepo.GetSalaByNome(ctx, sala_legado.NomeSala)
	
	if erro != nil{
		return nil, erro
	}

	if sala_existente != nil {
		sala_final = sala_existente	
	}else{
		nova_sala := &sala.Sala{
			NomeSala: sala_legado.NomeSala,
		}

		_, erro = u.salaRepo.Create(ctx, nova_sala)

		if erro != nil {
			return nil, erro
		}

		sala_final = nova_sala
	}

	idade := time.Now().Year() - aluno_legado.DataNascimento.Year()

	if time.Now().YearDay() < aluno_legado.DataNascimento.YearDay(){
		idade -= 1
	}

	hash, erro := bcrypt.GenerateFromPassword([]byte(senha), bcrypt.DefaultCost)
}

func (u *alunoUseCase) GetByRm(ctx context.Context, rm int) (*aluno.Aluno, error) {
	aluno_encontrado, erro := u.alunoRepo.GetByRm(ctx, rm)

	if erro != nil{
		return nil, erro
	}

	if aluno_encontrado == nil{
		return nil, aluno.ErroNotFound
	}

	return aluno_encontrado, nil
}

func (u *alunoUseCase) DeleteAlunoFromEducaRank(ctx context.Context, id string) error {
	panic("unimplemented")
}

func (u *alunoUseCase) GetAll(ctx context.Context) ([]*aluno.Aluno, error) {
	panic("unimplemented")
}

func (u *alunoUseCase) GetPontuacao(ctx context.Context, id string) (int, error) {
	panic("unimplemented")
}

func (u *alunoUseCase) PontuacaoComFiltros(ctx context.Context, filtros aluno.Filtros) ([]*aluno.Aluno, int, error) {
	panic("unimplemented")
}

func (u *alunoUseCase) SearchAlunos(ctx context.Context, query string, page int, pageSize int) ([]*aluno.Aluno, int, error) {
	panic("unimplemented")
}

func (u *alunoUseCase) Update(ctx context.Context, id string, senha *string) (*aluno.Aluno, error) {
	panic("unimplemented")
}
