package controllers

import (
	"encoding/json"
	"fmt"
	"github.com/gobuffalo/pop"
	"github.com/gorilla/mux"
	"log"
	"net/http"
	"soa_lab4_rest/models"
	"soa_lab4_rest/utils"
	"strconv"
)

func GetMessagesInDialog (w http.ResponseWriter, r *http.Request){
	w.Header().Set("Content-Type", "application/json")
	var messages []models.Message
	id := r.Context().Value("user").(int)
	params := mux.Vars(r)
	if paramsId, _ := strconv.Atoi(params["id"]);id == paramsId {
		utils.BadRequest(w)
		return
	}
	tx, err := pop.Connect("development")
	if err != nil{
		log.Panic(err)
	}
	err = tx.Where(fmt.Sprintf("(player_from = %d and player_to = %s) or " +
		"player_from = %s and player_to = %d",id, params["id"], params["id"], id)).All(&messages)
	if err != nil{
		utils.Respond(w, utils.Message(false, "Error"))
	}else{
		err = json.NewEncoder(w).Encode(messages)
	}
}

func CreateMessageInDialog (w http.ResponseWriter, r *http.Request){
	w.Header().Set("Content-Type", "application/json")
	var message models.Message
	id := r.Context().Value("user").(int)
	params := mux.Vars(r)
	if paramsId, _ := strconv.Atoi(params["id"]);id == paramsId {
		utils.BadRequest(w)
		return
	}
	err := json.NewDecoder(r.Body).Decode(&message)
	if err != nil{
		utils.BadRequest(w)
		return
	}
	message.PlayerFrom = id
	message.PlayerTo, _ = strconv.Atoi(params["id"])
	tx, _ := pop.Connect("development")
	_, err = tx.ValidateAndCreate(&message)
	if err != nil{
		utils.BadRequest(w)
		return
	}
	_ = json.NewEncoder(w).Encode(message)
}
