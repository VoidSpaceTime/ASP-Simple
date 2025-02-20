<template>
    <div>
        <!-- heard -->
        <div class="grid grid-cols-2">
            <div class="w-40">
                <el-menu :default-active="1" class="el-menu-demo" mode="vertical" @select="">
                    <el-menu-item index="1">
                        <RouterLink index="1" to="/userCenter/userInfo">用户中心</RouterLink>
                    </el-menu-item>
                </el-menu>
            </div>
            <RouterView />
        </div>

    </div>
</template>
<script setup lang="ts">
import { reactive } from 'vue';
import { RouterView, routerViewLocationKey } from 'vue-router';


let menus = reactive([
    {
        title: "主页",
        path: "userInfo",
    },
    {
        title: "笔记管理",
        path: "/",

    },
]);

</script>