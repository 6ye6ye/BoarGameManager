<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid .navbar">
            <a class="navbar-brand" href="/">BoardGames</a>

            <a class="nav-link" href="/">
                Games
            </a>
            <a v-show="isAdmin" class="nav-link" href="/users">
                Users
            </a>
            <a v-show="isAuth" class="nav-link" href="/myGameParties">
                Game parties
            </a>
            <a v-show="isAuth" class="nav-link" href="/friends">
                Friends
            </a>
            <a v-show="!isAuth" class="nav-link" href="/login">
                Sing in
            </a>
            <a v-show="!isAuth" class="nav-link" href="/register">
                Sing up
            </a>
            <a v-show="isAuth" class="nav-link" @click="logout" href="/">
                Logout
            </a>
            <a v-show="isAuth" class="nav-link" href="/myAccount">
                {{userName}}
            </a>
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
            this.isAuth = localStorage.getItem('isAuth');
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
                                this.isAuth = false;
                                localStorage.setItem('userName', '');
                                localStorage.setItem('role', '');
                                localStorage.setItem('isAuth', 'false');
                                //window.location.href = '/';
                                this.$router.replace({ name: 'GamesView' })
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
