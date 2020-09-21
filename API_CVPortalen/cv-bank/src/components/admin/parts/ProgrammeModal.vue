<template>
  <section v-if="selectedOne != null">
    <b-modal v-model="show" :width="640" scroll="keep">
      <div class="card">
      <div class="card-header" role="button">
        <p class="card-header-title">
          <template v-if="selectedOne != null">{{selectedOne.name}}</template>
        </p>
      </div>
      <div class="card-content">
        <div class="content">
          <template v-if="selectedOne != null">
            <Programme v-bind:programme="selectedOne" is-edit=true></Programme>
          </template>
        </div>
      </div>
      </div>
    </b-modal>
  </section>
</template>

<script>
import Programme from "@/components/Programme/Programme";
export default {
  components:{Programme},
  props:{selectedOne:Object, modalActive:Boolean},
  data() {
    return {
      show: this.modalActive
    }
  },
  methods:{
    showModal(){
      this.show = true
    },
  }
}
</script>