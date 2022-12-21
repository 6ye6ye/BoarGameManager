import { createApp } from 'vue'
import App from './App.vue'
import router from '@/router/index.js';
import './index.css'
const cors = require('cors');

import ModalWindow from './views/ModalWindow.vue';

createApp(App).component('modal-window', ModalWindow)
    .use(router)
    .use(cors)
    .use(require('vue-cookies')).mount('#app')
