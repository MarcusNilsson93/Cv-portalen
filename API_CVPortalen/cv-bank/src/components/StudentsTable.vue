<template>
  <section>
    <b-table
        :data="isEmpty ? [] : data"
        :hoverable="isHoverable"
        :loading="isLoading"
        :mobile-cards="hasMobileCards"
    >
      <b-table-column field="name" label="Name" v-slot="props">
        {{ props.row.firstName + " " + props.row.lastName }}
      </b-table-column>
      <b-table-column field="email" label="Email" v-slot="props">
        {{ props.row.email }}
      </b-table-column>
      
    </b-table>
  </section>
</template>

<script>

export default {
  name: "StudentsTable",
  props:{getUsers:Function},
  data() {
    const data = []
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
    this.getStudents()
  },
  methods:{
    async getStudents(){
      this.data = await this.getUsers()
      this.isLoading = false;
    }
  }
}
</script>

<style scoped>

</style>