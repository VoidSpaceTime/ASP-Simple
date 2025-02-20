import axios from 'axios'
axios.defaults.headers.common['contentType'] ='application/json';
export function RequestPost(url: string, parameter: {}) {
    const instance = axios.create({
        baseURL: url,
        timeout: 12000,
        method: "post",
    });
    //拦截器
    instance.interceptors.request.use(
        config => {

            let token = localStorage.getItem("token") || "";
            config.headers.token = token;
            // 上面不行用这个
            // config.headers.contentType = 'application/json';
            return config;
        },
        err => {
            console.log(err);
        }
    );
    instance.interceptors.response.use(
        res => {
            let data = res.data;

            // if (data.success === false) {
            //     if (data.code === "000008") {
            //         //token 无效
            //         window.localStorage.clear();

            //         //跳转到登录页面
            //         // router.push('/login');
            //         router.push("/");
            //     }
            // }
            return res.data;
        },
        err => {
            console.log(err);
        }
    );
    return instance(parameter);
}

export function RequestGet(url: string, parameter: {}) {
    //创建实例
    const instance = axios.create({
        baseURL: url,
        timeout: 12000,
        method: "get",
    });
    //拦截器
    instance.interceptors.request.use(
        config => {
            let token = localStorage.getItem("token") || "";
            config.headers.token = token;
            return config;
        },
        err => {
            console.log(err);
        }
    );

    instance.interceptors.response.use(
        res => {
            let data = res.data;

            // if (data.success === false) {
            //     if (data.code === "000008") {
            //         //token 无效
            //         window.localStorage.clear();

            //         //跳转到登录页面
            //         // router.push('/login');
            //         router.push("/");
            //     }
            // }
            return res.data;
        },
        err => {
            console.log(err);
        }
    );

    return instance(parameter);
}
