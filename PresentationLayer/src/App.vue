<template>
    <AppHeader />
    <div id="app" class="container  min-w-screen flex my-6 items-center justify-center  font-sans overflow-hidden">
            <router-view></router-view>
    </div>
</template>

<script>
    import AppHeader from './views/AppHeader.vue'
    import { useRouter } from "vue-router";


    export default {
        name: 'app',
        components: {
            AppHeader
        },
        data() {
            return {
                defaultLayout: "default",
                currentRoute: useRouter()
            }
        },

      
        computed: {
            layout() {
                return `${this.currentRoute.value.meta.layout || this.defaultLayout}-layout`
            }

        }
    };
</script>

<style>
    .vue-star-rating{
        flex-wrap:wrap;
    } 
</style>
<!--<style>

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
</style>-->