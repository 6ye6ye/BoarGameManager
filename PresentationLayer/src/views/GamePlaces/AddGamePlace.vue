<template>
    <form ref="form" class="col-sm" @submit.prevent="addGamePlace" method="post">

        <div class="form-control border bg-light">
            <h2>Game place</h2>
            <hr>
            <div class="row">
                <label class="control-label">Name:</label>
                <input type="text" v-model="name" minlength="3" maxlength="50" class="form-control" required />
                <!--<button v-on:click="addGamePlace()" type="button" class="btn btn-primary">Add</button>-->
            </div>
            <hr>
            <button type="submit" class="btn btn-primary">Add</button>
            <p class="text-danger"> {{errorMessage}}</p>
        </div>
    </form>
</template>

<script>
    import GamePlaceService from "../../services/GamePlaceService";

    export default {
        name: 'AddGamePlace',
        emits: ['close', 'get-game-places'],
        data() {
            return {
                name: '',
                errorMessage: ''
            }
        },
        computed: {
            isValid() {
                return this.name 
            }
        },
        methods: {
            async addGamePlace() {
                if (!this.isValid) return false
                GamePlaceService.AddGamePlace(this.name)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-game-places');
                        }
                    })
                    .catch(e => {
               
                         this.errorMessage = e.response.data;
                    });
            },
        }
    }
</script>

<style lang="scss" scoped>
</style>
