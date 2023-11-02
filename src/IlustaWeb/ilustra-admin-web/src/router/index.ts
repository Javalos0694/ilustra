import { useAuthStore } from '@/store/auth'
import { storeToRefs } from 'pinia';
import { ecommerceRoutes } from './ecommerce.routes';
import { type RouteRecordRaw, createRouter, createWebHistory } from 'vue-router'

const routes: RouteRecordRaw[] = [
    {
        path: '/login',
        name: 'Login',
        component: () => import('@/views/Auth/Login.vue'),
        meta: {
            requireAuth: false
        }
    },
    {
        path: '/',
        name: 'Layout',
        component: () => import('@/components/base/layout.vue'),
        children: ecommerceRoutes
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

router.beforeEach((to, from, next) => {
    const authStore = useAuthStore();
    const { tokenStored } = storeToRefs(authStore);

    const authenticated = tokenStored.value.length > 0;
    const needAuth = to.meta.requireAuth;

    if (needAuth && !authenticated) return next("/login")
    return next()
})

export default router;