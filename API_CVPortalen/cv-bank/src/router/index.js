import Vue from 'vue'
import Router from 'vue-router'
import Login from '../views/Login.vue'
import Profile from '../views/Profile'
import AdminPage from "@/views/AdminPage";
import Home from "@/views/Home";


Vue.use(Router)

let router = new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home,
      meta: {
        guest: true
      }
    },
    {
      path: '/login',
      name: 'Login',
      component: Login,
      meta: {
        guest: true
      }
    },
    {
      path: '/sign-up',
      name: 'SignUp',
      meta: {
        guest: true
      },
      component: () => import('@/views/Signup.vue'),

    },
    {
      path: '/profile',
      name: 'UserProfile',
      meta: {
        requireAuth: true,
        requireAdmin: false
      },
      component: Profile
    },
    {
      path: '/admin_dashboard',
      name: 'AdminDashboard',
      meta: {
        requireAuth: true,
        requireAdmin: true
      },
      component: AdminPage
    },
    {
      path: '*',
      component: Login
    }
  ]
});

router.beforeEach((to, from, next) => {
  if(to.matched.some(record => record.meta.requireAuth)) {
    if (localStorage.getItem('userData') == null) {
      next({
        path: '/login',
        params: { nextUrl: to.fullPath }
      })
    } else {
      let user = JSON.parse(localStorage.getItem('userData'))
      if(to.matched.some(record => record.meta.requireAdmin)) {
        if(user.role === "Admin"){
          next()
        }
        else{
          next({ name: 'UserProfile'})
        }
      }
    else {
        next()
      }
    }
  } else if(to.matched.some(record => record.meta.guest)) {
    if(localStorage.getItem('userData') == null){
      next()
    }
    else{
      next({ name: 'UserProfile'})
    }
  }else {
    next()
  }
});

export default router

