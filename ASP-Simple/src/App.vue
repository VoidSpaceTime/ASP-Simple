<template>
  <!-- <Home /> -->
  <!-- <Login /> -->
  <div class="app">
    <div>
      <RouterView />
    </div>
  </div>

</template>

<script setup lang="ts">
import { reactive, ref } from 'vue';
import Login from './views/Login.vue';
import Home from './components/Home.vue';


let search = ref('');

</script>

<style scoped></style>

<style>
#grid-container {
  display: grid;
  /* grid-template-columns: 1fr 1fr 1fr;
  grid-gap: 10px;
  background-color: #2196F3;
  padding: 10px; */
}
</style>