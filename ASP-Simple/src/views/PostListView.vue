<template>

    <div class="grid grid-cols-5 gap-8 w-10/12 justify-self-center">

        <div v-for="post in PostCardList" :key="post.Id">
            <PostCard :post="post" class=" w-full" />
        </div>
    </div>
</template>

<script setup lang="ts">
import type IPostCard from '@/interface/IPostCard.ts';
import { reactive } from 'vue';
import PostCard from '@/components/PostCard.vue';

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
</script>