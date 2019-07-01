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
	response := Message(false, "Bad request")
	w.WriteHeader(http.StatusBadRequest)
	Respond(w, response)
}

func PermissionDenied(w http.ResponseWriter){
	response := Message(false, "Permission denied")
	w.WriteHeader(http.StatusForbidden)
	Respond(w, response)
}
