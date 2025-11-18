package avaliacao

import "context"

type IAvaliacaoService interface {
	GetAll(ctx context.Context) ([]*Avaliacao, error)
	GetById(ctx context.Context, id string) (*Avaliacao, error)
	GetAvaliacoesByAluno(ctx context.Context, id string) ([]*Avaliacao, error)
	GetAvaliacoesByProfessor(ctx context.Context, id string) ([]*Avaliacao, error)
	DeleteAvaliacao(ctx context.Context, id string) (bool, error)
}
