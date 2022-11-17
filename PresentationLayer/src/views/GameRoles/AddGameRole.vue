<template>
    <div class="post">
        <div class="row ">
            <div class="col-md-4 mx-auto">
                <div class="form-group">
                    <label class="form-label">Name</label>
                    <input type="text" v-model="role.name" class="form-control" />

                    <div class="form-group">
                        <button v-on:click="addGameRole()" type="button" class="btn btn-success ">Confirm</button>
                    </div>
                </div>
            </div>
            </div>
    </div>
</template>

<script>


    import GameRolesService from "../../services/GameRolesService";


    export default {
        name: 'AddGameRoleView',
        data() {
            return {
                role: {
                    gameId: this.$route.params.id * 1,
                    name: ''
                }
            }
        },
        methods: {
            addGameRole: function () {
                GameRolesService.AddGameRole(this.role)
                //GamesService.AddGame(this.game)
                    .then(response => {
                        console.log(response.data);
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
