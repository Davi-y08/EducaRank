package avaliacao

import "time"

type Avaliacao struct{
	ID string `json:"id"`
	ProfessorID string `json:"professor_id"`
	AlunoID string `json:"aluno_id"`
	PontuacaoAlterada int `json:"pontuacao_alterada"`
	Comentario string `json:"Comentario"`
	Data time.Time `json:"data"`
}