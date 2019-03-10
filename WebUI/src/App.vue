<template>
  <div id="app">
    <ProbablisticApproach/>
  </div>
</template>

<script>
import ProbablisticApproach from "./components/ProbablisticApproach.vue";

export default {
  name: "app",
  components: {
    ProbablisticApproach
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
