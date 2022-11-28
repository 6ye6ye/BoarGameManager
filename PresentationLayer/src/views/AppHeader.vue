<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid .navbar">
            <router-link class="navbar-brand" to="/">BoardGames</router-link>
            <router-link class="nav-link" to="/">Games</router-link>
            <router-link class="nav-link" v-show="isAdmin&&isAuth" to="/users">Users</router-link>
            <router-link class="nav-link" v-show="isAuth" to="/myGameParties"> Game parties</router-link>
            <router-link class="nav-link" v-show="isAuth" to="/friends">Friends</router-link>
            <router-link class="nav-link" v-show="!isAuth" to="/login"> Sing in</router-link>
            <router-link class="nav-link" v-show="!isAuth" to="/register"> Sing up</router-link>
            <router-link class="nav-link" v-show="isAuth" @click="logout" to="/">Logout</router-link>
            <router-link class="nav-link" v-show="isAuth"  to="/myAccount">  {{userName}}</router-link>
        </div>
    </nav>
</template>

<script>
    import AccountService from "../services/AccountService";
 
    export default {
        name: "AppHeader",
        data() {
            return {
                isAuth: false,
                isAdmin: false,
                userName: ''
            };
        },
        created: function () {
            this.isAdmin = localStorage.getItem('role') === "Admin"
            this.userName = localStorage.getItem('userName');
            this.isAuth = localStorage.getItem('isAuth')=='true';
        },
      
        methods: {
            logout: function () {
                AccountService.logout().then(response => {
                    console.log(response);

                    console.log("logout");
                    AccountService.logout();
                    switch (response.status) {
                        case (200):
                            {
                                localStorage.setItem('userName', '');
                                localStorage.setItem('role', '');
                                localStorage.setItem('isAuth', 'false');
                                this.isAuth=false
                                this.$router.push('/login')
                                return { ok: true }
                            }
                        case (400):
                            {
                                this.errorMessage = response;
                                return { ok: false }
                            }
                    }
                    console.log(response.data);
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
