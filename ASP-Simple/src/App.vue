<template>
  <!-- <Home /> -->
  <!-- <Login /> -->
  <div class="grid w-full h-full">
    <!-- <RouterView /> -->
    <!-- <Login /> -->
    <Home />
     <!-- <Publish/> -->
  </div>

</template>

<script setup lang="ts">
import { reactive, ref } from 'vue';
import Login from './components/Login.vue';
import Home from './components/Home.vue';
import Publish from './components/Publish.vue';


let search = ref('');

</script>
