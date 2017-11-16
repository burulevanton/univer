<template>
<div id="app">
    <div id="login_block">
        <input id="tabInput" type="radio" name="tab" class="sign-up" @click="showForm(1)" checked>
        <label for="tabInput" class="tab" @click="showForm(1)" v-bind:class="{active : showSignUp}" >Регистрация</label>

        <input id="tabRegistration" type="radio" name="tab" class="sign-in">
        <label for="tabRegistration" class="tab" @click="showForm(2)" v-bind:class="{active : showSignIn}">Вход</label>

        <div class="sign_up" v-show="showSignUp">
            <h1>Регистрация</h1>
            <form class="test-form">
                <div class="top-row">
                    <div class="field_wrap">
                        <input v-bind:class="{invalid : !isNameValid}" class="input" required autocomplete="off" placeholder="Имя пользователя" type="text" v-on:focus="nameOnFocus=true" v-model="name"/>
                        <div class="error" v-show="!isNameValid">
                            <span>Поле не должно быть пустым</span>
                        </div>
                    </div>

                    <div class="field_wrap">
                        <input v-bind:class="{invalid : !isPasswordValid}" class="input"  required autocomplete="off" type="password" placeholder="Пароль" v-model="password">
                        <div class="error" v-show="password && !isPasswordValid">
                            <span>Пароль должен содержать 8-16 символов</span>
                        </div>
                    </div>
                </div>
                <div class="field_wrap">
                    <input class="input" v-bind:class="{invalid : !isPhoneValid}" required autocomplete="off" type="text" placeholder="Телефон" v-model="phone">
                    <div class="error" v-show="phone && !isPhoneValid">
                        <span>Неправильный номер телефона</span>
                    </div>
                </div>

                <div class="field_wrap">
                    <input class="input" v-bind:class="{invalid : !isEmailValid}" type="email" placeholder="e-mail" required autocomplete="off" v-model="email"/>
                    <div class = "error" v-show="email && !isEmailValid">
                        <span>Неправильный email</span>
                    </div>
                </div>

                <button :disabled="!isEmailValid || !isPhoneValid || !isPasswordValid">Зарегестрироваться</button>
            </form>
        </div>
        <div class="sign_in" v-show="showSignIn">
            <h1>Вход</h1>
            <div class="field_wrap">
                <input class="input" required autocomplete="off" placeholder="Имя пользователя" type="text" v-model="name"/>
            </div>

            <div class="field_wrap">
                <input class="input" v-bind:class="{invalid : !isPasswordValid}" required autocomplete="off" type="password" placeholder="Пароль" v-model="password">
                <div class="error" v-show="password && !isPasswordValid">
                    <span>Пароль должен содержать 8-16 символов</span>
                </div>
            </div>

            <button>Войти</button>
        </div>
    </div>

</div>
</template>

<script>
import {nameValidate, emailValidate, phoneValidate, passwordValidate} from './validate.js'

export default {
  name: 'app',
  data () {
    return {
      name : '',
      nameOnFocus : false,
      email : '',
      phone : '',
      password : '',
      showSignUp : true,
      showSignIn : false
    }
  },
  computed: {
    isNameValid(){
          return !this.nameOnFocus || nameValidate(this.name);
        },
    isEmailValid() {
          return emailValidate(this.email);
      },
    isPhoneValid(){
          return phoneValidate(this.phone);
      },
    isPasswordValid(){
          return passwordValidate(this.password);
      }
  },
  methods:{
        showForm(num){
            switch(num){
                case 1:
                    this.showSignUp = true;
                    this.showSignIn = false;
                    break;
                case 2:
                    this.showSignUp = false;
                    this.showSignIn = true;
                    break;
            }
        }
  }
}
</script>

<style scoped>
body{
    margin: 0;
}
*{
    box-sizing: border-box;
}
/*#app{*/
    /*width:100%;*/
    /*margin:auto;*/
    /*max-width:525px;*/
    /*min-height:670px;*/
    /*position:relative;*/
/*}*/

#login_block{
    background: rgba(19, 35, 47, 0.9);
    padding: 40px;
    max-width: 600px;
    margin: 40px auto;
    border-radius: 4px;
    box-shadow: 0 4px 10px 4px rgba(19, 35, 47, 0.3);
}

.sign_up, .sign_in{
    margin-top : 60px;
    position:relative;
}
.sign_up{
    min-height:345px;
}

button{
    display: block;
    margin: auto;
    border:none;
    padding:15px;
    border:0;
    background:#CD5555;
    width: 60%;
    color: white;
    font-size: 14px;
}
button:disabled{
    opacity: 0.3;
}

.field_wrap{
    margin-bottom:40px;
}

.top-row .field_wrap{
    float: left;
    width: 48%;
    margin-right: 4%;
}
.top-row .field_wrap:last-child{
    margin: 0;
}

.field_wrap label,
.field_wrap input,
.field_wrap button{
    width: 100%;
    display: block;
}

.field_wrap input{
    font-size: 22px;
    display: block;
    width: 100%;
    height: 100%;
    padding: 5px 10px;
    background: none;
    border: 1px solid #a0b3b0;
    color: #ffffff;
    border-radius: 0;
    -webkit-transition: border-color .25s ease, box-shadow .25s ease;
    transition: border-color .25s ease, box-shadow .25s ease;
}
.field_wrap input:focus,
.field_wrap input:hover{
    border-color: #008B45;
    outline: 0;
}
.field_wrap input.invalid:focus,
.field_wrap input.invalid:hover{
    border-color: #FF3030;
    outline: 0;

}
input[type='radio']{
    display: none;
}
.tab{
    display: block;
    text-decoration: none;
    padding: 15px;
    background: rgba(160, 179, 176, 0.25);
    color: #a0b3b0;
    font-size: 20px;
    float: left;
    width: 50%;
    text-align: center;
    cursor: pointer;
    -webkit-transition: .5s ease;
    transition: .5s ease;
}
.tab:hover{
    background: #EE6363;
    color: #ffffff;
}
.active{
    background: #CD5555;
    color: #ffffff;
}
h1{
    color: white;
    text-align: center;
}
.error{
    color: #EE2C2C;
}
/*.field_wrap label{*/
    /*font-size: 12px;*/
    /*text-transform: uppercase;*/
    /*color: #aaa;*/
    /*position: absolute;*/
/*}*/
</style>
