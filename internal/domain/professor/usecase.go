package professor

import "context"

type ProfessorUseCase interface {
	GetAll(ctx context.Context) ([]*Professor, error)
	GetById(ctx context.Context, id string) (*Professor, error)
	Create(ctx context.Context, rm int, senha string, cpf string) (*Professor, error)
	Update(ctx context.Context, senha *string, id string) (*Professor, error)
	SearchProfessores(ctx context.Context, query string, page int, pageSize int) ([]*Professor, error)
	Delete(ctx context.Context, id string) error
}