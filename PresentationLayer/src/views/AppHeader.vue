<template>
    <!--<nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid .navbar">
            <router-link class="navbar-brand" to="/">BoardGames</router-link>
            <router-link class="nav-link" to="/">Games</router-link>
            <router-link class="nav-link" v-show="isAdmin&&isAuth" to="/users">Users</router-link>
            <router-link class="nav-link" v-show="isAuth" to="/myGameParties"> Game parties</router-link>
            <router-link class="nav-link" v-show="isAuth" to="/friends">Friends</router-link>

            <router-link class="nav-link" v-show="isAuth" to="/players">Players</router-link>
            <router-link class="nav-link" v-show="isAuth" to="/gamePlaces">GamePlaces</router-link>

            <router-link class="nav-link" v-show="!isAuth" to="/login"> Sign in</router-link>
            <router-link class="nav-link" v-show="!isAuth" to="/register"> Sign up</router-link>
            <router-link class="nav-link" v-show="isAuth" @click="logout" to="/">Logout</router-link>
            <router-link class="nav-link" v-show="isAuth" to="/myAccount">  {{userName}}</router-link>
        </div>
    </nav>-->

    <section class="relative mx-auto">
    
        <nav class="flex justify-between bg-purple-800 text-white w-screen">
            <div class="px-5 xl:px-12 py-6 flex justify-between w-full items-center">

                <router-link class="text-3xl font-bold font-heading hover:text-gray-200" to="/">BoardGames</router-link>
               
                    <ul class="hidden xl:flex  px-4 mx-auto font-semibold font-heading space-x-12">
                        <li><router-link class="hover:text-gray-200" to="/">Games</router-link></li>
                        <li v-if="isAdmin&&isAuth"><router-link class="hover:text-gray-200" to="/users">Users</router-link></li>
                        <li v-if="isAuth"> <router-link class="hover:text-gray-200" to="/myGameParties"> Game parties</router-link></li>
                        <li v-if="isAuth"> <router-link class="hover:text-gray-200" to="/friends">Friends</router-link></li>
                        <li v-if="isAuth"> <router-link class="hover:text-gray-200" to="/players">Players</router-link></li>
                        <li v-if="isAuth"> <router-link class="hover:text-gray-200" to="/gamePlaces">GamePlaces</router-link></li>
                    </ul>
      
                <div class="hidden md:flex items-right space-x-5 ">
                    <router-link v-if="!isAuth" class="hover:text-gray-200" to="/login"> Sign in</router-link>

                    <router-link v-if="!isAuth" class="hover:text-gray-200" to="/register"> Sign up</router-link>
                    <router-link v-if="isAuth" class="hover:text-gray-200" @click="logout" to="/">Logout</router-link>
                    <router-link class="flex items-center hover:text-gray-200" to="/myAccount">
                        <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 hover:text-gray-200" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5.121 17.804A13.937 13.937 0 0112 16c2.5 0 4.847.655 6.879 1.804M15 10a3 3 0 11-6 0 3 3 0 016 0zm6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
                        </svg>
                        {{userName}}

                    </router-link>
                </div>
       
            </div>
         
            <a class="navbar-burger self-center mr-12 xl:hidden" href="#">
                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 hover:text-gray-200" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
                </svg>
            </a>
        </nav>

    </section>

</template>

<script>
    import AccountService from "../services/AccountService";


    export default {
        name: "AppHeader",
        data() {
            return {
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