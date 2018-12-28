package main

import (
	"github.com/gorilla/handlers"
	"github.com/gorilla/mux"
	"net/http"
	"os"
	"soa_lab4_rest/controllers"
	"soa_lab4_rest/middlewares"
)

//
//type LocationType int
//
//const (
//	Forest  LocationType = 0
//	Desert  LocationType = 1
//	Dungeon LocationType = 2
//	River   LocationType = 3
//	Ocean   LocationType = 4
//)
//
//func (locationType LocationType) String() string {
//	names := [...]string{
//		"Forest",
//		"Desert",
//		"Dungeon",
//		"River",
//		"Ocean"}
//	return names[locationType]
//}
//
//type PlayerClass int
//
//const (
//	Knight  PlayerClass = 0
//	Wizard  PlayerClass = 1
//	Thief   PlayerClass = 2
//	Paladin PlayerClass = 3
//)
//
//func (playerClass PlayerClass) String() string {
//	names := [...]string{
//		"Knight",
//		"Wizard",
//		"Thief",
//		"Paladin"}
//	return names[playerClass]
//}
//
//type Location struct {
//	LocationId   string       `json:"location_id"`
//	Description  string       `json:"description"`
//	LocationType LocationType `json:"locationType"`
//}
//
//type Player struct {
//	ID          int         `json:"id"`
//	Name        string      `json:"name"`
//	PlayerClass PlayerClass `json:"player_class"`
//	Email       string      `json:"email"`
//	Level       int         `json:"level"`
//	Position    int         `json:"position"`
//}
//
//type Message struct {
//	MessageId   int     `json:"message_id"`
//	PlayerFrom  *Player `json:"player_from"`
//	PlayerTo    *Player `json:"player_to"`
//	MessageText string  `json:"message_text"`
//}
//
//var players []Player
//var messages []Message
//var locations []Location

func main() {
	r := mux.NewRouter()

	//locations
	r.HandleFunc("/locations", controllers.GetLocations).Methods("GET")
	r.HandleFunc("/locations/{id}", controllers.GetLocation).Methods("GET")
	r.HandleFunc("/locations", controllers.CreateLocation).Methods("POST")
	r.HandleFunc("/locations/{id}", controllers.UpdateLocation).Methods("PUT")
	r.HandleFunc("/locations/{id}", controllers.DeleteLocation).Methods("DELETE")

	//players
	r.HandleFunc("/players", controllers.GetPlayers).Methods("GET")
	r.HandleFunc("/players/{id}", controllers.GetPlayer).Methods("GET")
	r.HandleFunc("/players", controllers.CreatePlayer).Methods("POST")
	r.HandleFunc("/players/{id}", controllers.UpdatePlayer).Methods("PUT")
	r.HandleFunc("/players/{id}", controllers.DeletePlayer).Methods("DELETE")

	//messages
	r.HandleFunc("/messages", controllers.GetMessages).Methods("GET")
	r.HandleFunc("/messages/{id}", controllers.GetMessage).Methods("GET")
	r.HandleFunc("/messages", controllers.CreateMessage).Methods("POST")
	r.HandleFunc("/messages/{id}", controllers.UpdateMessage).Methods("PUT")
	r.HandleFunc("/messages/{id}", controllers.DeleteMessage).Methods("DELETE")

	//users
	r.HandleFunc("/users/new", controllers.CreateUser).Methods("POST")
	r.HandleFunc("/users/login", controllers.Authenticate).Methods("POST")

	r.Use(middlewares.JwtAuthentication)

	_ = http.ListenAndServe(":8000", handlers.LoggingHandler(os.Stdout, r))

}