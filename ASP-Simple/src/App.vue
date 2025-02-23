<template>
  <div class="grid w-full h-full">
    <RouterView></RouterView>
  </div>

</template>

<script setup lang="ts">
import { onBeforeMount, reactive, ref } from 'vue';
import { IdentityApi } from './services/IdentityApi';
import router from './router';
import { useIsUserLoginStore } from './stores/userIsLogin';

// 搞一个钩子 每次挂载的时候 发送一个获取用户信息的请求 判断登录状态, token失效时间归服务器管理
onBeforeMount(async () => {
  await IdentityApi.GetUserInfoAsync().then(res => {
    if (res.status == 200) {

      useIsUserLoginStore().setUserStats(true);
      console.log("已经登录");

    }
  }).catch(err => {
    useIsUserLoginStore().setUserStats(false);
    localStorage.setItem('token', "");
    // router.push({ path: '/' });
  })
})


</script>
