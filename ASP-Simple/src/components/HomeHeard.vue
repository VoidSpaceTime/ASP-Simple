<template>
    <el-affix>

        <div class="grid grid-flow-col justify-between m-4 h-10">

            <el-link class=" w-40">
                <RouterLink active-class="active" :to="{ path: '/' }">
                    <div class="">图标</div>
                </RouterLink>

            </el-link>
            <div class="w-[28rem] left-10">
                <el-input v-model="search" placeholder="" :suffix-icon="Search" clearable></el-input>
            </div>
            <div class="grid grid-flow-col justify-end gap-4">

                <el-button @click="clickAvatar" :circle="true">
                    <div v-if="loginShow == true">
                        <el-dialog title="登录" width="30%" :close-on-click-modal="false" v-model="loginShow">
                            <span slot="footer">
                                <el-form :model="login" label-width="auto" :status-icon="true" :rules="rules"
                                    class="demo-ruleForm">
                                    <el-form-item label="账号" prop="user">
                                        <el-input v-model="login.UserName"></el-input>
                                    </el-form-item>
                                    <el-form-item label="密码" prop="password">
                                        <el-input v-model="login.Password" type="password"
                                            autocomplete="off"></el-input>
                                    </el-form-item>
                                    <el-form-item class="grid gap-4 justify-self-end">
                                        <el-button class="w-24">注册</el-button>
                                        <el-button class="w-24" type="primary" @click="handleLogin">登录</el-button>
                                    </el-form-item>
                                </el-form>
                            </span>
                        </el-dialog>

                    </div>
                </el-button>
                <el-link>消息</el-link>
                <el-link>动态</el-link>
                <el-link>收藏</el-link>
                <el-link>历史</el-link>
                <el-link>
                    <RouterLink active-class="active" :to="{ path: '/creativeCenter' }" target="_blank">投稿</RouterLink>
                    <!-- <button @click="pushCreativeCenter">投稿</button> -->
                </el-link>

            </div>
        </div>
    </el-affix>
</template>

<script setup lang="ts">
import type { FormRules } from 'element-plus';
import { reactive, ref } from 'vue';
import { Search } from '@element-plus/icons-vue';
import { Repository } from '@/services/Repository';
import router from '@/router';
import { RouterLink } from 'vue-router';
import { useIsUserLoginStore } from '@/stores/userIsLogin';
import { IdentityApi } from '@/services/IdentityApi';

let search = ref('');
let loginShow = ref(false);

let login = reactive({
    UserName: '',
    Password: ''
});

const validatePass = (rule: any, value: string, callback: Function) => {
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

const clickAvatar = function () {
    if (useIsUserLoginStore().getUserStats() == true) {
        console.log("已经登录22");
        router.push({ path: '/userCenter' });
        loginShow.value = false;
    } else {
        loginShow.value = true;
    }
}
const logout = function () {
    localStorage.setItem('token', "");
    useIsUserLoginStore().setUserStats(false);
    router.push({ path: '/' });
}
const handleLogin = () => {
    IdentityApi.LoginByUserNameAndPwdAsync(login)
        .then((res) => {
            if (res.status) {

            }
            console.log("token", res, res.status, res.headers);

            loginShow.value = false;
            localStorage.setItem('token', res.data.token);
            // router.push({ path: '/' });

        }).catch(err => {
            console.log(err);
            console.log("登录报错");
            useIsUserLoginStore().setUserStats(false);
            localStorage.setItem('token', "");

        });
};
function pushCreativeCenter() {
    const url = router.resolve({ path: '/creativeCenter' });
    window.open(url.href, '_blank');
}


</script>