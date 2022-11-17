<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid .navbar">
            <a class="navbar-brand" href="/">Настольные игры</a>

            <a class="nav-link" href="/">
                Games
            </a>
            <a class="nav-link" href="/myGameParties">
                Game parties
            </a>
            <a class="nav-link" href="/friends">
                Friends
            </a>
            <a class="nav-link" href="/login">
                Sing in
            </a>
            <a class="nav-link" href="/register">
                Sing up
            </a>
            <a class="nav-link" @click="logout" href="/">
                Logout
            </a>

        </div>

    </nav>
</template>

<script>
    import AccountService from "../services/AccountService";

     export default {
        name: "AppHeader",
            data() {
            return {};
        },
        methods: {
            logout: function () {
                AccountService.logout().then(response => {
                    switch (response.status) {
                        case (200):
                            {
                                this.$router.push({ name: 'GamesView' })

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
        components: { },
    };

</script>
