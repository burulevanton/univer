package models

import (
	"encoding/json"
	"github.com/dgrijalva/jwt-go"
	"github.com/gobuffalo/pop"
	"golang.org/x/crypto/bcrypt"
	"soa_lab4_rest/utils"
	"strings"
)

type Token struct {
	PlayerId int
	jwt.StandardClaims
}

type Player struct {
	ID          int    `json:"id" db:"id"`
	Name        string `json:"name" db:"name"`
	Email       string `json:"email" db:"email"`
	Password    string `json:"password" db:"password"`
	Level       int    `json:"level" db:"level"`
	Position    string `json:"position" db:"position"`
	PlayerClass string `json:"player_class" db:"player_class"`
	Token       string `json:"token" db:"-"`
}

type AlienPlayer struct {
	ID          int    `json:"id"`
	Name        string `json:"name"`
	Level       int `json:"level"`
	Position    string `json:"position"`
	PlayerClass string `json:"player_class"`
}

// String is not required by pop and may be deleted
func (player Player) String() string {
	jp, _ := json.Marshal(player)
	return string(jp)
}

// Players is not required by pop and may be deleted
type Players []Player

// String is not required by pop and may be deleted
func (p Players) String() string {
	jp, _ := json.Marshal(p)
	return string(jp)
}

func (player *Player) Validate() (map[string] interface{}, bool){
	if !strings.Contains(player.Email, "@"){
		return utils.Message(false, "Incorrect email"), false
	}
	if len(player.Password) < 6 {
		return utils.Message(false, "Incorrect password"), false
	}
	if player.Position == ""{
		return utils.Message(false, "Need to set player position"), false
	}
	if player.PlayerClass == ""{
		return utils.Message(false, "Need to set player class"), false
	}
	if player.Level == 0{
		player.Level = 1
	}
	if player.Name == ""{
		return utils.Message(false, "Need to set player name"), false
	}
	var temp []Player
	tx, _ := pop.Connect("development")
	err := tx.Where("email = '" + player.Email + "'").All(&temp)
	if err!= nil{
		return utils.Message(false, "Connection error"), false
	}
	if temp != nil{
		return utils.Message(false, "Email is already in use by another Player"), false
	}
	return utils.Message(false, "Requirement passed"), true
}

func (player *Player) Create() map[string] interface{} {
	if resp, ok := player.Validate(); !ok{
		return resp
	}
	hashedPassword, _ := bcrypt.GenerateFromPassword([]byte(player.Password),bcrypt.DefaultCost)
	player.Password = string(hashedPassword)
	tx, _ := pop.Connect("development")
	_, _ = tx.ValidateAndCreate(player)
	if player.ID <= 0 {
		return utils.Message(false, "Failed to create Player")
	}
	tk := &Token{PlayerId: player.ID}
	token := jwt.NewWithClaims(jwt.GetSigningMethod("HS256"), tk)
	tokenString, _ := token.SignedString([]byte("secret"))
	player.Token = tokenString
	player.Password = "********"
	response := utils.Message(true, "Player has been created")
	response["Player"] = player
	return response
}

func Login(email, password string) map[string]interface{} {
	player:=&Player{}
	tx, _ := pop.Connect("development")
	err := tx.Where("email = '" + email + "'").First(player)
	if err != nil {
		return utils.Message(false, "Email address not found")
	}
	err = bcrypt.CompareHashAndPassword([]byte(player.Password), []byte(password))
	if err != nil{
		return utils.Message(false, "Invalid login or password")
	}
	player.Password = "*******"
	tk := &Token{PlayerId:player.ID}
	token := jwt.NewWithClaims(jwt.GetSigningMethod("HS256"), tk)
	tokenString, _ := token.SignedString([]byte("secret"))
	player.Token = tokenString

	resp := utils.Message(true, "Logged in")
	resp["Player"] = player
	return resp
}

func (player *Player) PlayerToAlienPlayer() AlienPlayer{
	alienPlayer := AlienPlayer{}
	alienPlayer.ID = player.ID
	alienPlayer.PlayerClass = player.PlayerClass
	alienPlayer.Level = player.Level
	alienPlayer.Position = player.Position
	alienPlayer.Name = player.Name
	return alienPlayer
}