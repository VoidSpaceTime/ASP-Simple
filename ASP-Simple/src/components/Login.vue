<template>
    <div>
        <h1>Login</h1>
        <form>
            <el-form>
                <el-label>账号</el-label>
                <el-input class="User" v-model="user"> </el-input>
                <el-label>密码</el-label>
                <el-input class="Password" show-password v-model="psw"> </el-input>
                <el-button type="primary" @Click="login">登录</el-button>
                <el-button>注册</el-button>
            </el-form>
        </form>
    </div>
</template>

<script setup lang="ts">
import axios from 'axios';
import { ref } from 'vue';
// import  {Axios}  from 'axios';
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

<style scoped></style>