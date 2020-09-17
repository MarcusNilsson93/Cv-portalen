<template>
  <Programme v-if="!Loading" v-bind:programme="programme"></Programme>
</template>

<script>
import Programme from "@/components/Programme/Programme";
import {get} from "@/components/Actions/Api";
export default {
  name: "ProgrammeProfile",
  props: {id:Number},
  components:{Programme}
  ,
  data(){
    return{
      Loading: true,
      programme: {}
    }
  },
  mounted() {
    this.loadProgramme()
  },
  methods:{
    async loadProgramme(){
      this.programme =  await get("programme/" + this.$route.params.id).then(res => res.json())
      this.Loading = false
    }
  }
}
</script>

<style scoped>

</style>