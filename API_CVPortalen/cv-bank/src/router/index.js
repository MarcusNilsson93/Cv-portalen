import Vue from 'vue'
import VueRouter from 'vue-router'
import Login from '../views/Login.vue'
import AcountPage from '../views/Acount.vue'
import {loggedIn} from "@/components/Actions/Api"

Vue.use(VueRouter)

  const routes = [
  {
    path: '/',
    name: 'Login',
    component: Login
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
      path: '/profile',
      name: 'UserProfile',
      component: async () => (await loggedIn === true ? AcountPage : Login)
    },
    {
      path: '*',
      component: Login
    }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
})

export default router
