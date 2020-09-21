<template>
  <div>
    <b-tabs position="is-centered" v-model="activeTab">
      <b-tab-item label="AccesKey"><AccessKeyBox></AccessKeyBox></b-tab-item>
      <b-tab-item label="Account"><SignIn></SignIn></b-tab-item>
      <b-tab-item label="Register"><sign-up></sign-up></b-tab-item>
    </b-tabs>
  </div>
</template>

<script>
import SignIn from "@/components/SignIn";
import SignUp from "@/components/SignUp";
import AccessKeyBox from "@/components/authentication/AccessKeyBox";
export default {
  name: "AuthenticationBox",
  components: {AccessKeyBox, SignUp, SignIn},
  data(){
    return{
      activeTab: 0
    }
  },
}
</script>

<style scoped>

</style>