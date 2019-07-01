<template>
  <div class="wrap_for_types">
    <input id="tabInput" type="radio" name="tab" class="sign-up">
    <label for="tabInput" class="tab" @click="showSignUp()" v-bind:class="{active : signUp}" >Регистрация</label>

    <input id="tabRegistration" type="radio" name="tab" class="sign-in">
    <label for="tabRegistration" class="tab" @click="showSignIn()" v-bind:class="{active : signIn}">Вход</label>
  </div>
</template>

<script>
  export default {
    name : 'form_header',
    props : ['signUp', 'signIn'],
    data() {
      return {

      }
    },
    methods : {
      showSignUp() {
        if(this.$route.path === '/signup')
          return
        this.$router.push('/signup')
      },
      showSignIn(){
        if(this.$route.path === '/signin')
          return
        this.$router.push('/signin')
      }
    }
  }
</script>

<style scoped>
  *{
    box-sizing: border-box;
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
</style>
