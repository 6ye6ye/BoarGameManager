<template>
    <AppHeader />

    <div class="container" id="app">
        <router-view></router-view>
    </div>
</template>

<script>
 //   import GamesPage from '../views/GamesView.vue'
    import AppHeader from './views/AppHeader.vue'
    export default {
        name: 'app',
        components: {
            AppHeader
        },
    };

</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
