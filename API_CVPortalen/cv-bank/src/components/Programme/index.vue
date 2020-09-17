<template>
  <section>
    <b-field position="is-centered">
      <b-input placeholder="Search..." type="search" icon="magnify">
      </b-input>

      <p class="control">
        <button class="button is-info">Search</button>
      </p>
    </b-field>
    <ProgrammeTable></ProgrammeTable>
  </section>

</template>

<script>
import ProgrammeTable from "@/components/Programme/parts/ProgrammeTable";
export default {
  name: "ProgrammeIndex",
  components: {ProgrammeTable}
}
</script>

<style scoped>

</style>