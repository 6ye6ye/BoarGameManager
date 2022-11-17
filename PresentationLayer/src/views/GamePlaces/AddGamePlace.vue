<template>
    <div class="form-control border bg-light">
        <label class="control-label">Add game place window</label>
        <div class="row">
            <label class="control-label">Name</label>
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
                name:""
            }
        },

        methods: {
          
            addGamePlace: function () {
                GamePlaceService.AddGamePlace(this.name)
                    .then(response => {
                        console.log(response.data);
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
