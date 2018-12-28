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

func GetPlayers(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	var players []models.Player
	tx, err := pop.Connect("development")
	if err != nil {
		log.Panic(err)
	}
	err = tx.All(&players)
	if err != nil {
		utils.Respond(w, utils.Message(false, "Произошла ошибка"))
	} else {
		err = json.NewEncoder(w).Encode(players)
	}
}

func GetPlayer(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var player models.Player
	tx, err := pop.Connect("development")
	if err != nil {
		log.Panic(err)
	}
	err = tx.Find(&player, params["id"])
	if err != nil {
		response := utils.Message(false, "Не найдено")
		w.WriteHeader(http.StatusNotFound)
		utils.Respond(w, response)
	} else {
		err = json.NewEncoder(w).Encode(player)
	}
}

func CreatePlayer(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	var player models.Player
	_ = json.NewDecoder(r.Body).Decode(&player)
	tx, _ := pop.Connect("development")
	_, err := tx.ValidateAndCreate(&player)
	if err != nil {
		utils.BadRequest(w)
	}
	_ = json.NewEncoder(w).Encode(player)
}

func UpdatePlayer(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var player models.Player
	tx, _ := pop.Connect("development")
	err := tx.Find(player, params["id"])
	if err != nil {
		utils.BadRequest(w)
	}
	_ = json.NewDecoder(r.Body).Decode(&player)
	player.ID, _ = strconv.Atoi(params["id"])
	_, err = tx.ValidateAndUpdate(&player)
	if err != nil {
		utils.BadRequest(w)
	}
	_ = json.NewEncoder(w).Encode(player)
}

func DeletePlayer(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var player models.Player
	tx, _ := pop.Connect("development")
	err := tx.Find(&player, params["id"])
	if err != nil {
		utils.BadRequest(w)
	}
	err = tx.Destroy(&player)
	if err != nil {
		utils.Respond(w, utils.Message(false, "Произошла ошибка"))
	}
}
