<template>
<div id="profile">
<h1>Профиль</h1>
    <div class="profile_form">
    <div class="image">
        <img src="../src/assets/image.jpg">
    </div>
    <div class="profile_info">
        <ul class="profile_data">
            <li>
                <span class="profile_categories">Имя</span>
                <input type="text" id="name" class="profile_info_text" v-model="name">
            </li>
            <li>
                <span class="profile_categories">Пароль</span>
                <input type="password" id="password" class="profile_info_text" v-model="password">
            </li>
            <li>
                <span class="profile_categories">Телефон</span>
                <input type="text" id ="phone" class="profile_info_text" v-model="phone">
            </li>
            <li>
                <span class="profile_categories">E-mail</span>
                <input type="text" id = "email"  class="profile_info_text" v-model="email">
            </li>
        </ul>
        <button v-on:click="logout()">Выйти</button>
        </div>
    </div>
</div>
</template>

<script>
import axios from 'axios'
export default {
    name : 'profile',
    data() {
      return{
        name : '',
        password : '',
        phone : '',
        email : ''
      }
    },
    methods : {
      logout(){
        axios.get('/signout').then((response) =>{
          this.$store.commit('logout')
          this.$router.push('/signin')
        })
      }
    },
    created() {
      axios.get('/user').then(response => {
          this.name = response.data.name
          this.password = response.data.password
          this.phone = response.data.phone
          this.email = response.data.email
      })
        .catch(()=>{
        this.$router.push('signup')
        })
    }
}
</script>

<style scoped>
        *{
            box-sizing: border-box;
        }
        h1{
            color: white;
            background-color: #CD5555;
            padding: 15px;
            display: inline-block;
            margin-left: -40px;
            margin-top: -40px;
        }
        .image{
            width: 140px;
            height: 250px;
            margin-right: 20px;
            display: inline-block;
            /*margin-left: 50px;*/
            float: left;
        }
        .image img{
            max-width: 100%;
            margin-bottom: 30px;
        }
        .profile_info{
            display: inline-block;
            overflow: visible;
        }
        ul{
            list-style: none;
        }
        .profile_data span,.profile_data div{
            display: inline-block;

        }
        .profile_data .profile_categories{
            padding: 5px;
            background-color: #CD5555;
            border-left: 2px solid #8B3A3A;
            margin-right: 10px;
            margin-bottom: 20px;
        }
        .profile_data .profile_info_text{
            color: white;
            background: none;
            border: 0;
            font-size: 22px;
            padding: 5px 10px;
        }
        button{
            background:#CD5555;
            color: white;
            font-size: 14px;
            border: 0;
            padding : 15px;
        }
        .profile_data .error{
            display: block;
            color: #EE2C2C;
        }
</style>
