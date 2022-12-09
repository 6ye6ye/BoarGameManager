<template>
    <div class="modal-mask">
        <div class="modal-wrapper">
            <div class="modal-container">
        
             
                <button class="modal-default-button button-close" @click="$emit('close')">
                    x
                </button>
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
        padding:20px 0px 20px 0px;
        margin-bottom:20px;
        width: 100%;
        height: 100%;
        display: flex;
        justify-content:center;
       
        overflow: auto;
        background-color: rgba(0, 0, 0, 0.5);
        transition: opacity 0.3s ease;
    }

    .modal-wrapper {
        display: flex;
        flex-direction: column;
        vertical-align: middle;
    }

    .modal-container {
        width: 600px;
        margin: 0px auto;
        padding: 10px ;
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
       margin-top:10px;
    }

    .button-close{
        margin:0 auto;
    }
</style>