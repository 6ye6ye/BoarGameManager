<template>
    <form ref="form" class="col-sm" @submit.prevent="addGameRole" method="post">
        <div class="row ">
            <div class="col-md-4 mx-auto">
                <h2>Game role</h2>
                <hr>
                <label class="form-label">Name</label>
                <input type="text" v-model="role.name" minlength="1" maxlength="50" class="form-control" required />
            </div>
            <hr>
            <button type="submit" class="btn btn-success ">Add</button>
            <p class="text-danger"> {{errorMessage}}</p>
        </div>
    </form>
</template>

<script>
    import GameRolesService from "../../services/GameRolesService";
    export default {
        name: 'AddGameRoleView',
        data() {
            return {
                errorMessage:'',
                role: {
                    gameId: this.$route.params.id,
                    name: ''
                }
            }
        },
        computed: {
            isValid() {
                return this.role.name 
            }
        },
        methods: {
            async addGameRole() {
                if (!this.isValid) return false
                GameRolesService.AddGameRole(this.role)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-game-roles');
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
