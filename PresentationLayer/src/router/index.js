import LoginView from '../views/Account/LoginView.vue';
import GamesView from '../views/Games/GamesView.vue';
import RegisterView from '../views/Account/RegisterView.vue';
//Vue.use(Router)
import {
    createWebHistory,
    createRouter
} from "vue-router";

const routes = [
    {
        path: '',
        name: 'GamesView',
        component: GamesView
    },
    {
        path: '/login',
        name: 'LoginView',
        component: LoginView
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        // component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
    },
    {
        path: '/register',
        name: 'RegisterView',
        component: RegisterView
    }
];

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
});

export default router;
