<template>
    <div class="h-screen bg-main flex flex-col">
        <AppHeader />
        <div id="app" bf class="container  mt-6 grow flex w-full bg-min-w-screenmy-6 items-start justify-center  font-sans ">
            <router-view></router-view>
        </div>
        <AppFooter class="shrink"  />
    </div>
</template>

<script>
    import AppHeader from './views/AppHeader.vue'
    import AppFooter from './views/AppFooter.vue'
    import { useRouter } from "vue-router";
    export default {
        name: 'app',
        components: {
            AppHeader,
            AppFooter
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
    .vue-star-rating {
        flex-wrap: wrap;
    }
</style>
