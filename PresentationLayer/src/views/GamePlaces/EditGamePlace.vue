<template>
    <form ref="form" class="col-sm" @submit.prevent="editGamePlace" method="post">
        <div class="row ">
            <div class=" mx-auto">
                <h2>Game place</h2>
                <input placeholder="Input  name" type="text" v-model="gamePlace.name" minlength="3" maxlength="50" class="form-control" required />
                <button type="submit" class="button-submit btn btn-primary">Save</button>
                <p class="text-danger"> {{errorMessage}}</p>
            </div>
        </div>
    </form>
</template>

<script>
    import GamePlaceService from "../../services/GamePlaceService";

    export default {
        name: 'EditGamePlace',
        emits: ['close', 'get-game-places'],
        props: ['gamePlaceId'],
        data() {
            return {
                gamePlace: {
                    id: this.gamePlaceId,
                    name: ''
                },
                errorMessage: ''
            }
        },
        computed: {
            isValid() {
                return this.gamePlace.name
            }
        },
        created() {
            this.getGamePlace();
        },
        methods: {
            async getGamePlace() {
                GamePlaceService.GetGamePlaceShortById(this.gamePlaceId).then(response => {
                    if (response.status==200)
                     this.gamePlace = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            async editGamePlace() {
                if (!this.isValid) return false
                GamePlaceService.Edit(this.gamePlace)
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
