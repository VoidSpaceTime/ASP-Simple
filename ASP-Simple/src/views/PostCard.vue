<template>
    <div class="postCard">
        <el-image :src="src" fit="fit" loading="lazy" aria-setsize="60px" class="postImg"></el-image>
        <div class="Info">
            <div>{{ title }}</div>
            <a :href="src"><el-image :src="userImg" fit="fill" :lazy="true" class="userImg"></el-image>

            </a>
            <span>content</span>
        </div>

    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
let src = ref('https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg');
let userImg = ref('https://pic4.zhimg.com/v2-10ab4fade18c67ccd61b0ce123e45321_1440w.jpg')
let title = ref('title1111111111111');
</script>

<style scoped>
.postCard {
    display: grid;
    grid-template-rows: auto;
    grid-auto-flow: row;
    width: 20%;
    gap: 5px;
}

.postImg {
    object-fit: cover;
    width: 100%;
    /* 按比例展示 */
}

.userImg {
    width: 30px;
    height: 30px;
    border-radius: 50%;
}
</style>