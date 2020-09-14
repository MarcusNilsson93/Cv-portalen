<template>
  <div>
    <h1 id="headline">Logga in på ditt konto för att ladda upp ditt cv</h1>
    <div id="section" class="m-t-12">
      <div class="columns is-centered">
        <div class="column is-6">
          <div class="box">
            <div class="container">
              <b-field label="E-post">
                <b-input type="email" required v-model="input"></b-input>
              </b-field>
              <b-field label="Lösenord">
                <b-input type="password" required value="" v-model="password" password-reveal></b-input>
              </b-field>
              <b-field>
                <b-input type="button" value="Logga in" @click.native="signIn"></b-input>
              </b-field>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
//import authAction from "@/components/Actions/handlers/Account"
import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
Vue.use(VueAxios,axios)
export default {
  name: "SignIn",
  data() {
    return {
      input: "",
    };
  },
methods: {
    async signIn(){
      //await authAction("login", this.OnSuccess,  {"email":this.input, "password":this.password});
                            //Sökväg till userlistan
       Vue.axios.post("https://localhost:5001/api/user/authenticate", {"email":this.input, "password":this.password})
       .then((resp)=>{
         console.log(resp)
         console.log(resp.data)
         localStorage.setItem('userData', JSON.stringify(resp.data))
       })
    },
    OnSuccess(){

      console.log("Jag är glad")
    }
  }
  
};
</script>
<style scoped>
/*Exempel css*/
#headline {
  color: red;
  font-size: 20px;
}
</style>