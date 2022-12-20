<template>
    <AppHeader />
    <div id="app">
        <router-view></router-view>
    </div>
</template>

<script>
    import AppHeader from './views/AppHeader.vue'
    export default {
        name: 'app',
        components: {
            AppHeader
        },
    };
</script>

<style>
    body {
        height: 100%;
    }

    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 30px;
    }

    table {
        margin-bottom: 0px;
        background-color: white
    }

    .filter {
        border: 1px solid;
        background-color: #edededd3;
    }

        .filter.flex {
            display: flex;
            justify-content: flex-start;
            align-items: flex-end;
            flex-wrap: wrap;
            width: 100%;
        }

    input {
        border: 2px solid currentcolor;
    }

        input:invalid {
            border: 2px double red;
        }

    .container {
        padding: 0px 0px 20px 0px;
        height: auto !important;
        margin-bottom: 30px;
    }

    .container-white {
        background-color: white;
        box-shadow: -1px -1px 35px 5px rgba(18,18,18,0.07);
        -webkit-box-shadow: -1px -1px 35px 5px rgba(18,18,18,0.07);
        -moz-box-shadow: -1px -1px 35px 5px rgba(18,18,18,0.07);
        height: 100%;
        margin-bottom: 30px;
        padding-bottom: 20px;
    }

    .m-rl-20 {
        margin: 0 20px 0 20px;
    }

    .m-tb-20 {
        margin: 20px 0 20px 0;
    }

    .row {
        margin-left: 0px;
        margin-right: 0px;
    }

    .icon {
        width: 30px;
        height: 30px;
    }

    .title {
        color: #4f4f4f;
        background-color: #E0E0E0;
        margin-bottom: 20px;
    }

    .extended-title {
        color: #757575;
        margin-top: 20px;
        background-color: #E0E0E0;
    }

    .sidenav {
        height: 100%;
        width: 20%;
        margin-left: 20px;
        margin-right: 20px;
        display: inline;
        overflow-x: hidden;
        padding-top: 20px;
    }

    .user-info {
        height: 100%;
        max-width: 30%;
        margin-left: 20px;
        margin-right: 20px;
        display: inline;
        overflow-x: hidden;
    }

    .text-justify {
        text-align: justify;
    }

    .input-container input, .input-container button {
        margin-bottom: 10px;
        border: 1px solid;
    }
</style>
