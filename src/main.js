import Vue from 'vue'
import Auth from './Auth.vue'
import Profile from './Profile.vue'

new Vue({
    el: '#app',
    render: h => h(Auth)
})

new Vue({
    el: '#profile',
    render: h => h(Profile)
})