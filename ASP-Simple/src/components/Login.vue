<template>
    <el-div class="login-container">
        <el-h1>Login</el-h1>
        <el-form>
            <el-label>账号</el-label>
            <el-input class="User" v-model="user"> </el-input>
            <el-label>密码</el-label>
            <el-input class="Password" show-password v-model="psw"> </el-input>
            <el-button type="primary" @Click="login">登录</el-button>
            <el-button>注册</el-button>
        </el-form>
    </el-div>
</template>

<script setup lang="ts">
import axios from 'axios';
import { ref } from 'vue';
let user = ref('');
let psw = ref('');

function login() {
    axios.post('http://localhost:3000/login', {
        user: user.value,
        psw: psw.value
    }).then(res => {
        console.log(res);
    }).catch(err => {
        console.log(err);
    })
}
</script>

<style scoped>
.login-container {
    position:relative;
    max-width: 600px;
    margin: 0 auto;
    padding: 2rem;
    border: 1px solid #ccc;
    border-radius: 16px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);

}
el-h1 {
    text-align: center;
    font-size: 24px;
    margin-bottom: 200px;
}
</style>