import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const useIsUserLoginStore = defineStore('isUserLogin', () => {
    let isUserLogin = ref(false)

    function setUserStats(flag: boolean = false) {
        isUserLogin.value = flag
    }
    function getUserStats() {
        return isUserLogin.value
    }

    return { setUserStats, getUserStats }
})
