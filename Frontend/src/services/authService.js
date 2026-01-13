import axios from 'axios'

const API_URL = 'https://localhost:7126/api/auth'

const authService = {
    async register(email, password, fullName) {
        try {
            const response = await axios.post(`${API_URL}/register`, {
                email,
                password,
                fullName
            })

            if (response.data.success && response.data.token) {
                localStorage.setItem('authToken', response.data.token)
                localStorage.setItem('user', JSON.stringify(response.data.user))
            }

            return response.data
        } catch (error) {
            if (error.response && error.response.data) {
                return error.response.data
            }
            return {
                success: false,
                message: 'Error de conexión con el servidor'
            }
        }
    },

    async login(email, password) {
        try {
            const response = await axios.post(`${API_URL}/login`, {
                email,
                password
            })

            if (response.data.success && response.data.token) {
                localStorage.setItem('authToken', response.data.token)
                localStorage.setItem('user', JSON.stringify(response.data.user))
            }

            return response.data
        } catch (error) {
            if (error.response && error.response.data) {
                return error.response.data
            }
            return {
                success: false,
                message: 'Error de conexión con el servidor'
            }
        }
    },

    logout() {
        localStorage.removeItem('authToken')
        localStorage.removeItem('user')
    },

    getCurrentUser() {
        const userStr = localStorage.getItem('user')
        return userStr ? JSON.parse(userStr) : null
    },

    isAuthenticated() {
        return !!localStorage.getItem('authToken')
    }
}

export default authService
