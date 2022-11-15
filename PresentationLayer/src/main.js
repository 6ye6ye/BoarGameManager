import { createApp }  from 'vue'
import App from './App.vue'
import router from '@/router/index.js';


//import BootstrapVue from 'bootstrap-vue/dist/bootstrap-vue.esm';
//import 'bootstrap-vue/dist/bootstrap-vue.css';
//import 'bootstrap/dist/css/bootstrap.css';

export const eventBus = createApp(App)
const cors = require('cors');



createApp(App).use(router).use(cors).mount('#app')   
//createApp(App).mount('#app')

