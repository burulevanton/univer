package controllers

import (
	"encoding/json"
	"net/http"
	"soa_lab4_rest/models"
	"soa_lab4_rest/utils"
)

func Authenticate(w http.ResponseWriter, r *http.Request){
	player := &models.Player{}
	err := json.NewDecoder(r.Body).Decode(player)
	if err != nil {
		utils.Respond(w, utils.Message(false, "Invalid request"))
		return
	}
	resp := models.Login(player.Email, player.Password)
	utils.Respond(w, resp)
}