<template>
    <HomeHeard />

    <!-- heard -->
    <div class="grid grid-cols-[10rem_minmax(600px,_1fr)] grid-rows-2">

        <el-affix>
            <div class=" row-start-1 row-span-2">
                <el-menu :default-active="1" class="" mode="vertical" @select="">

                    <el-menu-item :index="1">
                        <RouterLink :to="{ path: 'userCenter' }">用户中心</RouterLink>
                    </el-menu-item>
                    <el-menu-item :index="2">
                        <RouterLink to="userCenter/userInfo">用户中心</RouterLink>
                    </el-menu-item>
                    <el-menu-item :index="3">
                        <RouterLink to="userCenter/userInfo">用户中心</RouterLink>
                    </el-menu-item>
                    <el-menu-item :index="4">
                        <RouterLink to="userCenter/userInfo">用户中心</RouterLink>
                    </el-menu-item>

                </el-menu>
            </div>
        </el-affix>
        <RouterView />
    </div>

</template>
<script setup lang="ts">
import HomeHeard from '@/components/HomeHeard.vue';
import { reactive } from 'vue';
import { RouterView, routerViewLocationKey } from 'vue-router';


</script>