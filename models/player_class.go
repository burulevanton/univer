package models

import (
	"encoding/json"
)

type PlayerClass struct {
	Name      string    `json:"name" db:"name"`
}

// String is not required by pop and may be deleted
func (p PlayerClass) String() string {
	jp, _ := json.Marshal(p)
	return string(jp)
}

// PlayerClasses is not required by pop and may be deleted
type PlayerClasses []PlayerClass

// String is not required by pop and may be deleted
func (p PlayerClasses) String() string {
	jp, _ := json.Marshal(p)
	return string(jp)
}
