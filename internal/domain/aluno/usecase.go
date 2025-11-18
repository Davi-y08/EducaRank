package aluno

import "context"

type AlunoUseCase interface {
	GetAll(ctx context.Context) ([]*Aluno, error)
	GetById(ctx context.Context, id string) (*Aluno, error)
	GetPontuacao(ctx context.Context, id string) (int, error)
	Update(ctx context.Context, id string, senha *string) (*Aluno, error)
	PontuacaoComFiltros(ctx context.Context, filtros Filtros) ([]*Aluno, int, error)
	Create(ctx context.Context, rm int, senha string, cpf string) (*Aluno, error)
	DeleteAlunoFromEducaRank(ctx context.Context, id string) error
	SearchAlunos(ctx context.Context, query string, page int, pageSize int) ([]*Aluno, int, error)
}

type Filtros struct{
	//schools filters
	Etec *string
	Sala *int
	IdadeMin *int
	IdadeMax *int

	// pagination
	Page int
	PageSize int
}