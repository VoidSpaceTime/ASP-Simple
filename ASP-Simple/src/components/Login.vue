<template>
    <teleport to="body">
        <div class=" absolute left-0 top-0 bg-black/30 w-screen h-screen justify-center items-center grid" v-show="isShow">
            <div class="grid  h-60 w-96  gap-4 bg-white m-1">
                <div class="grid grid-flow-col justify-between">
                    <h1>Login</h1>
                    <div class=" select-none cursor-pointer" @click="isShow = false">
                        <svg class="w-6 h-6" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1024 1024">
                            <path fill="currentColor"
                                d="M764.288 214.592 512 466.88 259.712 214.592a31.936 31.936 0 0 0-45.12 45.12L466.752 512 214.528 764.224a31.936 31.936 0 1 0 45.12 45.184L512 557.184l252.288 252.288a31.936 31.936 0 0 0 45.12-45.12L557.12 512.064l252.288-252.352a31.936 31.936 0 1 0-45.12-45.184z"
                                data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"></path>
                        </svg>
                    </div>
                </div>
                <el-form class="m-5 space-y-2">
                    <label>账号</label>
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

<script setup lang="ts" name="Login">
import axios from 'axios';
import emitter from '@/unitls/mitters';
import { el } from 'element-plus/lib/locale/index.js';
import { onUnmounted, ref } from 'vue';
let user = ref('');
let psw = ref('');
let isShow = ref(false);
// 绑定事件
emitter.on('loginShow', (value) => {
    isShow.value = true;
    console.log("12131231231");
})
// 绑定事件
emitter.on('loginHide', (value) => {
    isShow.value = false;
})
onUnmounted(() => {
    emitter.off('loginShow')
    emitter.off('loginHide')
})



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
