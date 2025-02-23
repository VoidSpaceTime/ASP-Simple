import type { IRegisterUser } from "@/interface/IIdentity";
import { Repository } from "./Repository";

let url = "https://10.243.222.94:7137";
let domainName = "/Login";
export let IdentityApi = {
    RegisterUserAsync: async function (data: IRegisterUser) {
        return await Repository.RequestPost(url, {
            url: url + domainName + "/RegisterUser",
            data: data
        });
    },

    // GetUserInfo
    GetUserInfoAsync: async function () {
        return await Repository.RequestGet(url + domainName + "/GetUserInfo", {});
    },
    // LoginByPhoneAndPwd
    LoginByPhoneAndPwdAsync: async function (data: { PhoneNum: string, Password: string }) {
        return await Repository.RequestPost(url, {
            url: url + domainName + "/LoginByPhoneAndPwd",
            data: data
        });
    },
    // LoginByUserNameAndPwd
    LoginByUserNameAndPwdAsync: async function (data: { UserName: string, Password: string }) {
        return await Repository.RequestPost(url, {
            url: url + domainName + "/LoginByUserNameAndPwd",
            data: data
        });
    },
    // ChangeMyPassword
    ChangeMyPasswordAsync: async function (data: { OldPassword: string, NewPassword: string }) {
        return await Repository.RequestPost(url, {
            url: url + domainName + "/ChangeMyPassword",
            data: data
        });
    },
}

