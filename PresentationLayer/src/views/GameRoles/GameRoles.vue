<template>
    <div class="w-full">
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

        <ul v-if="!gameRoles.length==0"
            class="mt-2 text-gray-700">
            <li v-for="role in gameRoles"
                :key="role.Id"
                class="flex justify-around border-b py-2">
                {{role.name}}
               <div class="flex item-center justify-center">
                    <div v-on:click="showEditModal(role.id)"
                         type="button"
                         class="w-6 mr-2 transform hover:text-purple-500 hover:scale-110">
                        <svg xmlns="http://www.w3.org/2000/svg" w-7 h-7 viewBox="0 0 24 24" fill="none" stroke="currentColor"
                             stroke-linecap="round" stroke-width="2" stroke-linejoin="round">
                            <polygon points="16 3 21 8 8 21 3 21 3 16 16 3"></polygon>
                        </svg>

                    </div>

                    <div v-on:click="goToDelete(role.id)"
                          type="button"
                         class="w-6 mr-2 transform hover:text-purple-500 hover:scale-110">
                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                        </svg>
                    </div>
                </div>


            </li>

        </ul>

        <p class="text-center" v-if="gameRoles.length==0">- No game roles -</p>
        <button v-if="isAuth&&isAdmin"
                @click="showAddModal"
                type="button"
                class="w-full rounded bg-green-500 shadow-md text-white px-4 py-2  hover:bg-green-400 focus:outline-none">
            add
        </button>
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
