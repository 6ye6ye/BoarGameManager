<template>
    <div class="row ">
        <div class="col-md-4 mx-auto">
            <label class="form-label">Name</label>
            <input type="text" v-model="role.name" class="form-control" />
            <div class="form-group">
                <button v-on:click="addGameRole()" type="button" class="btn btn-success ">Add</button>
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
                    gameId: this.$route.params.id,
                    name: ''
                }
            }
        },
        methods: {
            addGameRole: function () {
                GameRolesService.AddGameRole(this.role)
                    .then(response => {
                        console.log(response.data);
                        this.$emit('close');
                        this.$emit('get-game-roles');
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
