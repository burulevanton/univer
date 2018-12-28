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
	UserId int
	jwt.StandardClaims
}

type User struct {
	ID       int    `json:"id" db:"id"`
	Email    string `json:"email" db:"email"`
	Password string `json:"password" db:"password"`
	Type     string `json:"type" db:"type"`
	Token    string `json:"token" db:"-"`
}

// String is not required by pop and may be deleted
func (user User) String() string {
	ju, _ := json.Marshal(user)
	return string(ju)
}

// Users is not required by pop and may be deleted
type Users []User

// String is not required by pop and may be deleted
func (u Users) String() string {
	ju, _ := json.Marshal(u)
	return string(ju)
}

func (user *User) Validate() (map[string] interface{}, bool){
	if !strings.Contains(user.Email, "@"){
		return utils.Message(false, "Incorrect email"), false
	}
	if len(user.Password) < 6 {
		return utils.Message(false, "Incorrect password"), false
	}
	var temp []User
	tx, _ := pop.Connect("development")
	err := tx.Where("email = '" + user.Email + "'").All(&temp)
	if err!= nil{
		return utils.Message(false, "Connection error"), false
	}
	if temp != nil{
		return utils.Message(false, "Email is already in use by another user"), false
	}
	return utils.Message(false, "Requirement passed"), true
}

func (user *User) Create() map[string] interface{} {
	if resp, ok := user.Validate(); !ok{
		return resp
	}
	hashedPassword, _ := bcrypt.GenerateFromPassword([]byte(user.Password),bcrypt.DefaultCost)
	user.Password = string(hashedPassword)
	tx, _ := pop.Connect("development")
	_, _ = tx.ValidateAndCreate(user)
	if user.ID <= 0 {
		return utils.Message(false, "Failed to create user")
	}
	tk := &Token{UserId:user.ID}
	token := jwt.NewWithClaims(jwt.GetSigningMethod("HS256"), tk)
	tokenString, _ := token.SignedString([]byte("secret"))
	user.Token = tokenString
	user.Password = "********"
	response := utils.Message(true, "User has been created")
	response["user"] = user
	return response
}

func Login(email, password string) map[string]interface{} {
	user:=&User{}
	tx, _ := pop.Connect("development")
	err := tx.Where("email = '" + email + "'").First(user)
	if err != nil {
		return utils.Message(false, "Email address not found")
	}
	err = bcrypt.CompareHashAndPassword([]byte(user.Password), []byte(password))
	if err != nil{
		return utils.Message(false, "Invalid login or password")
	}
	user.Password = "*******"
	tk := &Token{UserId:user.ID}
	token := jwt.NewWithClaims(jwt.GetSigningMethod("HS256"), tk)
	tokenString, _ := token.SignedString([]byte("secret"))
	user.Token = tokenString

	resp := utils.Message(true, "Logged in")
	resp["user"] = user
	return resp
}