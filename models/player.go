package models

import (
	"encoding/json"
)

type Player struct {
	ID          int    `json:"id" db:"id"`
	Name        string `json:"name" db:"name"`
	Email       string `json:"email" db:"email"`
	Level       int    `json:"level" db:"level"`
	Position    string `json:"position" db:"position"`
	PlayerClass string `json:"player_class" db:"player_class"`
}

// String is not required by pop and may be deleted
func (p Player) String() string {
	jp, _ := json.Marshal(p)
	return string(jp)
}

// Players is not required by pop and may be deleted
type Players []Player

// String is not required by pop and may be deleted
func (p Players) String() string {
	jp, _ := json.Marshal(p)
	return string(jp)
}
