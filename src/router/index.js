import Vue from 'vue'
import store from '../store/index'
import Profile from '../Profile.vue'
import signin from '../signin.vue'
import signup from '../signup.vue'

import Router from 'vue-router'
import axios from 'axios'


Vue.use(Router)

const router = new Router({
  mode : 'history',
  routes : [
    {
      path : '/',
      redirect: {
        name : 'signup'
      }
    },
    {
      path : '/profile',
      name : 'profile',
      component:Profile,
      beforeEnter : (to,from,next) =>{
        if(!(store.state.session_id))
          next({
            path: '/signin'
          })
        next()
      }
    },
    {
      path : '/signin',
      name : 'signin',
      component:signin
    },
    {
      path : '/signup',
      name : 'signup',
      component:signup
    }
  ]
})
router.beforeEach((to,from, next) =>{
  axios.get('/session')
    .then(response=>{
      store.commit('login', response.data)
      next({
        path : '/profile'
      })
    })
    .catch((error)=> {
      if (store.state.session_id)
        store.commit('logout')
    })
  if(store.state.session_id && to.path!=='/profile') {
    next({
      path: '/profile'
    })
  }
  next()
})
export default router
