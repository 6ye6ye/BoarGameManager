import LoginView from '../views/Account/LoginView.vue';
import RegisterView from '../views/Account/RegisterView.vue';

import GamesView from '../views/Games/GamesView.vue';
import AddGameView from '../views/Games/AddGameView.vue';
import GameView from '../views/Games/GameView.vue';

import GamePartiesView from '../views/GameParties/GamePartiesView.vue';
import GamePartyView from '../views/GameParties/GamePartyView.vue';
import AddGamePartyView from '../views/GameParties/AddGamePartyView.vue';

import FriendsView from '../views/Friends/FriendsView.vue';

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
        path: '/addGame',
        name: 'AddGameView',
        component: AddGameView
    },
    {
        path: '/game:id',
        name: 'GameView',
        component: GameView,
        params: true
    },

    {
        path: '/myGameParties',
        name: 'GamePartiesView',
        component: GamePartiesView
    },
    {
        path: '/addGameParty',
        name: 'AddGamePartyView',

        component: AddGamePartyView
    },
    {
        path: '/gameParty:id',
        name: 'GamePartyView',
        component: GamePartyView,
        params: true,

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
    },
    {
        path: '/friends',
        name: 'FriendsView',
        component: FriendsView
    },
    {
        path: "/:catchAll(.*)", // Unrecognized path automatically matches 404
        redirect: '/404',
    },
    {
        path: '/404',
        name: 'PageNotExist',
        component: () => import('@/views/PageNotExist.vue')
    }

];


const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
});

export default router;
