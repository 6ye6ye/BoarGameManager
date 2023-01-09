<template>
    <div v-show="message!=''"
         class="p-2 my-2 text-red-700 bg-red-100" role="alert">
        <svg fill="#ffffff" class="w-6 h-6 absolute" width="64px" height="64px" viewBox="-1.7 0 20.4 20.4" xmlns="http://www.w3.org/2000/svg"  stroke="#ffffff"><g id="SVGRepo_bgCarrier" stroke-width="0"></g><g id="SVGRepo_iconCarrier"><path d="M16.417 10.283A7.917 7.917 0 1 1 8.5 2.366a7.916 7.916 0 0 1 7.917 7.917zm-6.804.01 3.032-3.033a.792.792 0 0 0-1.12-1.12L8.494 9.173 5.46 6.14a.792.792 0 0 0-1.12 1.12l3.034 3.033-3.033 3.033a.792.792 0 0 0 1.12 1.119l3.032-3.033 3.033 3.033a.792.792 0 0 0 1.12-1.12z"></path></g></svg>
        <p class="pl-6">{{message}}</p>
    </div>
</template>

<script>
    export default {
        props: ['message'],
    }
</script>
