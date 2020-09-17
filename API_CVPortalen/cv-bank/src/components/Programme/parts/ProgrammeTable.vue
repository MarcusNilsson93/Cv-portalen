<template>
  <section>
    <b-table
        :data="isEmpty ? [] : data"
        :hoverable="isHoverable"
        :loading="isLoading"
        :mobile-cards="hasMobileCards"
        @click="handleModal"
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
import {get} from "@/components/Actions/Api";

export default {
  name: "ProgrammeTable",
  data() {
    const data = [
    ]

    return {
      data,
      isEmpty: false,
      isLoading: true,
      isHoverable: true,
      hasMobileCards: true,
      showModal: false,
    }
  },
  mounted() {
    this.getAllProgrammes()
  },
  methods:{
    handleModal(record, index){
      console.log("clicked"+ record.id, index)
      this.$router.push("/programme/"+ record.id)
    },
    async getAllProgrammes(){
      this.data = await get("programme").then(res => res.json());
      this.isLoading = false;
    }
  }
}
</script>

<style scoped>

</style>