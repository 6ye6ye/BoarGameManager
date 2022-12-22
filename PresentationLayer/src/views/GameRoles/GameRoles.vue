<template>
    <ModalWindow v-show="isModalAddVisible" @close="closeAddModal">
        <template v-slot:title>
            <h5>New game role</h5>
        </template>
        <template v-slot:body>
            <AddGameRole @close="closeAddModal" @get-game-roles="getGameRoles"></AddGameRole>
        </template>
    </ModalWindow>

    <ModalWindow v-if="isModalEditVisible" @close="closeEditModal">
        <template v-slot:title>
            <h5>Edit game role</h5>
        </template>
        <template v-slot:body>
            <EditGameRole :gameRoleId="currentId" @get-game-roles="getGameRoles" @close="closeEditModal"></EditGameRole>
        </template>
    </ModalWindow>

    <div class="extended-title">
        <p class="d-inline"> Game roles</p>
        <img class="icon" v-if="isAuth&&isAdmin" type="button" @click="showAddModal" :src="require('/src/assets/icon-add.png')" />
    </div>
    <div class="row justify-content-center ">
        <div class="col-md-4">

            <ul v-if="!gameRoles.length==0">
                <li v-for="role in gameRoles" :key="role.Id">
                    {{role.name}}
                    <img class="icon" v-if="isAdmin" @click="showEditModal(role.id)" type="button" :src="require('/src/assets/icon-edit.png')" />
                    <img class="icon" v-if="isAdmin" @click="goToDelete(role.id)" type="button" :src="require('/src/assets/icon-remove.png')" />
                </li>
            </ul>
            <p v-if="gameRoles.length==0">- No game roles -</p>
        </div>
    </div>
</template>

<script>
    import AddGameRole from "./AddGameRole.vue";
    import EditGameRole from "./EditGameRole.vue";
    import GameRolesService from "../../services/GameRolesService";
    export default {
        name: 'GamesRoles',
        data() {
            return {
                gameId: this.$route.params.id.toString(),
                gameRoles: [],
                isAuth: localStorage.getItem('isAuth'),
                isAdmin: localStorage.role == 'Admin',
                isModalAddVisible: false,
                isModalEditVisible: false,
                currentId: '',
            };
        },
        created() {
            this.getGameRoles();
            this.isAuth = localStorage.isAuth;
            this.isAdmin = localStorage.getItem('role') === "Admin"
        },
        components: {
            AddGameRole,
            EditGameRole
        },
        methods: {
            showAddModal() {
                this.isModalAddVisible = true;
            },
            closeAddModal() {
                this.isModalAddVisible = false;
            },
            showEditModal(id) {
                this.currentId = id;
                this.isModalEditVisible = true;
            },
            closeEditModal() {
                this.isModalEditVisible = false;
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
