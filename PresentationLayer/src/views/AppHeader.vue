<template>
    <nav class="flex items-center justify-between shadow-md flex-wrap bg-gradient-to-r from-blue-500 to-purple-800 text-white w-screen  p-6">
        <div class="flex items-center flex-no-shrink text-white mr-6">
            <router-link class="text-3xl font-bold font-heading hover:text-green-300" to="/">BoardGames</router-link>
        </div>
        <div class="block md:hidden">
            <button @click="toggle" class="ease duration-300 transition-none hover:scale-105 cursor-pointer flex items-center px-3 py-2 border rounded text-teal-lighter border-teal-light hover:text-green-300 hover:border-white">
                <svg class="fill-current h-3 w-3" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><title>Menu</title><path d="M0 3h20v2H0V3zm0 6h20v2H0V9zm0 6h20v2H0v-2z" /></svg>
            </button>
        </div>
        <div :class="open ? 'block rounded mt-3 ': 'hidden'" class="w-full inherit flex-grow md:flex md:items-center md:w-auto ">
            <div class=" md:flex-grow flex">
                <ul class=" flex  md:flex-row flex-col items-center w-full px-4 mx-auto font-semibold font-heading space-between">
                    <li class="ease duration-300 transition-none hover:scale-105 cursor-pointer">
                    <router-link class="p-2 hover:text-green-300" to="/">Games</router-link>
                    </li>
                    <li v-if="isAdmin&&isAuth" 
                        class="ease duration-300 transition-none hover:scale-105 cursor-pointer">
                    <router-link class="p-2 hover:text-green-300" to="/users">Users</router-link>
                    </li>
                    <li v-if="isAuth"
                        class="ease duration-300 transition-none hover:scale-105 cursor-pointer">
                        <router-link class="p-2 hover:text-green-300" to="/myGameParties"> Game parties</router-link>
                    </li>
                    <li v-if="isAuth"
                        class="ease duration-300 transition-none hover:scale-105 cursor-pointer">
                        <router-link class="p-2 hover:text-green-300" to="/friends">Friends</router-link>
                    </li>
                    <li v-if="isAuth"
                        class="ease duration-300 transition-none hover:scale-105 cursor-pointer">
                        <router-link class="p-2 hover:text-green-300" to="/players">Players</router-link>
                    </li>
                    <li v-if="isAuth"
                        class="ease duration-300 transition-none hover:scale-105 cursor-pointer">
                        <router-link class="p-2 hover:text-green-300" to="/gamePlaces">GamePlaces</router-link>
                    </li>
                </ul>
            </div>
            <div class="flex ">
                <ul class=" flex items-center w-full justify-center px-4 mx-auto font-semibold font-heading ">
                    <li v-if="!isAuth"
                        class="ease duration-300 transition-none hover:scale-105 cursor-pointer">
                        <router-link class="p-2 b  hover:text-green-300 mr-2" to="/login"> Sign in</router-link>
                    </li>
                    <li v-if="!isAuth"
                        class="ease duration-300 transition-none hover:scale-105 cursor-pointer">
                        <router-link class="p-2  hover:text-green-300  mr-2" to="/register"> Sign up</router-link>
                    </li>
                    <li v-if="isAuth"
                        class="ease duration-300 transition-none hover:scale-105 cursor-pointer">
                        <router-link class="p-2  hover:text-green-300 mr-2" @click="logout" to="/">Logout</router-link>
                    </li>
                    <li v-if="isAuth"
                        class="ease duration-300 transition-none hover:scale-105 cursor-pointer">
                        <router-link class="p-2 flex block items-center hover:text-green-300" to="/myAccount">
                            <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 hover:text-gray-200" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5.121 17.804A13.937 13.937 0 0112 16c2.5 0 4.847.655 6.879 1.804M15 10a3 3 0 11-6 0 3 3 0 016 0zm6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
                            </svg>
                            {{userName}}
                        </router-link>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>

<script>
    import AccountService from "../services/AccountService";
    export default {
        name: "AppHeader",
        data() {
            return {
                open: false,
                isAuth: false,
                isAdmin: false,
                userName: '',
                cookie: ''
            };
        },
        created: function () {
            var is = this.$cookies.isKey('.AspNetCore.Identity.Application');
            this.cookie = is;
            this.isAdmin = localStorage.getItem('role') === "Admin"
            this.userName = localStorage.getItem('userName');
            this.isAuth = localStorage.getItem('isAuth') == 'true';
        },

        methods: {

            toggle() {
                this.open = !this.open
            },
            logout: function () {
                AccountService.logout().then(response => {
                    switch (response.status) {
                        case (200):
                            {
                                localStorage.setItem('userName', '');
                                localStorage.setItem('role', '');
                                localStorage.setItem('isAuth', 'false');
                                this.isAuth = false
                                this.$router.push('/login')
                                return { ok: true }
                            }
                        case (400):
                            {
                                this.errorMessage = response;
                                return { ok: false }
                            }
                    }
                })
                    .catch(e => {
                        this.errorMessage = e.response.data;
                        console.log(e);
                    });
            },
        },
        components: {},
    };
</script>

<style>
</style>