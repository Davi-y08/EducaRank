package sala

import(
	"context"
)

type SalaRepository interface{
	GetSalaByNome(ctx context.Context, nome_sala string) (*Sala, error)
	Create(ctx context.Context, sala *Sala) (*Sala, error)
}