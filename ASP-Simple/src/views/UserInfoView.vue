<template>
    <div class="grid grid-cols-2 justify-self-center">
        <el-image :src="url" fit="cover" :lazy="true" class=" rounded-full w-28 h-28 self-center"></el-image>
        <el-card shadow="never" :body-style="{ padding: '20px' }">
            <div slot="header">
                <span>时空</span>
            </div>
            <!-- card body -->
            <div slot="body">
                <div>时空</div>
                <div>UID</div>
                <div>签名</div>
                <div>年龄/性别</div>
                <div>关注 粉丝 获赞 收藏</div>
            </div>
        </el-card>
        <div class="affix-container col-span-2">
            <el-affix :offset="80" class="grid grid-flow-col justify-center">
                <el-button type="primary">Target container</el-button>
                <el-button type="primary">Target container</el-button>
                <el-button type="primary">Target container</el-button>
            </el-affix>
        </div>
        <ul v-infinite-scroll="load" class="infinite-list" style="overflow: auto">
            <li v-for="(post, i) in postList" :key="i" class="infinite-list-item">{{ i }}</li>

        </ul>
    </div>

</template>

<script setup lang="ts">
import { reactive } from 'vue';

let url = "https://sns-avatar-qc.xhscdn.com/avatar/5dcc405f0000000001007ed0.jpg?imageView2/2/w/540/format/webp|imageMogr2/strip2"
let postList = reactive([{
    count: 0
}])
const load = () => {
    // postList.push({
    //     count: 0
    // })
}
</script>