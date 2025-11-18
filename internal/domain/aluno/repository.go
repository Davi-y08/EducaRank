package aluno

import "context"

type IAlunoService interface {
	GetAll(ctx context.Context) ([]*Aluno, error)
	GetById(ctx context.Context, id string) (*Aluno, error)
	GetPontuacao(ctx context.Context, id string) (int, error)
	Update(ctx context.Context, aluno_model Aluno, id string) (*Aluno, error)
	PontuacaoComFiltros(ctx context.Context, filtros Filtros) ([]*Aluno, error)
	Create(ctx context.Context, rm int, senha string, cpf string) ([]*Aluno, error)
	DeleteAlunoFromEducaRank(ctx context.Context, id string) (bool, error)
	SearchAlunos(ctx context.Context, query string, page int, pageSize int) ([]*Aluno, error)
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