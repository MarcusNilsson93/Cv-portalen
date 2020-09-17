<template>
  <section>
    <b-modal v-model="showModal">
      <p class="image is-4by3">
        <img src="/static/img/placeholder-1280x960.png">
      </p>
    </b-modal>
      
  </section>
</template>

<script>
export default {
  props: {
    mContent: {},
    showModal: Boolean,
  },
  data() {
    return {
    }
  }
}
</script>