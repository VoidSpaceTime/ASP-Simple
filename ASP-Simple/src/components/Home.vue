<template>
    <div class="grid justify-self-center w-11/12">
        <div class="grid grid-flow-col justify-between m-4 ">
            <div>图标</div>
            <div class=" w-[30rem]">
                <el-input v-model="search" placeholder="" size="large" :suffix-icon="Search" clearable
                    @change=""></el-input>
            </div>
            <el-button type="" size="large" @click="loginShow = true" circle="true">
                <el-dialog title="登录" width="30%" :close-on-click-modal="false" v-model="loginShow" @close="">
                    <span slot="footer">
                        <el-button @click="loginShow = false">Cancel</el-button>
                        <el-button type="primary" @click="">OK</el-button>
                    </span>
                </el-dialog>
            </el-button>
        </div>
        <el-tabs v-model="activeName" class=" justify-self-center w-full" @tab-click="" type="card">
            <el-tab-pane label="User" name="1">User</el-tab-pane>
            <el-tab-pane label="Config" name="2">Config</el-tab-pane>
            <el-tab-pane label="Role" name="3">Role</el-tab-pane>
            <el-tab-pane label="Task" name="4">Task</el-tab-pane>
        </el-tabs>
        <div class="grid grid-cols-6"></div>
    </div>

</template>

<script setup lang="ts" name="Home">
import { Search } from '@element-plus/icons-vue'
import emitter from '@/unitls/mitters';
import { ref, reactive } from 'vue';
import Login from '@/components/Login.vue';
let search = ref('')
const activeName = ref('1')
let icon = "http://www.w3.org/2000/svg"
let loginShow = ref(false)
function login() {
    // 未登录 弹出登录
    loginShow.value = true
    // 登录 跳转个人信息
}


</script>
