<template>
    <div class="grid justify-self-center w-11/12">
        <HomeHeard />
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
            <!-- <PostListView /> -->
        </div>
    </div>
</template>

<script setup lang="ts" name="Home">
import { ref, reactive } from 'vue';
import axios from 'axios';
import HomeHeard from './HomeHeard.vue';

</script>