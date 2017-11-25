<template>
<div class="sign_in">
            <form_header :signIn="true"></form_header>
            <h1>Вход</h1>
            <div class="error error_signIn" v-show="errorMessage">
                    <span>{{errorMessage}}</span>
            </div>
            <div class="field_wrap">
                <input name = "name" class="input" required autocomplete="off" placeholder="Имя пользователя" type="text" v-model="name"/>
            </div>

            <div class="field_wrap">
                <input name = "password" class="input" v-bind:class="{invalid : !isPasswordValid}" required autocomplete="off" type="password" placeholder="Пароль" v-model="password">
                <div class="error" v-show="password && !isPasswordValid">
                    <span>Пароль должен содержать 8-16 символов</span>
                </div>
            </div>
            <button :disabled="!isNameValid && !isPasswordValid" v-on:click="post_data()">Войти</button>
</div>
</template>

<script>
import {nameValidate, passwordValidate} from './validate.js'
import form_header from './form_header.vue'
import axios from 'axios'

export default {
  name: 'sign-in',
  data () {
    return {
      name : '',
      password : '',
      errorMessage : ''
    }
  },
  computed: {
    isNameValid(){
          return nameValidate(this.name);
        },
    isPasswordValid(){
          return passwordValidate(this.password);
      }
    },
  components : {
    form_header
  },
  methods : {
    post_data(){
      axios.post('/signin',{
        name : this.name,
        password : this.password
      }).then(response=> {
        this.errorMessage = ''
        this.$store.commit('login',response.data)
        this.$router.push('/profile')
      })
        .catch(() => {
          this.errorMessage = 'Данные введены неверно'
        })
    }
  }
}
</script>

<style scoped src="./assets/auth_form.css">

</style>
