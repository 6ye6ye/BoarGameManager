<template>
    <div class="modal-mask">
        <div class="modal-wrapper">
            <div class="modal-container">
                <div class="modal-body">
                    <slot name="body" />
                </div>
                <div>
                    <button class="modal-default-button" @click="$emit('close')">
                        Close
                    </button>
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
        position: absolute;
        z-index: 9998;
        top: 0;
        left: 0;
        padding:20px 0px 20px 0px;
        width: 100%;
        height: 100%;
        display: table;
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
        padding: 20px 30px;
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

    .modal-enter {
        opacity: 0;
    }

    .modal-leave-active {
        opacity: 0;
    }

        .modal-enter .modal-container,
        .modal-leave-active .modal-container {
            -webkit-transform: scale(1.1);
            transform: scale(1.1);
        }
</style>