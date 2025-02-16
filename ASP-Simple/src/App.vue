<template>
  <!-- <Home /> -->
  <!-- <Login /> -->
  <div class="grid w-full h-full">
    <RouterView />
    <!-- <Login /> -->
  </div>

</template>

<script setup lang="ts">
import { reactive, ref } from 'vue';
import Login from './views/Login.vue';
import Home from './components/Home.vue';


let search = ref('');

</script>

