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
                <b-input type="button" value="Logga in" @click.native="login"></b-input>
              </b-field>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import authAction from "@/components/Actions/handlers/Account";
export default {
  name: "SignIn",
  data() {
    return {
      input: "",
      fullEmail: "",
      password: ""
    };
  },
  methods: {
        checkForValidEmail() {
          const isValid= /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
            //this.fullEmail = this.input + '@iths.se'
          return isValid.test(this.input);
        },
    async login(){
          /*
          * Använder min gamla api controller från tidigare projekt. 
          * https://github.com/chipet94/web.net.labb4/tree/master/web.net.labb4/ClientApp/src/components/Actions
          * 
          * Sparar userData under localStorage["userData"]
          * */
          if (this.checkForValidEmail()){
            await authAction("login", this.onSuccess, {email: this.input, password: this.password})
          }
    },
    onSuccess(){
          let userdata = JSON.parse(localStorage["userData"])  // exempel
          console.log(userdata)
          alert("Success! Token: "+ userdata.token)
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