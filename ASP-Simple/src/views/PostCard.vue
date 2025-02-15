<template>
    <div class="grid grid-cols-1 w-1/5 gap-1">
        <!-- 文章  -->
        <a :href="postUrl">
            <el-image :src="userImg" fit="fit" loading="lazy" aria-setsize="60px"
                class=" w-auto object-cover"></el-image>
            <div class=" text-base">{{ title }}</div>
        </a>
        <!-- 用户信息  -->
        <div class="">
            <!-- <a :href="userUrl" class=" relative justify-center"> -->
            <a :href="userUrl" class="grid grid-flow-col justify-start w-full gap-x-1">
                <el-image :src="userImg" fit="fill" :lazy="true" class=" aspect-square rounded-full w-5" />
                <span class=" relative ">{{ userName }}</span>
                <span>{{ releaseTime }}</span>
            </a>

        </div>

    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
let postUrl = ref('https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg');
let userUrl = ref('');
let userName = ref('UserName')
let userImg = ref('https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg');
let title = ref('title1111111111111');
let releaseTime = ref('10-10');
</script>
