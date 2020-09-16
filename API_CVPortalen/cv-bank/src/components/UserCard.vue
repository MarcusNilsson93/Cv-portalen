<template >
  <div>
  <div class="card-header" role="button">
    <p class="card-header-title">
      <template v-if="!loading">Profile</template>
      <b-skeleton size="is-large" :active="loading"></b-skeleton>
    </p>
  </div>
  <div class="card-content">
    <div class="content">
      <template v-if="!loading">
        <b-field label="Förnamn">
          {{user.firstName}}
        </b-field>
        <b-field label="Efternamn">
          {{user.lastName}}
        </b-field>
        <b-field label="Email">
          {{user.email}}
        </b-field>
        <b-field label="Utbildning">
          {{user.programme}}
        </b-field>
      </template>
      <b-skeleton size="is-large" :active="loading" :count="2"></b-skeleton>
    </div>
  </div>
    <span>(just placeholders)</span>
  <footer class="card-footer">
    <a class="card-footer-item">
      <template v-if="!loading">Save</template>
      <b-skeleton size="is-large" :active="loading"></b-skeleton>
    </a>
    <a class="card-footer-item">
      <template v-if="!loading">Edit</template>
      <b-skeleton size="is-large" :active="loading"></b-skeleton>
    </a>
    <a class="card-footer-item">
      <template v-if="!loading">Delete</template>
      <b-skeleton size="is-large" :active="loading"></b-skeleton>
    </a>
  </footer>
    </div>
</template>

<script>
export default {
  name: "UserCard",
  props: {user: Object},
  data() {
    return {
      loading: false,
    };
  },
}
</script>

<style scoped>

</style>