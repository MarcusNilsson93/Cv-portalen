<template>
  <div>
    <h1 id="headline">Skapa ett konto med din iths mail, för att ladda upp ditt cv</h1>
    <div id="section" class="m-t-12">
      <div class="columns is-centered">
        <div class="column is-6">
          <div class="box">
            <div class="container">

                <b-field label="Förnamn">
                    <b-input required type="text" v-model="firstName"></b-input>  
                </b-field>

                <b-field label="Efternamn">
                    <b-input required type="text" v-model="lastName"></b-input>   
                </b-field>

                <b-field label="Utbildning">
                    <b-select placeholder="Välj din utbildning" v-model="selected">
                      <option  v-for="education in educations" v-bind:value="{ id: education.id, name: education.name }"
                      v-bind:key="`eductation-${education.id}`">
                        {{education.name}}
                      </option>
                    </b-select>
                </b-field>

                <b-field label="E-post">
                    <b-input type="email" required v-model="input" id="emailfield"></b-input>
                </b-field>

                <b-field label="Lösenord">
                    <b-input v-model="password" required type="password" value="" password-reveal></b-input>
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
import authAction from "@/components/Actions/handlers/Account";
import {get} from '@/components/Actions/Api'
export default {
  name: "SignUp",
  mounted(){
    this.getProgrammes()    
  },
  data() {
    return {
      selected: "",
      educations: [],
      input: "",
      firstName: "",
      lastName: "",
      password:""
    };
  },
  methods: {
     async signUp(){
       console.log('in signUp')
       console.log(this.selected.id)
      await authAction ("register", this.onRegisterSuccess, 
      {"FirstName": this.firstName,
       "LastName": this.lastName,
        "Email": this.input,
       "Password":this.password,
       "programmeId":this.selected.id} )
    },
async getProgrammes(){
    this.educations =  await get("programme").then(res => res.json())
    
},
    onRegisterSuccess(){
      //If registration is succesfull you will be directed to the signIn page
      window.location.replace("/login")
    },
  }
}
</script>
<style scoped>
/*Exempel css*/
#headline {
  color: red;
  font-size: 20px;
}
</style>