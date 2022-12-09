<template>
    <ModalWindow v-show="isModalVisible" @close="closeModal">
        <template v-slot:body>
            <AddGameRole @close="closeModal" @get-game-roles="getGameRoles"></AddGameRole>
        </template>
    </ModalWindow>

    <div class="row justify-content-center ">
        <div class="col-md-4">
            <div class="mb-2">
                <h3 class="d-inline"> Game roles</h3>
                <button v-if="isAuth&&isAdmin" type="button" class=" d-inline btn btn-primary" @click="showModal">+</button>
            </div>
            <ul v-if="!gameRoles.length==0">
                <li v-for="role in gameRoles" :key="role.Id">
                    {{role.name}}
                    <img v-if="isAdmin" class="icon" v-on:click="goToDelete(item.id)" type="button" :src="require('/src/assets/icon-remove.png')" />
                </li>
            </ul>
            <p v-if="gameRoles.length==0">- No game roles -</p>
        </div>
    </div>
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
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToDelete(id) {
                GameRolesService.DeleteGameRole(id).then(response => {
                    if (response.status == 200) {
                        let i = this.gameRoles.map(item => item.id).indexOf(id)
                        this.gameRoles.splice(i, 1)
                    }
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
        },
    }
</script>

<style>
</style>
