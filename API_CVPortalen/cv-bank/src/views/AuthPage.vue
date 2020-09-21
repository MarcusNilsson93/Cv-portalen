<template>
  <div class="container">
    <div class="box">
      <AuthenticationBox></AuthenticationBox>
    </div>
  </div>
</template>

<script>
import AuthenticationBox from "@/components/authentication/AuthenticationBox";
export default {
  name: "AuthPage",
  components: {AuthenticationBox}
}
</script>

<style scoped>

</style>