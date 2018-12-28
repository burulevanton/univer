package controllers

import (
	"encoding/json"
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
	err = tx.All(&messages)
	if err != nil {
		utils.Respond(w, utils.Message(false, "Произошла ошибка"))
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
	err = tx.Find(&message, params["id"])
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
	_ = json.NewDecoder(r.Body).Decode(&message)
	tx, _ := pop.Connect("development")
	_, err := tx.ValidateAndCreate(&message)
	if err != nil {
		utils.BadRequest(w)
	}
	_ = json.NewEncoder(w).Encode(message)
}

func UpdateMessage(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var message models.Message
	tx, _ := pop.Connect("development")
	err := tx.Find(message, params["id"])
	if err != nil {
		utils.BadRequest(w)
	}
	message.ID, _ = strconv.Atoi(params["id"])
	_ = json.NewDecoder(r.Body).Decode(&message)
	_, err = tx.ValidateAndUpdate(&message)
	if err != nil {
		utils.BadRequest(w)
	}
	_ = json.NewEncoder(w).Encode(message)
}

func DeleteMessage(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var message models.Message
	tx, _ := pop.Connect("development")
	err := tx.Find(&message, params["id"])
	if err != nil {
		utils.BadRequest(w)
	}
	err = tx.Destroy(&message)
	if err != nil {
		utils.Respond(w, utils.Message(false, "Произошла ошибка"))
	}
}
