<template>
    <div class="grid justify-self-center w-11/12">
        <div class="grid grid-flow-col justify-between m-4">
            <div class="">图标</div>
            <div class="w-[28rem]">
                <el-input v-model="search" placeholder="" :suffix-icon="Search" clearable></el-input>
            </div>
            <div class="grid grid-flow-col justify-end gap-4">
                <el-button @click="loginShow = true" :circle="true">
                    <el-dialog title="登录" width="30%" :close-on-click-modal="false" v-model="loginShow">
                        <span slot="footer">
                            <el-form :model="login" label-width="auto" :status-icon="true" :rules="rules" class="demo-ruleForm">
                                <el-form-item label="账号" prop="user">
                                    <el-input v-model="login.user"></el-input>
                                </el-form-item>
                                <el-form-item label="密码" prop="password">
                                    <el-input v-model="login.password" type="password" autocomplete="off"></el-input>
                                </el-form-item>
                                <el-form-item>
                                    <el-button>注册</el-button>
                                    <el-button type="primary" @click="handleLogin">登录</el-button>
                                </el-form-item>
                            </el-form>
                        </span>
                    </el-dialog>
                </el-button>
                <el-link>消息</el-link>
                <el-link>动态</el-link>
                <el-link>收藏</el-link>
                <el-link>历史</el-link>
            </div>
        </div>
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
import { Search } from '@element-plus/icons-vue';
import { ref, reactive } from 'vue';
import type { FormInstance, FormRules } from 'element-plus';
import axios from 'axios';

let search = ref('');
let loginShow = ref(false);

let login = reactive({
    user: '',
    password: ''
});

const validatePass = (rule: any, value: any, callback: any) => {
    if (value === '') {
        callback(new Error('请输入密码'));
    } else if (value.length < 6) {
        callback(new Error('密码长度不能小于6位'));
    } else {
        callback();
    }
};

const rules = reactive<FormRules<typeof login>>({
    password: [{ validator: validatePass, trigger: 'blur' }]
});

const handleLogin = () => {
    console.log('登录按钮被点击');
    // axios.post('http://localhost:3000/login', login).then(res => {
    //     console.log(res);
    // });
    // 在这里添加登录逻辑
};
</script>