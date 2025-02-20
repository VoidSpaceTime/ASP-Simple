<template>
  <div class="grid w-full h-full">
    <HomeHeard />
    <!-- <Home /> -->
    <!-- <UserCenter /> -->
    <RouterView></RouterView>
  </div>

</template>

<script setup lang="ts">
import { reactive, ref } from 'vue';
import Login from './components/Login.vue';
import Home from './components/Home.vue';
import HomeHeard from './components/HomeHeard.vue';
import UserCenter from './components/UserCenter.vue';


let search = ref('');

</script>
