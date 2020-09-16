<template>
  <div id="app">
    <div id="nav">
      <router-link to="/" v-if="!loggedin">Logga in</router-link> |
      <router-link to="/sign-up" v-if="!loggedin">Registrera</router-link>
      <router-link to="/profile" v-else>Profile</router-link>
      | <button class="button is-primary">Logga ut</button>
    </div>
    <router-view/>
  </div>
</template>
<script>
import {loggedIn} from "@/components/Actions/Api"
export default {
  data(){
    return{
      loggedin: false
    }
  },
  created(){
    this.checkLogin()
  },
  methods: {
      async checkLogin(){
      this.loggedin = await loggedIn()
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
