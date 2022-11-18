<template>
    <div class="form-control border bg-light">
        <h2>Game place</h2>
        <div class="row">
            <label class="control-label">Name:</label>
            <input type="text" v-model="name" class="form-control" />
            <button v-on:click="addGamePlace()" type="button" class="btn btn-primary">Add</button>
        </div>
    </div>
</template>

<script>


    import GamePlaceService from "../../services/GamePlaceService";

    export default {
        name: 'AddGamePlace',
        data() {
            return {
                name: ""
            }
        },

        methods: {

            addGamePlace: function () {
                GamePlaceService.AddGamePlace(this.name)
                    .then(response => {
                        console.log(response.data)
                        this.$emit('close');
                        this.$emit('get-user-game-places');
                    })
                    .catch(e => {
                        console.log(e);
                    });

            },

        }
    }

</script>

<style lang="scss" scoped>
</style>
