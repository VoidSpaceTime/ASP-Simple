<template>
    <div>
        <!-- heard -->
        <div></div>
        <div class="grid">
            <div class="w-1/6">

                <el-menu :default-active="1" class="el-menu-demo" mode="vertical" @select="">
                    <el-menu-item v-for="(submenus, index) in menus" :index="index + 1">
                        {{ submenus.title }}
                    </el-menu-item>
                </el-menu>
            </div>
            <div class="">
                <RouterView />
            </div>
        </div>

    </div>
</template>
<script setup lang="ts">
import { reactive } from 'vue';
import { RouterView, routerViewLocationKey } from 'vue-router';


let menus = reactive([
    {
        title: "主页",
    },
    {
        title: "笔记管理",
    },
]);

</script>