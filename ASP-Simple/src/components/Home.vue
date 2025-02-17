<template>

    <head>
        123123123131
        <title>首页</title>
    </head>


    <div class="grid justify-center gap-4 ">
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
                <RouterLink :to="{ path: '/login' }">登录</RouterLink>
                <!-- <el-button type="primary" size="default" @click="">登录</el-button> -->
                <RouterLink :to="{ path: '/' }">个人中心</RouterLink>
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
        <RouterView />
        <div class="grid grid-cols-4 gap-10 w-10/12 justify-self-center">

            <div v-for="post in PostCardList" :key="post.Id">
                <PostCard :post="post" class=" w-full" />

            </div>
        </div>
    </div>

</template>

<script setup lang="ts" name="Home">
import PostCard from '@/components/PostCard.vue';
import type IPostCard from '@/interface/IPostCard.ts';
import Login from '@/views/Login.vue';
import { ref, reactive } from 'vue';

let search = ref('');
let PostCardList = reactive<IPostCard[]>([
    {
        Id: "122131231",
        PostName: '测试1',
        PostUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
        UserName: '测试用户1',
        UserUrl: 'https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg',
        ImgUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
    },
    {
        Id: "122131232",
        PostName: '测试2',
        PostUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
        UserName: '测试用户2',
        UserUrl: 'https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg',
        ImgUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
    },
    {
        Id: "122131233",
        PostName: '测试3',
        PostUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
        UserName: '测试用户3',
        UserUrl: 'https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg',
        ImgUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
    },
    {
        Id: "122131234",
        PostName: '测试4',
        PostUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
        UserName: '测试用户3',
        UserUrl: 'https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg',
        ImgUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
    },
    {
        Id: "122131235",
        PostName: '测试5',
        PostUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
        UserName: '测试用户3',
        UserUrl: 'https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg',
        ImgUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
    },
    {
        Id: "122131236",
        PostName: '测试6',
        PostUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
        UserName: '测试用户3',
        UserUrl: 'https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg',
        ImgUrl: "https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg",
    },
]);

function showLogin()
{
   
}
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