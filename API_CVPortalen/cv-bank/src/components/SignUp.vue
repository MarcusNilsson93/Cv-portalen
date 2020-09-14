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

                <b-field label="Utbildning">
            <b-select placeholder="Välj din utbildning" v-model="educationId">
                <option value="Applikationsutveckling">
                    Applikationsutveckling
                </option>
                <option value="Javascript-utveckling">
                    Javascript-utveckling
                </option>
                <option value= 2>
                    .Netutveckling
                </option>
                <option value="Webutveckling-med-react">
                    Webutveckling med react
                </option>
                <option value="Molnutveckling">
                    Molnutveckling
                </option>
                <option value="Agil-testautomatiserare">
                    Agil testautomatiserare
                </option>
                <option value="UX-designer">
                    UX-designer
                </option>
                <option value="It-Projektledare">
                    It-Projektledare
                </option>
                <option value="Frontendutvecklare">
                    Frontendutvecklare
                </option>
                <option value= 3>
                    Javautvecklare
                </option>
                <option value="Mjukvarutestare">
                    Mjukvarutestare
                </option>
                <option value= 1>
                    Webutvecklare
                </option>
            </b-select>
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
      educationId: Number
    };
  },
  methods: {
    signUp(){
     Vue.axios.post("https://localhost:5001/api/user/register",
      {"email":this.input,
       "password":this.password,
       "firstName":"jdisa",
       "lastName": "sad",
       "programmeId": this.educationId})
       .then((resp)=>{
         console.log(resp)
         console.log(resp.data)
         //localStorage.setItem('userData', JSON.stringify(resp.data))
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