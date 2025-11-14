package models

type Professor struct{
	ID       string   `json:"id"`
    RM       int      `json:"rm"`
    Nome     string   `json:"nome"`
    Foto     string   `json:"foto"`
	Materias[] string `json:"materias"`
}