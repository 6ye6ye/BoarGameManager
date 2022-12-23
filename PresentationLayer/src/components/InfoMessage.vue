<template>
    <div v-show="message!=''" 
         class="font-mono  p-2 mb-4 text-white text-center shadow-md  text-md
         font-bold bg-blue-300 border-2 border-white 
         rounded-lg dark:bg-red-200 dark:text-red-800" role="alert">
        <p >{{message}}</p>
    </div>
</template>

<script>
    export default {
        props: ['message'],
    }
</script>
