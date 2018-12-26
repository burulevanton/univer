package models

import (
	"encoding/json"
)

type Message struct {
	ID        int `json:"id" db:"id"`
	PlayerFrom int `json:"player_from" db:"player_from"`
	PlayerTo int `json:"player_to" db:"player_to"`
	MessageText string `json:"message_text" db:"message_text"`
}

// String is not required by pop and may be deleted
func (m Message) String() string {
	jm, _ := json.Marshal(m)
	return string(jm)
}

// Messages is not required by pop and may be deleted
type Messages []Message

// String is not required by pop and may be deleted
func (m Messages) String() string {
	jm, _ := json.Marshal(m)
	return string(jm)
}

