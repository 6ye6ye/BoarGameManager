<template>
    <AppHeader />
    <div  id="app">
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
        height:100%;
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
        background-color: white
    }
    .filter {
        border: 1px solid;
        background-color: #edededd3;
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
        padding: 0px;
        height: 100%;
        margin-bottom: 30px;
    }
    .row {
        margin-left:0px;
        margin-right:0px;
    }
    
</style>
