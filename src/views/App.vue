<template>
<div id="app">
      <router-view></router-view>
</div>
</template>

<script>
import sign_in from "./signin.vue"
import sign_up from "./signup.vue"
import form_header from './form_header.vue'
import axios from 'axios'

export default {
  name: 'app',
  data () {
    return{}
  }
}
</script>

<style>
body{
    margin: 0;
}
*{
    box-sizing: border-box;
}
#app{
    background: rgba(19, 35, 47, 0.9);
    padding: 40px;
    max-width: 700px;
    margin: 40px auto;
    border-radius: 4px;
    box-shadow: 0 4px 10px 4px rgba(19, 35, 47, 0.3);
}
</style>
