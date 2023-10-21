import { type RouteRecordRaw, createRouter, createWebHistory } from 'vue-router'

const routes: RouteRecordRaw[] = [
    {
        path: '/login',
        name: 'Login',
        component: () => import('@/views/Auth/Login.vue')
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router;