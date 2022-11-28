<template>
    <div class="form-control border bg-light">
        <h2>Game place</h2>
        <div class="row">
            <label class="control-label">Name:</label>
            <input type="text" v-model="name" class="form-control" />
            <button v-on:click="addGamePlace()" type="button" class="btn btn-primary">Add</button>
        </div>
        <ErrorMessage :errorMessage="errorMessage" />
    </div>
</template>

<script>
    import GamePlaceService from "../../services/GamePlaceService";
    import ErrorMessage from "../ErrorMessage.vue";
    export default {
        name: 'AddGamePlace',
        emits: ['close', 'get-game-places'],
        data() {
            return {
                name: '',
                errorMessage:''
            }
        },
        components: {
            ErrorMessage
        },
        methods: {
            addGamePlace: function () {
                GamePlaceService.AddGamePlace(this.name)
                    .then(response => {
                        console.log(response.data)
                        this.$emit('close');
                        this.$emit('get-game-places');
                    })
                    .catch(e => {

                        if (e.status == 400)
                            this.errorMessage = "Not valid input"
                        else

                            this.errorMessage = e.response.data;
                    });

            },
        }
    }
</script>

<style lang="scss" scoped>
</style>
