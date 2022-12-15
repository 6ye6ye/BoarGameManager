import LoginView from '../views/Account/LoginView.vue';
import RegisterView from '../views/Account/RegisterView.vue';

import GamesView from '../views/Games/GamesView.vue';
import AddGameView from '../views/Games/AddGameView.vue';
import GameView from '../views/Games/GameView.vue';

import GamePartiesView from '../views/GameParties/GamePartiesView.vue';
import GamePartyView from '../views/GameParties/GamePartyView.vue';
import AddGamePartyView from '../views/GameParties/AddGameParty.vue';

import FriendsView from '../views/Friends/FriendsView.vue';

import UsersView from '../views/Users/UsersView.vue';
import UserView from '../views/Users/UserView.vue';

import PlayersView from '../views/Players/PlayersView.vue';
import GamePlacesView from '../views/GamePlaces/GamePlacesView.vue';


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
        path: '/game/:id',
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
        path: '/gameParty/:id',
        name: 'GamePartyView',
        component: GamePartyView,
        params: true,
    },
    {
        path: '/login',
        name: 'LoginView',
        component: LoginView
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
        path: '/players',
        name: 'PlayersView',
        component: PlayersView
    },
    {
        path: '/gamePlaces',
        name: 'GamePlacesView',
        component: GamePlacesView
    },
    {
        path: '/users',
        name: 'UsersView',
        component: UsersView

    },
    {
        path: '/user/:id',
        name: 'UserView',
        component: UserView,
        params: true,
    },
    {
        path: '/myAccount',
        name: 'MyUserView',
        component: UserView,
        params: true,
    },
    {
        path: "/:catchAll(.*)",
        redirect: '/404',
    },
    {
        path: '/404',
        name: 'PageNotExist',
        component: () => import('@/views/PageNotExist.vue')
    }
];


const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
