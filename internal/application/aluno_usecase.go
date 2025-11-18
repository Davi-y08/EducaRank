package application

import (
	"context"
	"educarank/internal/domain/aluno"
)

type alunoUseCase struct{
	alunoRepo aluno.IAlunoService
}

