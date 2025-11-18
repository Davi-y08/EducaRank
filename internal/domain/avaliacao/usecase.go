package avaliacao

import "context"

type AvaliacaoUseCase interface {
	GetAll(ctx context.Context) ([]*Avaliacao, error)
	GetById(ctx context.Context, id string) (*Avaliacao, error)
	Create(ctx context.Context, aluno_id string, professor_id string, comentario string, nova_pontuacao int) error
	GetAvaliacoesByAluno(ctx context.Context, id string) ([]*Avaliacao, error)
	GetAvaliacoesByProfessor(ctx context.Context, id string) ([]*Avaliacao, error)
	DeleteAvaliacao(ctx context.Context, id string) error
}
