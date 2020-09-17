<template>
  <div>
    <h2>{{programme.name}}</h2>
    <b-field label=""> </b-field>
    <StudentsTable v-bind:get-users="GetStudents"></StudentsTable>
  </div>
</template>

<script>
import StudentsTable from "@/components/StudentsTable";
import {get} from "@/components/Actions/Api";
export default {
  name: "Programme",
  components: {StudentsTable},
  props: {programme: {}},
  data() {
    return{
      
    }
  },
  mounted() {
    this.StudentsTable
  },
  methods:{
    async GetStudents(){
      return await get("programme/" + this.programme.id+"/students").then(res => res.json())
    }
  }
}
</script>

<style scoped>

</style>