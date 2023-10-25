import { useAuthStore } from '@/store/auth'
import { storeToRefs } from 'pinia';
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
        path: '/dashboard',
        alias: '/',
        name: 'Main',
        component: () => import("@/views/Main/Dashboard.vue"),
        meta: {
            requireAuth: true
        }
    },
    {
        path: '/users',
        name: 'Users',
        component: () => import("@/views/User/Users.vue"),
        meta: {
            requireAuth: true
        }
    },
    {
        path: '/account',
        name: 'Account',
        component: () => import("@/views/User/Account.vue"),
        meta: {
            requireAuth: true
        }
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