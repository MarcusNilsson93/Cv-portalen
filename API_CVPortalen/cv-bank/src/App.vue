<template>
  <div id="app">
    <div id="nav">
      <div v-if="!loggedin">
        <router-link to="/login">Logga in</router-link> |
        <router-link to="/sign-up">Registrera</router-link>
      </div>
      <div v-else>
        <router-link to="/profile">Profile</router-link> 
        <router-link to="/admin_dashboard" v-if="currentUser.role === 'Admin'"> | Admin Dashboard</router-link>
        <button class="button is-danger is-pulled-right"  @click="logout">Logga ut</button>
      </div>
    </div>
    <router-view/>
  </div>
</template>
<script>
import {getCurrentUser, Logout} from "@/Helpers/UserHandler"
import {loggedIn} from "@/components/Actions/Api"
export default {
  data(){
    return{
      loggedin: false,
      currentUser: {}
    }
  },
  created(){
    this.checkLogin()
  },
  methods: {
      async checkLogin(){
      this.loggedin = await loggedIn()
        this.loggedin? this.currentUser = getCurrentUser(): null;
    },
    logout(){
      Logout()
      window.location.replace("/")
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
