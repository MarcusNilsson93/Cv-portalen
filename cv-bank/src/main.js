import Vue from '../node_modules/vue/types'
import App from './App.vue'
import router from './router'
import Buefy from '../node_modules/buefy/types'
import './node_modules/buefy/dist/buefy.css'

Vue.use(Buefy)

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
