<template>
    <div class="grid grid-flow-col justify-between m-4">

        <el-link class=" w-40"><router-link active-class="active" :to="{ path: '/home' }">  <div class="">图标</div></router-link>
          
        </el-link>
        <div class="w-[28rem] left-10">
            <el-input v-model="search" placeholder="" :suffix-icon="Search" clearable></el-input>
        </div>
        <div class="grid grid-flow-col justify-end gap-4">
            <el-button @click="loginShow = true" :circle="true">
                <el-dialog title="登录" width="30%" :close-on-click-modal="false" v-model="loginShow">
                    <span slot="footer">
                        <el-form :model="login" label-width="auto" :status-icon="true" :rules="rules"
                            class="demo-ruleForm">
                            <el-form-item label="账号" prop="user">
                                <el-input v-model="login.UserName"></el-input>
                            </el-form-item>
                            <el-form-item label="密码" prop="password">
                                <el-input v-model="login.Password" type="password" autocomplete="off"></el-input>
                            </el-form-item>
                            <el-form-item class="grid gap-4 justify-self-end">
                                <el-button class="w-24">注册</el-button>
                                <el-button class="w-24" type="primary" @click="handleLogin">登录</el-button>
                            </el-form-item>
                        </el-form>
                    </span>
                </el-dialog>
            </el-button>
            <el-link>消息</el-link>
            <el-link>动态</el-link>
            <el-link>收藏</el-link>
            <el-link>历史</el-link>
            <el-link> <router-link active-class="active" :to="{ path: '/userCenter' }">投稿</router-link></el-link>

        </div>
    </div>
</template>

<script setup lang="ts">
import type { FormRules } from 'element-plus';
import { reactive, ref } from 'vue';
import { Search } from '@element-plus/icons-vue';
import { RequestPost } from '@/services/Repository';
import { el } from 'element-plus/es/locales.mjs';

let search = ref('');
let loginShow = ref(false);

let login = reactive({
    UserName: '',
    Password: ''
});

const validatePass = (rule: any, value: any, callback: any) => {
    if (value === '') {
        callback(new Error('请输入密码'));
    } else if (value.length <= 5) {
        callback(new Error('密码长度不能小于6位'));
    } else {
        callback();
    }
};

const rules = reactive<FormRules<typeof login>>({
    Password: [{ validator: validatePass, trigger: 'blur' }]
});

const handleLogin = () => {
    RequestPost('Login/LoginByUserNameAndPwd', login).then(res => {
        localStorage.setItem('token', res.data.token);
    }).catch((reason) => console.log("失败", reason))
};
</script>