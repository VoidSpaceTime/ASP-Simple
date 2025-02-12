<template>
  <Login />
</template>

<script setup lang="ts">
import { reactive, ref } from 'vue';
import Login from './components/Login.vue';


</script>

<style scoped>
.login-container {
  max-width: 300px;
  margin: 0 auto;
  padding: 2rem;
  border: 1px solid #ccc;
  border-radius: 8px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  
}

h1 {
  text-align: center;
}

.form-group {
  margin-bottom: 1rem;
}
</style>