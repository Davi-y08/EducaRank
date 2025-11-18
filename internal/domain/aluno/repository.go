package aluno

import "context"

type AlunoRepository interface {
	Create(ctx context.Context, aluno *Aluno) error 
	GetByID(ctx context.Context, id string) (*Aluno, error)
	GetPontuacao(ctx context.Context, id string) (int, error) 
	GetAll(ctx context.Context) ([]*Aluno, error)
	Update(ctx context.Context, aluno *Aluno) error 
	DeleteByID(ctx context.Context, id string) error
	PontuacaoComFiltros(ctx context.Context, filtros Filtros) ([]*Aluno, int, error)
	GetByRm(ctx context.Context, rm int) (*Aluno, error)
	SearchAlunos(ctx context.Context, query string, page int, pageSize int) ([]*Aluno, int, error)
}
