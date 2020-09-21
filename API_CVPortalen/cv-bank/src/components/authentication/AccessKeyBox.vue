<template>
  <div>
    <h1 id="headline">Ange den nyckel du fått av ITHS.</h1>
    <div id="section" class="m-t-12">
      <div class="columns is-centered">
        <div class="column is-6">
          <div class="box">
            <div class="container">
              <b-field label="Access key">
                <b-input type="text" v-model="input"></b-input>
              </b-field>
              <b-field>
                <b-input type="button" value="Logga in"></b-input>
              </b-field>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "AccessKeyBox",
  data() {
    return {
      input: "",
    };
  },
  methods: {
  }

};
</script>
<style scoped>
/*Exempel css*/
#headline {
  color: red;
  font-size: 20px;
}
</style>