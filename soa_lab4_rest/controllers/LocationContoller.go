package controllers

import (
	"encoding/json"
	"github.com/gobuffalo/pop"
	"github.com/gorilla/mux"
	"log"
	"net/http"
	"soa_lab4_rest/models"
	"soa_lab4_rest/utils"
)

func GetLocations(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	var locations []models.Location
	tx, err := pop.Connect("development")
	if err != nil {
		log.Panic(err)
	}
	err = tx.All(&locations)
	if err != nil {
		utils.Respond(w, utils.Message(false, "Произошла ошибка"))
	} else {
		err = json.NewEncoder(w).Encode(locations)
	}
}

func GetLocation(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var location models.Location
	tx, err := pop.Connect("development")
	if err != nil {
		log.Panic(err)
	}
	err = tx.Find(&location, params["id"])
	if err != nil {
		response := utils.Message(false, "Не найдено")
		w.WriteHeader(http.StatusNotFound)
		utils.Respond(w, response)
	} else {
		err = json.NewEncoder(w).Encode(location)
	}
}

func CreateLocation(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	var location models.Location
	_ = json.NewDecoder(r.Body).Decode(&location)
	tx, _ := pop.Connect("development")
	_, err := tx.ValidateAndCreate(&location)
	if err != nil {
		utils.BadRequest(w)
		return
	}
	_ = json.NewEncoder(w).Encode(location)
}

func UpdateLocation(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var location models.Location
	tx, _ := pop.Connect("development")
	err := tx.Find(&location, params["id"])
	if err != nil {
		utils.BadRequest(w)
		return
	}
	_ = json.NewDecoder(r.Body).Decode(&location)
	location.ID = params["id"]
	_, err = tx.ValidateAndUpdate(&location)
	if err != nil {
		utils.BadRequest(w)
		return
	} else {
		_ = json.NewEncoder(w).Encode(location)
	}
}

func DeleteLocation(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var location models.Location
	tx, _ := pop.Connect("development")
	err := tx.Find(&location, params["id"])
	if err != nil {
		utils.BadRequest(w)
		return
	}
	err = tx.Destroy(&location)
	if err != nil {
		utils.Respond(w, utils.Message(false, "Произошла ошибка"))
		return
	} else{
		utils.Respond(w, utils.Message(true, "Success"))
	}
}
