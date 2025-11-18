package legado

import "time"

type AlunoLegado struct {
    RM             int       `json:"rm" db:"rm"`
    CPF            string    `json:"cpf" db:"cpf"`
    Nome           string    `json:"nome" db:"nome"`
    SalaId         int       `json:"sala_id" db:"sala_id"`
    DataNascimento time.Time `json:"dt_nascimento" db:"dt_nascimento"`
    Etec           string    `json:"etec" db:"etec"`
}

type ProfessorLegado struct {
    RM   int    `json:"rm" db:"rm"`
    Nome string `json:"nome" db:"nome"`
    CPF  string `json:"cpf" db:"cpf"`
}

type MateriaLegado struct {
    ID   int    `json:"id" db:"id"`
    Nome string `json:"materia" db:"materia"`
}

type SalaLegado struct {
    ID       int    `json:"id" db:"id"`
    NomeSala string `json:"nome_sala" db:"nome_sala"`
}