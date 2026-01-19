import { reactive, computed } from 'vue'
import authService from '../services/authService'
import type { User, LoginRequest, RegisterRequest } from '../types/auth'

const state = reactive({
    user: authService.getCurrentUser() as User | null,
    isAuthenticated: authService.isAuthenticated()
})

const login = async (data: LoginRequest) => {
    const response = await authService.login(data)
    if (response.success && response.user) {
        state.user = response.user
        state.isAuthenticated = true
    }
    return response
}

const register = async (data: RegisterRequest) => {
    const response = await authService.register(data)
    if (response.success && response.user) {
        state.user = response.user
        state.isAuthenticated = true
    }
    return response
}

const logout = () => {
    authService.logout()
    state.user = null
    state.isAuthenticated = false
}

const isAdmin = computed(() => {
    return state.user?.role === 'Admin'
})

export const useAuthStore = () => {
    return {
        state,
        login,
        register,
        logout,
        isAdmin
    }
}
