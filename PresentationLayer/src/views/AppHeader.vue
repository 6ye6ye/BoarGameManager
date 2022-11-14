<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="/">Настольные игры</a>
        <div class="navbar-nav mr-auto">
            <router-link class="nav-link" to="/">
                Games
            </router-link>
            <router-link class="nav-link" to="/login">
                Sing in
            </router-link>
            <router-link class="nav-link" to="/register">
                Sing up
            </router-link>
            <router-link class="nav-link" to="/">
                Logout
            </router-link>
            <router-link class="nav-link" to="/friends">
                Friends
            </router-link>
        </div>

    </nav>
</template>

<script>
     export default {
        name: "AppHeader",
            data() {
            return {};
        },
        methods: { },
        components: { },
    };

</script>
