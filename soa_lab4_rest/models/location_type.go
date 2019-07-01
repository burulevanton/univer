package models

import (
	"encoding/json"
)

type LocationType struct {
	Name string `json:"name" db:"name"`
}

// String is not required by pop and may be deleted
func (l LocationType) String() string {
	jl, _ := json.Marshal(l)
	return string(jl)
}

// LocationTypes is not required by pop and may be deleted
type LocationTypes []LocationType

// String is not required by pop and may be deleted
func (l LocationTypes) String() string {
	jl, _ := json.Marshal(l)
	return string(jl)
}
