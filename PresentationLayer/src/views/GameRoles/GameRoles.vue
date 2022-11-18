<template>
    <h3> Game roles</h3>
    <table class="table">
        <thead>
            <tr>
                <th>Name</th>
                <th></th>
            </tr>
        </thead>
        <tbody>

            <tr v-for="role in gameRoles" :key="role.Id">
                <td> {{role.name}}</td>
                <td> <button v-on:click="goToDelete(role.id)" type="button" class="btn btn-danger">Delete</button></td>
            </tr>
        </tbody>
    </table>

    <div v-on:click="seen = !seen" class="control">
        <button class="btn btn-primary">Show add window</button>
    </div>
    <div v-if="seen">
        <AddGameRole />
    </div>
</template>

<script>
    import AddGameRole from "./AddGameRole.vue";
    import GameRolesService from "../../services/GameRolesService";
    export default {
        name: 'GamesRoles',
        data() {
            return {
                gameId: this.$route.params.id.toString(),
                seen: false,
                gameRoles: [],
            };
        },
        created() {
            this.getGameRoles();
        },
        components: {
            AddGameRole
        },
        methods: {
            getGameRoles() {
                GameRolesService.GetGameRolesByGame(this.gameId).then(response => {
                    this.gameRoles = response.data;
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            //},
            //goToAdd() {
            //    this.$router.push({ name: 'AddGameView' })
            //},
            //goToDetails(id) {
            //    this.$router.push({ name: 'GameView',params: { id: id } })
            //},
            goToDelete(id) {
                GameRolesService.DeleteGameRole(id).then(response => {
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
        },
    }
</script>

<style lang="scss" scoped>
</style>
