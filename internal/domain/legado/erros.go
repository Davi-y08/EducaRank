package legado

import(
	"errors"
)

var AlunoNotFound = errors.New("Aluno não encontrado no banco de dados da etec")
var ProfessorNotFound = errors.New("Professor não encontrado no banco de dados da etec")
var SalaNotFound = errors.New("Sala não encontrada no banco de dados da etec")
var CpfNaoCoincide = errors.New("Os CPFs não são iguais")