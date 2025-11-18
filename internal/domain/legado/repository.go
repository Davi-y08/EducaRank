package legado

import(
	"context"
)

type LegadoRepository interface{
	GetAlunoLegadoByRM(ctx context.Context, rm int) (*AlunoLegado, error)
	GetProfessorLegadoByRm(ctx context.Context, rm int) (*ProfessorLegado, error)
	GetSalaById(ctx context.Context, id_sala int) (*SalaLegado, error)
}