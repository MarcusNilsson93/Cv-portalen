<template>
  <div>
    <h1 id="headline">Skapa ett konto med din iths mail, för att ladda upp ditt cv</h1>
    <div id="section" class="m-t-12">
      <div class="columns is-centered">
        <div class="column is-6">
          <div class="box">
            <div class="container">

                <b-field label="Förnamn">
                    <b-input required type="text"></b-input>  
                </b-field>

                <b-field label="Efternamn">
                    <b-input required type="text"></b-input>   
                </b-field>

                <b-field label="E-post">
                    <b-input type="email" required v-model="input" id="emailfield"></b-input>
                </b-field>

                <b-field label="Lösenord">
                    <b-input required type="password" value="" password-reveal></b-input>
                </b-field>

                <b-field>
                    <b-input type="button" value="Registrera" @click.native="signUp"></b-input>
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
  name: "SignUp",
  data() {
    return {
      input: "",
    };
  },
  methods: {
    signUp(){
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