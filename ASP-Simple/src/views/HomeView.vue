<template>
    <HomeHeard />
    <div class="grid justify-self-center w-11/12">
        <div class="grid grid-cols-10 gap-1 my-6 w-10/12 justify-self-center">
            <el-link href="" type="default" :underline="false" size="medium">测试</el-link>
            <el-link href="" type="default" :underline="false" size="medium">测试</el-link>
            <el-link href="" type="default" :underline="false" size="medium">测试</el-link>
            <el-link href="" type="default" :underline="false" size="medium">测试</el-link>
            <el-link href="" type="default" :underline="false" size="medium">测试</el-link>
            <el-link href="" type="default" :underline="false" size="medium">测试</el-link>
            <el-link href="" type="default" :underline="false" size="medium">测试</el-link>
            <el-link href="" type="default" :underline="false" size="medium">测试</el-link>
            <el-link href="" type="default" :underline="false" size="medium">测试</el-link>
            <el-link href="" type="default" :underline="false" size="medium">测试</el-link>
        </div>
        <div>
            <ul v-infinite-scroll="load" class="grid grid-cols-5 gap-8 w-10/12 justify-self-center">
                <li v-for="(post, i) in postCardList" :key="i" class="">
                    <PostCard :post="post" class=" w-full" />
                </li>
            </ul>
        </div>
    </div>
</template>

<script setup lang="ts" name="Home">
import type IPostCard from '@/interface/IPostCard';
import PostCard from '@/components/PostCard.vue';

import { ref, reactive } from 'vue';
import HomeHeard from '@/components/HomeHeard.vue';
let postCardList = reactive<IPostCard[]>([
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
function load() {
}
</script>