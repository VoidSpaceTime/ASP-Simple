<template>
    <section class="grid grid-cols-1 gap-1">
        <!-- 文章  -->
        <a :href="post.PostUrl">
            <el-image :src="post.ImgUrl" fit="fit" loading="lazy" :underline="false" aria-setsize="60px"
                class=" w-auto object-cover"></el-image>
            <el-link class=" text-base">{{ post.UserName }}</el-link>
        </a>
        <!-- 用户信息  -->
        <div class="">
            <!-- <a :href="userUrl" class=" relative justify-center"> -->
            <el-link :href="post.UserUrl" :underline="false" class="">
                <el-image :src="post.ImgUrl" fit="fill" :lazy="true" class="aspect-square rounded-full w-7 mr-2" />
                <span class=" relative ">{{ post.UserName }} · {{ releaseTime }}</span>
            </el-link>

        </div>
    </section>
</template>

<script setup lang="ts">
import type IPostCard from '@/interface/IPostCard';
import { ref } from 'vue';

let releaseTime = ref('10-10');

defineProps<{ post: IPostCard }>()
</script>
