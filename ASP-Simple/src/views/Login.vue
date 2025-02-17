<template>
    <teleport to="body"  v-show="isShow">
        <div class=" absolute left-0 top-0 bg-black/40 w-screen h-screen justify-center grid">
            <div class="grid  h-60 w-96  gap-4 bg-white m-1">
                <el-h1>Login</el-h1>
                <el-button class=" relative right-0" type="text" size="small" @click="show">X</el-button>
                
                <el-form class="m-5 space-y-2">
                    <el-label>账号</el-label>
                    <el-input class="User" v-model="user"> </el-input>
                    <el-label>密码</el-label>
                    <el-input class="Password" show-password v-model="psw"> </el-input>
                    <el-button type="primary" @Click="login">登录</el-button>
                    <el-button>注册</el-button>
                </el-form>
            </div>
        </div>
    </teleport>

</template>

<script setup lang="ts">
import axios from 'axios';
import { el } from 'element-plus/lib/locale/index.js';
import { ref } from 'vue';
let user = ref('');
let psw = ref('');
let isShow =ref(false);
function show ()
{
    isShow.value = false
}
// defineProps(["isShow"])

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
