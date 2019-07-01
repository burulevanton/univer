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
	var allPlayers []interface{}
	var currentPlayer models.Player
	var otherPlayers []models.Player
	tx, err := pop.Connect("development")
	if err != nil {
		log.Panic(err)
	}
	id := r.Context().Value("user").(int)
	err = tx.Find(&currentPlayer, id)
	err = tx.Select("id, name, level, position, player_class").Where("id != " + strconv.Itoa(id)).All(&otherPlayers)
	if err != nil {
		utils.Respond(w, utils.Message(false, "Failed"))
		return
	}
	for _, value := range otherPlayers {
		allPlayers = append(allPlayers, value.PlayerToAlienPlayer())
	}
	currentPlayer.Password = "***********"
	currentPlayer.Token = "************"
	allPlayers = append(allPlayers, currentPlayer)
	err = json.NewEncoder(w).Encode(allPlayers)
}

func GetPlayer(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var player models.Player
	tx, err := pop.Connect("development")
	if err != nil {
		log.Panic(err)
	}
	id := r.Context().Value("user").(int)
	if requestId, _ := strconv.Atoi(params["id"]); requestId == id{
		err = tx.Find(&player, params["id"])
		if err != nil {
			response := utils.Message(false, "Не найдено")
			w.WriteHeader(http.StatusNotFound)
			utils.Respond(w, response)
			return
		}
		player.Password = "***********"
		player.Token = "************"
		_ = json.NewEncoder(w).Encode(player)
	} else {
		err = tx.Select("id, name, level, position, player_class").Find(&player, params["id"])
		alienPlayer := player.PlayerToAlienPlayer()
		_ = json.NewEncoder(w).Encode(alienPlayer)
	}
}

func CreatePlayer(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	var player models.Player
	err := json.NewDecoder(r.Body).Decode(&player)
	if err != nil{
		utils.BadRequest(w)
		return
	}
	resp := player.Create()
	utils.Respond(w, resp)
}

func UpdatePlayer(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	id := r.Context().Value("user").(int)
	params := mux.Vars(r)
	if requestId, _ := strconv.Atoi(params["id"]); requestId != id{
		utils.PermissionDenied(w)
		return
	}
	var player models.Player
	tx, _ := pop.Connect("development")
	err := tx.Find(&player, params["id"])
	if err != nil {
		utils.BadRequest(w)
		return
	}
	_ = json.NewDecoder(r.Body).Decode(&player)
	player.ID, _ = strconv.Atoi(params["id"])
	_, err = tx.ValidateAndUpdate(&player)
	if err != nil {
		utils.BadRequest(w)
	}
	player.Password = "***********"
	player.Token = "************"
	_ = json.NewEncoder(w).Encode(player)
}

func DeletePlayer(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	id := r.Context().Value("user").(int)
	params := mux.Vars(r)
	if requestId, _ := strconv.Atoi(params["id"]); requestId != id{
		utils.PermissionDenied(w)
		return
	}
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
	utils.Respond(w, utils.Message(true, "Success"))
}

