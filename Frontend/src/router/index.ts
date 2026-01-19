import { createRouter, createWebHistory } from 'vue-router'
import Login from '../views/Login.vue'
import Register from '../views/Register.vue'
import Dashboard from '../views/Dashboard.vue'
import Admin from '../views/Admin.vue'
import Unauthorized from '../views/Unauthorized.vue'
import { useAuthStore } from '../store/auth'

const routes = [
    { path: '/', redirect: '/login' },
    { path: '/login', component: Login },
    { path: '/register', component: Register },
    { path: '/unauthorized', component: Unauthorized },
    {
        path: '/dashboard',
        component: Dashboard,
        meta: { requiresAuth: true }
    },
    {
        path: '/admin',
        component: Admin,
        meta: { requiresAuth: true, requiresAdmin: true }
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

router.beforeEach((to, _from, next) => {
    const { state } = useAuthStore()
    const isAuthenticated = state.isAuthenticated
    const user = state.user

    if (to.meta.requiresAuth && !isAuthenticated) {
        next('/login')
    } else if (to.meta.requiresAdmin && user?.role !== 'Admin') {
        next('/unauthorized')
    } else {
        next()
    }
})

export default router
