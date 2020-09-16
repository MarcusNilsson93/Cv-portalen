import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Login.vue'
import AcountPage from '../views/Acount.vue'
import UserProfile from "@/components/UserProfile";

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
  },
    {
      path: '/profile',
      name: 'UserProfile',
      
      component: UserProfile
    }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
})

export default router
