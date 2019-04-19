import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    vaults: [],
    keeps: [],
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultKeeps(state, vaultKeeps){
      state.vaultKeeps = vaultKeeps
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      debugger
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[Registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login failed')
          alert("Incorrect email or password.")
        })
    },
    logout({ commit, dispatch }, creds) {
      auth.delete('logout', creds)
        .then(res => {
          commit('setUser', {})
          router.push({ name: 'login' })
        })
        .catch(e => {
          console.log('Logout failed')
        })
    },
    getKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    getVaultKeeps({ commit, dispatch }) {
      api.get('vaultKeeps')
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
    },
    addKeep({ commit, dispatch }, data) {
      api.post('Keeps', data)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    addVaultKeep({ commit, dispatch }, data) {
      api.post('VaultKeeps', data)
        .then(res => {
          dispatch('getVaultKeeps')
        })
    },
    deleteKeep({ commit, dispatch }, keep) {
      api.delete(`Keeps/${keep.id}`, keep)
      .then(res => {
        dispatch('getKeeps')
        })
    },
    addKeepCount({ commit, dispatch }, keep) {
      api.put(`keeps/${keep.id}`, keep)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    addKeepShare({ commit, dispatch }, keep ) {
      api.put(`keeps/${keep.id}`, keep)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    addKeepView({ commit, dispatch }, keep) {
      api.put(`keeps/${keep.id}`, keep)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    getVaults({ commit, dispatch }) {
      api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    addVault({ commit, dispatch }, data) {
      api.post('vaults', data)
        .then(res => {
          dispatch('getVaults')
        })
    },
    deleteVault({ commit, dispatch }, vault) {
      api.delete(`Vaults/${vault.id}`, vault)
      .then(res => {
        dispatch('getVaults')
        })
    },
  }
})