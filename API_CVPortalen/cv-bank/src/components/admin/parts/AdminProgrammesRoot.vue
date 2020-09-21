<template>
  <section>
    <div>Only admins belong here.</div>
    <button @click="GetAll">GetAll</button>
    <button @click="load">loadOne</button>
    <button @click="AddOne">AddOne</button>
    <button @click="updateOne">UpdateOne</button>
    <button @click="RemoveOne">RemoveOne</button>
    <ProgrammeModal ref="programmeModalRef" v-bind:selected-one="selectedOne" v-model="selectedOne"></ProgrammeModal>
    <div v-if="selectedOne != null">
      selected:
      {{this.selectedOne}}
    </div>
    <b-table
        :data="isEmpty ? [] : programmes"
        :hoverable=true
        :loading="isLoading"
        :mobile-cards=true
        @click="handleselect"
    >
      <b-table-column field="category" label="Category" v-slot="props">
        {{ props.row.category.name }}
      </b-table-column>
      <b-table-column field="name" label="Name" v-slot="props">
        {{ props.row.name }}
      </b-table-column>

      <b-table-column field="startDate" label="Start date" v-slot="props">
        {{ new Date(props.row.start).toLocaleDateString() }}
      </b-table-column>

      <b-table-column field="endDate" label="End date" centered v-slot="props">
                <span class="tag is-success">
                    {{ new Date(props.row.end).toLocaleDateString() }}
                </span>
      </b-table-column>
      <b-table-column field="enrolled" label="Students" v-slot="props">
        {{ props.row.enrolled }}
      </b-table-column>
    </b-table>
  </section>

</template>

<script>
import {getById, getAll, Remove, Add, Update} from "@/components/Actions/handlers/ProgrammeService"
import ProgrammeModal from "@/components/admin/parts/ProgrammeModal";

export default {
  name: "AdminProgrammesRoot",
  components: {ProgrammeModal},
  data(){
    return{
      isEmpty: false,
      selectedOne: {},
      programmes: [],
      isLoading: false,
      showModal:false,
    }
  },
  methods:{
    onModalClose(){
      this.selectedOne = null;
    },
    async test(){
      console.log("test")
    },
    async GetAll(){
      let all = await getAll();
      this.programmes = all;
      console.log(all)
    },
    async load(){
      this.selectedOne = await getById(100000);
    },
    async AddOne(){
      let newOne = {name:"test", categoryId:99999, start:Date.now, end:Date.now,}
      await Add(newOne);
    },
    async updateOne(){
      this.selectedOne.name = "updatedName"
      await Update(this.selectedOne.id, this.selectedOne)
    },
    async RemoveOne(){
      await Remove(this.selectedOne.id)
      this.selectedOne = null;
    },
    handleselect(data){
      this.selectedOne = data;
      console.log(this.selectedOne)
      this.$refs.programmeModalRef.showModal()
    }
  }
}
</script>

<style scoped>

</style>