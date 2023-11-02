import { type RouteRecordRaw } from "vue-router"

const ecommerceRoutes: RouteRecordRaw[] = [
    {
        path: '/dashboard',
        name: 'Main',
        alias: '/',
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
    },
    {
        path: '/products',
        name: 'Products',
        component: () => import("@/views/Product/Product.vue"),
        meta: {
            requireAuth: true
        }
    },
    {
        path: '/products/detail/:id?',
        name: 'ProductDetail',
        component: () => import("@/views/Product/ProductDetail.vue"),
        meta: {
            requireAuth: true
        }
    },
    {
        path: '/master/',
        name: 'Master',
        component: () => import("@/views/Master/Main.vue"),
        meta: {
            requireAuth: true
        }
    },
    {
        path: '/colors/',
        name: 'Color',
        component: () => import("@/views/Master/Color.vue"),
        meta: {
            requireAuth: true
        }
    },
    {
        path: '/categories/',
        name: 'Category',
        component: () => import("@/views/Master/Category.vue"),
        meta: {
            requireAuth: true
        }
    },
    {
        path: '/dimensions/',
        name: 'Dimension',
        component: () => import("@/views/Master/Dimension.vue"),
        meta: {
            requireAuth: true
        }
    },
]

export { ecommerceRoutes };