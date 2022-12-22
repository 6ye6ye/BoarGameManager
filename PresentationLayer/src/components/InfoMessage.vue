<template>
    <div v-show="message!=''" class="p-4 mb-4 text-white shadow-md text-bold bg-blue-200 border-2 border-white rounded-lg dark:bg-red-200 dark:text-red-800" role="alert">
        {{message}}
    </div>
</template>

<script>

    export default {
        name: 'LoginView',
        props: ['message'],

    }
</script>
