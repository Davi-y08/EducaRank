package professor

type ProfessorCredencial struct {
    ProfessorID string `json:"professor_id"`
    SenhaHash   string `json:"senha_hash"`
    Salt        string `json:"salt"`
}