import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import '@mdi/font/css/materialdesignicons.css'
import { createStore } from 'vuex'
import state from './store/state'
import mutations from './store/mutations'
import getters from './store/getters'
import actions from './store/actions'

const store = createStore({
    state,
    getters,
    mutations,
    actions
})

//vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const vuetify = createVuetify({
    components,
    directives,
  })

  //sweet alert
import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';

createApp(App).use(store).use(router).use(vuetify).use(VueSweetalert2).mount('#app')
