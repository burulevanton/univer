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

func GetMessages(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	var messages []models.Message
	tx, err := pop.Connect("development")
	if err != nil {
		log.Panic(err)
	}
	id := r.Context().Value("user").(int)
	err = tx.Where(fmt.Sprintf("player_from = %d or player_to = %d", id, id)).All(&messages)
	if err != nil {
		utils.Respond(w, utils.Message(false, "Error"))
	} else {
		err = json.NewEncoder(w).Encode(messages)
	}
}

func GetMessage(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var message models.Message
	tx, err := pop.Connect("development")
	if err != nil {
		log.Panic(err)
	}
	id := r.Context().Value("user").(int)
	err = tx.Find(&message, params["id"])
	if message.PlayerTo != id && message.PlayerFrom != id{
		utils.PermissionDenied(w)
		return
	}
	if err != nil {
		response := utils.Message(false, "Не найдено")
		w.WriteHeader(http.StatusNotFound)
		utils.Respond(w, response)
	} else {
		err = json.NewEncoder(w).Encode(message)
	}
}

func CreateMessage(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	var message models.Message
	err := json.NewDecoder(r.Body).Decode(&message)
	id := r.Context().Value("user").(int)
	tx, _ := pop.Connect("development")
	if message.PlayerTo == message.PlayerFrom || message.MessageText == "" || id != message.PlayerFrom{
		utils.BadRequest(w)
		return
	}
	_, err = tx.ValidateAndCreate(&message)
	if err != nil {
		utils.BadRequest(w)
		return
	}
	_ = json.NewEncoder(w).Encode(message)
}

func UpdateMessage(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var message models.Message
	tx, _ := pop.Connect("development")
	id := r.Context().Value("user").(int)
	_ = json.NewDecoder(r.Body).Decode(&message)
	if message.PlayerFrom != 0 || message.PlayerTo != 0{
		utils.BadRequest(w)
		return
	}
	err := tx.Find(&message, params["id"])
	if err != nil {
		utils.BadRequest(w)
		return
	}
	if message.PlayerFrom != id{
		utils.PermissionDenied(w)
		return
	}
	message.ID, _ = strconv.Atoi(params["id"])
	_, err = tx.ValidateAndUpdate(&message)
	if err != nil {
		utils.BadRequest(w)
		return
	}
	_ = json.NewEncoder(w).Encode(message)
}

func DeleteMessage(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var message models.Message
	tx, _ := pop.Connect("development")
	id := r.Context().Value("user").(int)
	err := tx.Find(&message, params["id"])
	if err != nil {
		utils.BadRequest(w)
		return
	}
	if message.PlayerFrom != id{
		utils.PermissionDenied(w)
		return
	}
	err = tx.Destroy(&message)
	if err != nil {
		utils.Respond(w, utils.Message(false, "Произошла ошибка"))
	}else{
		utils.Respond(w, utils.Message(true, "Success"))
	}
}
