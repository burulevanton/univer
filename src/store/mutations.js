const mutations = {
  login : (state, data) => {
    sessionStorage.setItem('session_id',data)
    state.session_id = data
  },
  logout : (state) =>{
    sessionStorage.removeItem('session_id')
    state.session_id = null
  }
}

export default mutations
