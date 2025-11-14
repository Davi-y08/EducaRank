package models

type Aluno struct {
	ID string `json:"id"`
	RM int `json:"rm"`
	Nome string `json:"nome"`
	SalaId int `json:"sala_id"`
	Etec string `json:"etec"`
	Idade int `json:"idade"`
	Foto string `json:"Foto"`
	Pontuacao int `json:"pontuacao"`
	NrAvaliacoes int `json:"nr_avaliacoes"`
}