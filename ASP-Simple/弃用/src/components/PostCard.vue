<template>
    <section class="grid grid-cols-1 gap-1">
        <!-- 文章  -->
        <a :href="post.PostUrl">
            <el-image :src="post.ImgUrl" fit="fit" loading="lazy" aria-setsize="60px"
                class=" w-auto object-cover"></el-image>
            <div class=" text-base">{{ post.UserName }}</div>
        </a>
        <!-- 用户信息  -->
        <div class="">
            <!-- <a :href="userUrl" class=" relative justify-center"> -->
            <a :href="post.UserUrl" class="grid grid-flow-col justify-start w-full gap-2">
                <el-image :src="post.ImgUrl" fit="fill" :lazy="true" class=" aspect-square rounded-full w-5" />
                <span class=" relative ">{{ post.UserName }}</span>
                <span>{{ releaseTime }}</span>
            </a>

        </div>

    </section>
</template>

<script setup lang="ts">
import type IPostCard from '@/interface/IPostCard';
import { ref } from 'vue';
// let postUrl = ref('https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg');
// let userUrl = ref('');
// let userName = ref('UserName')
// let userImg = ref('https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg');
// let title = ref('title1111111111111');
let releaseTime = ref('10-10');

defineProps<{ post: IPostCard }>()
</script>
