package controllers

import (
	"encoding/json"
	"net/http"
	"soa_lab4_rest/models"
	"soa_lab4_rest/utils"
)

func CreateUser(w http.ResponseWriter, r *http.Request) {
	user := &models.User{}
	err := json.NewDecoder(r.Body).Decode(user)
	if err != nil{
		utils.BadRequest(w)
	}
	resp := user.Create()
	utils.Respond(w, resp)
}

func Authenticate(w http.ResponseWriter, r *http.Request){
	user := &models.User{}
	err := json.NewDecoder(r.Body).Decode(user)
	if err != nil {
		utils.Respond(w, utils.Message(false, "Invalid request"))
	}
	resp := models.Login(user.Email, user.Password)
	utils.Respond(w, resp)
}