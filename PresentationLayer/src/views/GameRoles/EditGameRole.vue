<template>
    <form ref="form" class="col-sm" @submit.prevent="editGameRole" method="post">
        <div class="row ">
            <div class=" mx-auto">
                <h2>Game role</h2>
                <input placeholder="Input role name" type="text" v-model="role.name" minlength="1" maxlength="50" class="form-control" required />
                <button type="submit" class="button-submit btn btn-success ">Save</button>
            </div>
            <p class="text-danger"> {{errorMessage}}</p>
        </div>
    </form>
</template>

<script>
    import GameRolesService from "../../services/GameRolesService";
    export default {
        name: 'EditGameRoleView',
        emits: ['close', 'get-game-roles'],
        props: ['gameRoleId'],
        data() {
            return {
                errorMessage:'',
                role: {
                    id: this.gameRoleId,
                    gameId: '',
                    name: ''
                }
            }
        },
        computed: {
            isValid() {
                return this.role.name 
            }
        },
        created() {
            this.getGameRole();
        },
        methods: {
            async getGameRole() {
                GameRolesService.GetGameRoleById(this.gameRoleId).then(response => {
                    this.role = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            async editGameRole() {
                if (!this.isValid) return false
                GameRolesService.Edit(this.role)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-game-roles');
                            return { ok: true }
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
