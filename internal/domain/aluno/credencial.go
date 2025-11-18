package aluno

type AlunoCredencial struct {
	AlunoID string `json:"aluno_id"`
	SenhaHash string `json:"senha_hash"`
	Salt string `json:"salt"`
}