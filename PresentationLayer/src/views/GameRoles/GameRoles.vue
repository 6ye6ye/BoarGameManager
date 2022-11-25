<template>
    <h3> Game roles</h3>
    <button v-if="isAuth&&isAdmin" type="button" class="btn btn-primary" @click="showModal">+</button>

    <ModalWindow v-show="isModalVisible" @close="closeModal">
        <template v-slot:body>
            <AddGameRole @close="closeModal" @get-game-roles="getGameRoles"></AddGameRole>
        </template>
    </ModalWindow>

    <table class="table" v-if="!gameRoles.length==0">
        <thead>
            <tr>
                <th>Name</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="role in gameRoles" :key="role.Id">
                <td> {{role.name}}</td>
                <td v-show="isAdmin"> <button v-on:click="goToDelete(role.id)" type="button" class="btn btn-danger">Delete</button></td>
            </tr>
        </tbody>
    </table>
    <p v-if="gameRoles.length==0">- No game roles -</p>
</template>

<script>
    import AddGameRole from "./AddGameRole.vue";
    import GameRolesService from "../../services/GameRolesService";
    import ModalWindow from "../ModalWindow.vue";
    export default {
        name: 'GamesRoles',
        data() {
            return {
                gameId: this.$route.params.id.toString(),

                gameRoles: [],
                isAuth: localStorage.getItem('isAuth'),
                isAdmin: localStorage.role == 'Admin',
                isModalVisible: false,
            };
        },
        created() {
            this.getGameRoles();
            this.isAuth = localStorage.isAuth;
            this.isAdmin = localStorage.getItem('role') === "Admin"
        },
        components: {
            AddGameRole,
            ModalWindow
        },
        methods: {
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
            getGameRoles() {
                GameRolesService.GetGameRolesByGame(this.gameId).then(response => {
                    this.gameRoles = response.data;
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToDelete(id) {
                GameRolesService.DeleteGameRole(id).then(response => {
                    console.log(response.data);
                    let i = this.gameRoles.map(item => item.id).indexOf(id) // find index of your object
                    this.gameRoles.splice(i, 1)
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
