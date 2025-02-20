import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import router from './router/index'
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import App from './App.vue'
import { RequestGet } from './services/Repository'

const app = createApp(App)

app.use(createPinia())
app.use(ElementPlus)
app.use(router)

app.mount('#app')
