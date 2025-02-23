// 创建一个路由器，并暴露出去

// 第一步：引入createRouter
import Home from '@/views/HomeView.vue'
import UserCenterView from '@/views/UserCenterView.vue'
import PostListView from '@/views/PostListView.vue'
import UserInfoView from '@/views/UserInfoView.vue'
import { createRouter, createWebHistory } from 'vue-router'
import CreativeCenterView from '@/views/CreativeCenterView.vue'
import ContributeView from '@/views/ContributeView.vue'
// 引入一个一个可能要呈现组件
// import Home from '@/components/Home.vue'
// import News from '@/components/News.vue'
// import About from '@/components/About.vue'

// 第二步：创建路由器
const router = createRouter({
    history: createWebHistory(), //路由器的工作模式（稍后讲解）
    routes: [ //一个一个的路由规则
        {
            // name: 'Home',
            path: '/',
            component: Home,
            children: [
                {
                    path: "postList",
                    component: PostListView,
                },
            ]
        },
        {
            path: '/userCenter',
            component: UserCenterView,
            children: [
                {
                    path: '',
                    component: UserInfoView,
                },
            ]
        },
        {
            path: '/creativeCenter',
            component: CreativeCenterView,
            children: [
                {
                    path: '/',
                    component: ContributeView,
                },
                {
                    path: 'contribute',
                    component: ContributeView,
                }
            ]
        },

    ]
})

// 暴露出去router
export default router
