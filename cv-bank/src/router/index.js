import Vue from '../../node_modules/vue/types'
import VueRouter from '../../node_modules/vue-router/types'
import Home from '../views/Login.vue'
import AcountPage from '../views/Acount.vue'

Vue.use(VueRouter)

  const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/sign-up',
    name: 'SignUp',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/Signup.vue')
  },
  {
    path: '/usertoken',
    name: 'AcountPage',
    component: AcountPage
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
