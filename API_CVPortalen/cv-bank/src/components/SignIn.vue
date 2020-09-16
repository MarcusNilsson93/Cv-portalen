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
                <b-input type="password" v-model="password" required value="" password-reveal></b-input>
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
import authAction from "@/components/Actions/handlers/Account"
export default {
  name: "SignIn",
  data() {
    return {
      input: "",
      password: ""
    };
  },
  methods: {
    signIn(){
      authAction("login", this.onLoginSuccess, {"Email":this.input,
       "password":this.password} )
    },
    onLoginSuccess(){
      //if the login sucseeds you will be directed to your profile page
      window.location.replace("/profile")
    },
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