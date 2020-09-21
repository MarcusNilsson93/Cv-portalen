<template>
  <section>
    <b-tabs v-model="activeTab">
      <b-tab-item label="Default"></b-tab-item>
      <b-tab-item label="Programmes"><AdminProgrammesRoot></AdminProgrammesRoot></b-tab-item>
    </b-tabs>
  </section>

</template>

<script>
import AdminProgrammesRoot from "@/components/admin/parts/AdminProgrammesRoot";
export default {
  name: "AdminDashboard",
  components: {AdminProgrammesRoot},
  data(){
    return{
      activeTab: 0
    }
  },
  methods: {}
}
</script>

<style scoped>

</style>