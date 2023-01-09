<template>
    <form ref="form" class="col-sm" @submit.prevent="editGameRole" method="post">
        <label class="block">
            <span class=" text-gray-700">Game role: </span>
            <input type="text"
                   placeholder="Input name"
                   class="block pl-4 w-full  border-gray-200 rounded-md border
                   focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   v-model="role.name"
                   minlength="1" maxlength="50" required />
        </label>
        <ErrorMessage :message="errorMessage" class="mt-2"></ErrorMessage>
        <button type="submit"
                class="mt-2 w-full px-4 py-2 text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
            Save
        </button>
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
