import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/customers/HomeView.vue'
import AdminLayout from '../views/admin/AdminLayout.vue'
import CustomerLayout from '../views/customers/CustomerLayout.vue'

const routes = [
  {
    path: '/admin',
    component: AdminLayout,
    children: [
      {
        path: 'dashboard',
        name: 'dashboard',
        component: () => import('../views/admin/AdminDashBoard.vue')
      },
      {
        path: 'jewelries',
        name: 'jewelry',
        component: () => import('../views/admin/AdminJewelry.vue')
      },
      {
        path: 'categories',
        name: 'category',
        component: () => import('../views/admin/AdminCategory.vue')
      },
      {
        path: 'orders',
        name: 'orders',
        component: () => import('../views/admin/AdminOrder.vue')
      },
      {
        path: 'customers',
        name: 'customers',
        component: () => import('../views/admin/Customer.vue')
      }
    ],
  },
  {
    path: '/customers',
    component: CustomerLayout,
    children: [
      {
        path: '/',
        name: 'home',
        component: HomeView
      },
      {
        path: 'detail-Jewelry/:id/:category',
        name: 'detailjewelry',
        component: () => import('../views/customers/DetailJewelry.vue')
      },
      {
        path: 'cart',
        name: 'cart',
        component: () => import('../views/customers/Cart.vue'),
      },
      {
        path: 'checkout',
        name: 'checkout',
        component: () => import('../views/customers/Checkout.vue')
      },
      {
        path: 'order',
        name: 'order',
        component: () => import('../views/customers/Order.vue')
      },
    ],
  },
  {
    path: '/login',
    name: 'login',
    component: () => import('../views/Login.vue')
  },


]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
