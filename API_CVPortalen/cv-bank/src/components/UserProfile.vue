<template>
  <div>
    <h1 id="headline"></h1>
    <div id="section" class="m-t-12">
      <div class="columns is-centered">
        <div class="column is-6">
          <div class="box">
            <div class="container">
              <UserCard v-if="!loading" v-bind:user="user"></UserCard>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import {getCurrentUser} from "@/Helpers/UserHandler"
import {get, loggedIn} from "@/components/Actions/Api";
import UserCard from "@/components/UserCard";

export default {
  name: "UserProfile",
  components: {UserCard},
  created() {
    this.getUserData()
  },
  data() {
    return {
      user: {},
      loading: true
    };
  },
  methods: {
    async getUserData() {
      let loggedin = await loggedIn("loggedIn")
      console.log("loggedin: " + loggedin)
      if (loggedin){
        let userdata = getCurrentUser()
        if (userdata){
          console.log(userdata)
          this.user = userdata
          this.user.programme = await this.getProgrammeName(this.user.programmeId)
        }
        else{
          console.log("No user")
        }
      }
      this.loading =false
    },
    async getProgrammeName(id){
      let programme = (await get("programme/" + id)).data
      if (programme.name)
        return programme.name
      return "Error / none"
    }
  }
};
</script>

<style scoped>

</style>