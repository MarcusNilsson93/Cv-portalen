<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <p>Profile</p>
    <UserProfile></UserProfile>
  </div>
</template>

<script>
// @ is an alias to /src
import UserProfile from '@/components/UserProfile.vue'

export default {
  name: 'Profile',
  components: {
    UserProfile
  }
}
</script>