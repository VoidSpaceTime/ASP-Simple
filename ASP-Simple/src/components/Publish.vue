<template>
    <div>
        <!-- heard -->
        <div></div>
        <div class="grid grid-cols-2">
            <div class="w-48">
                <el-menu mode="vertical" default-active="1" @select="">
                    <el-submenu v-for="(submenus, index) in menus" :index="index + 1" :key="submenus.key">
                        <template slot="title">{{ submenus.title }}</template>
                        <el-menu-item v-for="(item, subIndex) in submenus.menus"
                            :index="(index + 1) + '-' + (subIndex + 1)" :key="item.key">
                            {{ item.subTitle }}
                        </el-menu-item>
                    </el-submenu>
                </el-menu>

            </div>
            <div class="">
                <routerView />
            </div>
        </div>
    </div>
</template>
<script setup lang="ts">
import { reactive } from 'vue';
import { routerViewLocationKey } from 'vue-router';


let menus = reactive([{
    title: "测试标题", key: "menu", menus: [
        { subTitle: "首页", key: "1d" }, { subTitle: "笔记管理", key: "1d" }, { subTitle: "数据看板", key: "1d" }, { subTitle: "账号管理", key: "1d" }
    ]
}])

</script>