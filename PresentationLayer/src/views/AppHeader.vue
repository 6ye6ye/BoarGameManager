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
            <a class="nav-link" href="/">
                Logout
            </a>

        </div>

    </nav>
</template>

<script>

     export default {
        name: "AppHeader",
            data() {
            return {};
        },
        methods: {

        },
        components: { },
    };

</script>
