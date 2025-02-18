<template>

    <head>
        123123123131
        <title>首页</title>
    </head>

    <div class="grid gap-4">
        <div class="relative grid w-full grid-flow-col justify-between">
            <div class="leftBar">
                <RouterLink :to="{ path: '/' }">首页</RouterLink>
                <!-- <RouterLink :to="{ path: '/' }">导航</RouterLink>
                    <RouterLink :to="{ path: '/' }">导航</RouterLink> -->
            </div>
            <div class=" w-96">
                <el-input v-model="search" placeholder="" clearable class=" " />
                <!-- <<el-button type="info" size="default" @click="" class="searchBtn"></el-button> -->
            </div>
            <div class="grid grid-flow-col gap-x-2">
                <div @click="loginShow" class=" select-none cursor-pointer">登录</div>
                <!-- <router-link active-class="active" :to="{ path: '/login' }">登录</router-link> -->
                <!-- <el-button type="primary" size="default" @click="">登录</el-button> -->
                <RouterLink :to="{ path: '/' }">消息</RouterLink>
                <RouterLink :to="{ path: '/' }">动态</RouterLink>
                <RouterLink :to="{ path: '/' }">收藏</RouterLink>
                <RouterLink :to="{ path: '/' }">历史</RouterLink>
            </div>
        </div>
        <div class="grid grid-flow-col justify-center text-base gap-4 grid-rows-2">
            <RouterLink :to="{ path: '/' }">导航2222</RouterLink>
            <RouterLink :to="{ path: '/' }">导航2222</RouterLink>
            <RouterLink :to="{ path: '/' }">导航2222</RouterLink>
            <RouterLink :to="{ path: '/' }">导航2222</RouterLink>
            <RouterLink :to="{ path: '/' }">导航2222</RouterLink>
            <RouterLink :to="{ path: '/' }">导航2222</RouterLink>
            <RouterLink :to="{ path: '/' }">导航2222</RouterLink>
            <RouterLink :to="{ path: '/' }">导航2222</RouterLink>
            <RouterLink :to="{ path: '/' }">导航2222</RouterLink>
            <RouterLink :to="{ path: '/' }">导航2222</RouterLink>
        </div>
        <Login />
        <div>
            <RouterView />
        </div>



    </div>

</template>

<script setup lang="ts" name="Home">

import emitter from '@/unitls/mitters';
import { ref, reactive } from 'vue';
import Login from '@/components/Login.vue';

let search = ref('');
function loginShow() {
    emitter.emit('loginShow', true)
}
let menus = ["awda",'asdfadsf']
</script>

<style scoped>
.headerLayout {
    display: grid;
    /* grid-template-columns: 1fr; */
    grid-template-rows: 40px 80px;
    /* grid-auto-flow:unset; */
    /* grid-auto-flow: row; */
    /* gap: 5px; */
    /* border-bottom: 1px solid #ebebeb; */

}

.navigation {
    position: relative;
    /* top: 1rem; */
    /* align-items: center; */
    /* grid-template-columns: 1fr auto 1fr; */
    display: grid;
    /* grid-template-columns: repeat(auto);
     */
    grid-template-columns: repeat(auto-fill, 1fr);
    /* grid-template-columns: repeat(9,1fr); */
    grid-template-rows: repeat(2, 1fr);
    /* gap: 10px,10px; */
    /* gap: 5px; */
    /* width: 80%; */
    /* justify-content:space-between; */
    /* align-content:space-around; */
    /* align-content: center; */
    justify-content: center;
    align-content: center;
    justify-items: center;
    align-items: center;
    /* column-gap: 2px; */
    grid-auto-flow: column;


}
</style>
<style>
@media (max-width: 1024px) {
    html {
        width: 1024px;
        overflow-x: auto;
    }

    body {
        width: 100%;
        overflow-x: auto;
    }

    .container {
        width: 1024px;
    }
}
</style>