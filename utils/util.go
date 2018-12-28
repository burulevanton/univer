package utils

import (
	"encoding/json"
	"net/http"
)

func Message(status bool, message string) map[string]interface{} {
	return map[string]interface{}{"status": status, "message": message}
}

func Respond(w http.ResponseWriter, data map[string]interface{}) {
	w.Header().Add("Content-Type", "application/json")
	_ = json.NewEncoder(w).Encode(data)
}

func BadRequest(w http.ResponseWriter) {
	w.Header().Add("Content-Type", "application/json")
	response := Message(false, "Bad request")
	w.WriteHeader(http.StatusBadRequest)
	Respond(w, response)
}
