import Vue from 'vue'
import App from './App.vue'
import Profile from './Profile.vue'

new Vue({
    el: '#app',
    render: h => h(App)
})

new Vue({
    el: '#profile',
    render: h => h(Profile)
})