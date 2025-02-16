<template>

    <head>
        123123123131
        <title>首页</title>
    </head>

    <body class="body">

        <div class="headerLayout">
            <div class="headerBar ">
                <div class="leftBar">
                    <RouterLink :to="{ path: '/' }">首页</RouterLink>
                    <RouterLink :to="{ path: '/' }">导航</RouterLink>
                    <RouterLink :to="{ path: '/' }">导航</RouterLink>
                </div>
                <div class="center">
                    <el-input v-model="search" placeholder="" clearable class="searchInput" />
                    <!-- <<el-button type="info" size="default" @click="" class="searchBtn"></el-button> -->
                </div>
                <div class="rightBar">
                    <RouterLink :to="{ path: '/' }">动态</RouterLink>
                    <RouterLink :to="{ path: '/' }">历史</RouterLink>
                    <RouterLink :to="{ path: '/' }">收藏</RouterLink>
                </div>
            </div>
            <div class="navigation ">
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
            <div v-for="post in PostCardList" :key="post.indexOf">
                <!-- <PostCard /> -->
               
            </div>
        </div>
    </body>
</template>

<script setup lang="ts" name="Home">
import PostCard from '@/views/PostCard.vue';
import { ref } from 'vue';

let search = ref('');
let PostCardList:string[] = ["1","2"]
</script>

<style scoped>
.searchInput {
    width: auto;
    margin: 0 auto;
}
.headerLayout {
    display: grid;
    /* grid-template-columns: 1fr; */
    grid-template-rows: 40px 80px;
    /* grid-auto-flow:unset; */
    /* grid-auto-flow: row; */
    /* gap: 5px; */
    /* border-bottom: 1px solid #ebebeb; */

}
.headerBar {
    position: relative;
    display: grid;
    width: 100%;
    background-color: #ffffff;
    /* border-bottom: 1px solid #ebebeb; */
    grid-template-columns: auto auto auto;
    justify-content: space-between;
    align-content: center;

}

.navigation {
    position: relative;
    /* top: 1rem; */
    /* align-items: center; */
    /* grid-template-columns: 1fr auto 1fr; */
    display: grid;
    /* grid-template-columns: repeat(auto);
     */
    grid-template-columns: repeat(auto-fill,1fr);
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
    grid-auto-flow:column;


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
}</style>