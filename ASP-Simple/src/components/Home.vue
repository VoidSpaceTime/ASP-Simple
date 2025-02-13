<template>

    <head>
        123123123131
        <title>首页</title>
    </head>

    <body class="body">

        <div class="header grid-container">
            <div class="headr-bar ">
                <div class="left-bar">
                    <RouterLink :to="{ path: '/' }">首页</RouterLink>
                    <RouterLink :to="{ path: '/' }">导航</RouterLink>
                    <RouterLink :to="{ path: '/' }">导航</RouterLink>
                </div>
                <div class="center">
                    <el-input v-model="search" placeholder="" clearable class="searchInput" />
                    <!-- <<el-button type="info" size="default" @click="" class="searchBtn"></el-button> -->
                </div>
                <div class="right-bar">
                    <RouterLink :to="{ path: '/' }">动态</RouterLink>
                    <RouterLink :to="{ path: '/' }">历史</RouterLink>
                    <RouterLink :to="{ path: '/' }">收藏</RouterLink>
                </div>
            </div>
            <div class="navigation ">
                <RouterLink :to="{ path: '/' }">首页</RouterLink>
                <RouterLink :to="{ path: '/' }">导航</RouterLink>
                <RouterLink :to="{ path: '/' }">导航</RouterLink>
            </div>
        </div>
    </body>
</template>

<script setup lang="ts" name="Home">
import { ref } from 'vue';

let search = ref('');
</script>

<style scoped>
.searchInput {
    width: 300px;
    margin: 0 auto;
}

.header {
    display: block;
    unicode-bidi: isolate;
    min-height: 64px;
    position: relative;
    margin: 0 auto;
    max-width: 2560px;
    width: 100%;
}

.headr-bar {
    position: relative;
    width: 100%;
    display: grid;
    background-color: #ffffff;
    /* border-bottom: 1px solid #ebebeb; */
    grid-template-columns: 1fr auto 1fr;
    align-items: center;
}

.right-bar {
    position: relative;
    display: flex;
    justify-content: flex-end;
    grid-column-end: -1;   
}

.navigation {
    /* position: relative; */
    /* align-items: center; */
    /* grid-template-columns: 1fr auto 1fr; */
    display: flex;
    justify-content: center;
    
}

.searchBtn {
    margin: 0 auto;
}

</style>