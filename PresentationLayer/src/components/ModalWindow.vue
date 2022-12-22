<template>
    <div class="modal-mask">
        <div class="flex flex-column items-center">
            <div class=" w-full max-w-md p-6 bg-white rounded-md shadow-md">
                <div class="modal-header flex  items-center justify-between  border-b border-gray-200 rounded-t-md pb-2">
                    <img class="icon w-7 h-7" :src="require('/src/assets/icon-main.png')" />
                   
                    <h5 class="text-xl font-medium leading-normal text-gray-800">
                            <slot name="title" />
                    </h5>
                    <button type="button" @click="$emit('close')"
                            class="btn-close box-content w-4 h-4 p-1 text-black border-none rounded-none opacity-50 focus:shadow-none focus:outline-none focus:opacity-100 hover:text-black hover:opacity-75 hover:no-underline"
                            data-bs-dismiss="modal" aria-label="Close">x</button>
                </div>
           
                <hr/>
                <div class="modal-body">
                    <slot name="body" />
                </div>
                <div class="mt-2">
                    <slot name="button" />
                </div>
            </div>
        </div>
    </div>


</template>



<script>
    export default {
        props:['title'],
        methods: {
            close() {
                this.$emit('close');
            },
        },
    };
</script>
<style>

    .modal-mask {
        position: fixed;
        z-index: 9998;
        top: 0;
        left: 0;
        padding: 20px 0px 20px 0px;
        margin-bottom: 20px;
        width: 100%;
        height: 100%;
      
        justify-content: center;
        overflow: auto;
        background-color: rgba(0, 0, 0, 0.5);
        transition: opacity 0.3s ease;
    }

    /*.modal-wrapper {
        display: flex;
        flex-direction: column;
        vertical-align: middle;
    }

    .modal-container {
        width: 600px;
        margin: 0px auto;
        padding: 10px;
        background-color: #fff;
        border-radius: 2px;
        box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
        transition: all 0.3s ease;
        font-family: Helvetica, Arial, sans-serif;
    }

    .modal-header h3 {
        margin-top: 0;
        color: #42b983;
    }

    .modal-body {
        margin: 20px 0;
    }

    .modal-default-button {
        float: right;
    }

    .button-submit {
        margin-top: 10px;
    }

    .button-close {
        margin: 0 auto;
    }*/
</style>