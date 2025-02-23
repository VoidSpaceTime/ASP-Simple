<template>
    <div class="grid grid-rows-[3rem,1fr]">
        <el-affix class=" col-span-2 col-start-1  w-screen">
            <div class="grid grid-flow-col justify-between">
                <div>
                    <!-- <el-image :src="url" fit="fill" :lazy="true">
                    </el-image> -->
                    <div>图标占位</div>
                </div>
                <div>
                    <el-dropdown>
                        <span class="el-dropdown-link">
                            <el-avatar size="small" shape="circle" :src="url" fit="fill"></el-avatar>
                            <el-icon class="el-icon--right">
                                <arrow-down />
                            </el-icon>
                        </span>
                        <template #dropdown>
                            <el-dropdown-menu>
                                <el-dropdown-item>
                                    <el-button type="text" size="small" @click="">注销</el-button>
                                </el-dropdown-item>
                            </el-dropdown-menu>
                        </template>
                    </el-dropdown>
                </div>
            </div>
        </el-affix>
        <div class="grid grid-cols-[8rem_minmax(50rem,_1fr)]">

            <el-affix class="w-full">
                <el-button type="primary" size="medium" @click="" class=" bg-red-600">
                    <RouterLink :to="{ path: 'creativeCenter/' }">发布笔记</RouterLink>
                    <!-- <RouterLink :to="{ path:" creativeCenter/contribute"}"></RouterLink> -->
                </el-button>
                <!-- 
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

                </el-menu> -->
            </el-affix>
            <router-view></router-view>

        </div>
    </div>
</template>

<script setup lang="ts">

import { ArrowDown } from '@element-plus/icons-vue'
let url = "https://sns-avatar-qc.xhscdn.com/avatar/5dcc405f0000000001007ed0.jpg?imageView2/2/w/540/format/webp|imageMogr2/strip2"

</script>