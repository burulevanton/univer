import Vue from 'vue'
import Vuex from 'vuex'

import mutations from './mutations'

Vue.use(Vuex)

const state = {
  session_id : sessionStorage.getItem('session_id')
}

export default new Vuex.Store({
  state,
  mutations
})


