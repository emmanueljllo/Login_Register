import axios from 'axios'
import type { LoginRequest, RegisterRequest, AuthResponse, User } from '../types/auth'

const API_URL = 'http://localhost:5109/api/auth'

const authService = {
    async register(data: RegisterRequest): Promise<AuthResponse> {
        try {
            const response = await axios.post<AuthResponse>(`${API_URL}/register`, data)

            if (response.data.success && response.data.token) {
                localStorage.setItem('authToken', response.data.token)
                if (response.data.user) {
                    localStorage.setItem('user', JSON.stringify(response.data.user))
                }
            }

            return response.data
        } catch (error: any) {
            if (error.response && error.response.data) {
                return error.response.data
            }
            return {
                success: false,
                message: 'Error de conexión con el servidor'
            }
        }
    },

    async login(data: LoginRequest): Promise<AuthResponse> {
        try {
            const response = await axios.post<AuthResponse>(`${API_URL}/login`, data)

            if (response.data.success && response.data.token) {
                localStorage.setItem('authToken', response.data.token)
                if (response.data.user) {
                    localStorage.setItem('user', JSON.stringify(response.data.user))
                }
            }

            return response.data
        } catch (error: any) {
            if (error.response && error.response.data) {
                return error.response.data
            }
            return {
                success: false,
                message: 'Error de conexión con el servidor'
            }
        }
    },

    logout(): void {
        localStorage.removeItem('authToken')
        localStorage.removeItem('user')
    },

    getCurrentUser(): User | null {
        const userStr = localStorage.getItem('user')
        return userStr ? JSON.parse(userStr) : null
    },

    isAuthenticated(): boolean {
        return !!localStorage.getItem('authToken')
    },

    getToken(): string | null {
        return localStorage.getItem('authToken')
    }
}

export default authService
