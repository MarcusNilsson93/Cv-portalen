<template>
  <div>
    <h2>{{programme.name}}</h2>
    <section v-if="edit">
      <b-field label="Name">
        <b-input type="text" v-model="programme.name">{{programme.name}}</b-input> 
      </b-field>
      <b-field label="Category">
        <b-select placeholder="category" v-model="programme.category">
          <option  v-for="category in categories" v-bind:value="{ id: category.programmeCategoryId, name: category.name }"
                   v-bind:key="`category-${category.programmeCategoryId}`">
            {{category.name}}
          </option>
        </b-select>
      </b-field>
      <b-field label="Start">
        <b-input type="date" v-model="programme.start">{{Date.parse(programme.start)}}</b-input>
      </b-field>
      <b-field label="End">
        <b-input type="date" v-model="programme.end">{{Date.parse(programme.end)}}</b-input>
      </b-field>
      <button class="button is-success">Save</button>
    </section>
    <StudentsTable v-bind:get-users="GetStudents"></StudentsTable>
  </div>
</template>

<script>
import StudentsTable from "@/components/StudentsTable";
import {get} from "@/components/Actions/Api";
export default {
  name: "Programme",
  components: {StudentsTable},
  props: {programme: {}, IsEdit: Boolean},
  data() {
    return{
      edit: this.IsEdit,
      categories: []
    }
  },
  mounted() {
    this.GetCategories()
  },
  methods:{
    async GetStudents(){
      return await get("programme/" + this.programme.id+"/students").then(res => res.json())
    },
    async GetCategories(){
      this.categories = await get("programme/category").then(res => res.json())
    }
  }
}
</script>

<style scoped>

</style>