import { createApp } from 'vue'
import App from './App.vue'
import router from '@/router/index.js';
import './index.css'
const cors = require('cors');

import ModalWindow from '@/components/ModalWindow.vue';
import FilterBox from '@/components/FilterBox.vue';
import InfoMessage from '@/components/InfoMessage.vue';
import ContainerWhite from '@/components/ContainerWhite.vue';
createApp(App).component('ModalWindow', ModalWindow)
    .component('FilterBox', FilterBox)
    .component('InfoMessage', InfoMessage)
    .component('ContainerWhite', ContainerWhite)
    .use(router)
    .use(cors)
    .use(require('vue-cookies')).mount('#app')
