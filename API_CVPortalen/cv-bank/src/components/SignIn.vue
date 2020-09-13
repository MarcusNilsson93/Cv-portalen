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
                <b-input type="password" required value="" password-reveal></b-input>
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
    signIn(){
                            //Sökväg till userlistan
      Vue.axios.get('http://site.com/api/user/id')
      .then((resp)=>{
        console.log(resp.data.data)
      })
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