package models

import (
	"encoding/json"
)

type Location struct {
	ID           string `json:"id" db:"id"`
	Description  string `json:"description" db:"description"`
	LocationType string `json:"location_type" db:"location_type"`
}

// String is not required by pop and may be deleted
func (l Location) String() string {
	jl, _ := json.Marshal(l)
	return string(jl)
}

// Locations is not required by pop and may be deleted
type Locations []Location

// String is not required by pop and may be deleted
func (l Locations) String() string {
	jl, _ := json.Marshal(l)
	return string(jl)
}
