<template>
  <div class="login-container">
    <el-h1> 登录 </el-h1>
    <<el-form :model="form" label-width="80px" :inline="false" size="normal">

      <div class="form-group">
        <el-label for="username">用户名</el-label>
        <el-input v-model="form.username" type="text" id="username" required />

        <el-label for="password">密码</el-label>
        <el-input v-model="form.password" type="password" id="password" required />
      </div>
      <el-button type="submit">登录</el-button>
      <el-button>注册</el-button>

      </el-form>

  </div>
</template>

<script setup lang="ts">
import { reactive, ref } from 'vue';


const form = reactive({
  username: '',
  password: ''
});

const errorMessage = ref('');

const handleSubmit = () => {
  if (form.username === 'admin' && form.password === 'password') {
    alert('登录成功');
    errorMessage.value = '';
  } else {
    errorMessage.value = '用户名或密码错误';
  }
};

;
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