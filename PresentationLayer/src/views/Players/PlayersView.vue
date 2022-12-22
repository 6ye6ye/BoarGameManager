<template>

    <div class="w-full  text-gray-700">

        <ModalWindow v-if="isModalAddVisible" @close="closeAddModal">
            <template v-slot:title>
                <h5>New player</h5>
            </template>
            <template v-slot:body>
                <AddPlayerView @close="closeAddModal" @get-players="getCreatedPlayers"></AddPlayerView>
            </template>
        </ModalWindow>

        <ModalWindow v-if="isModalEditVisible" @close="closeEditModal">
            <template v-slot:title>
                <h5>Edit player</h5>
            </template>
            <template v-slot:body>
                <EditPlayerView :playerId="currentId" @get-players="getCreatedPlayers" @close="closeEditModal"></EditPlayerView>
            </template>
        </ModalWindow>
        <ErrorMessage :message="errorMessage"></ErrorMessage>

        <!-- Table -->
        <div class="mb-6">
            <div class="relative flex justify-end z-0 ">
                <button v-on:click="showAddModal"
                        type="button"
                        class="bg-green-500 shadow-md text-white px-4 py-2  hover:bg-green-400 focus:outline-none">
                    add
                </button>
            </div>
            <div class="relative bg-white shadow-md rounded z-40" v-if="players.length>0">
                <table class="min-w-max w-full table-auto">
                    <thead>
                        <tr class="bg-blue-400 text-white uppercase  leading-normal">
                            <th class="py-3 px-6 text-left">Name</th>
                            <th class="py-3 px-6 text-left"></th>

                        </tr>
                    </thead>
                    <tbody class="text-gray-600 ">
                        <tr v-for="item in players"
                            :key="item.Id"
                            class="border-b border-gray-200 hover:bg-gray-100">
                            <td class="py-3 px-6 text-left whitespace-nowrap">{{item.name }}</td>
                            <td class="py-3 px-6 text-center">
                                <div class="flex item-center justify-center">
                                    <div v-on:click="showEditModal(item.id)"
                                         class="w-6 mr-2 transform hover:text-purple-500 hover:scale-110">
                                        <svg xmlns="http://www.w3.org/2000/svg" w-7 h-7 viewBox="0 0 24 24" fill="none" stroke="currentColor"
                                             stroke-linecap="round" stroke-width="2" stroke-linejoin="round">
                                            <polygon points="16 3 21 8 8 21 3 21 3 16 16 3"></polygon>
                                        </svg>

                                    </div>

                                    <div v-on:click="goToDelete(item.id)"
                                         class="w-6 mr-2 transform hover:text-purple-500 hover:scale-110">
                                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                                        </svg>
                                    </div>
                                </div>
                            </td>

                        </tr>
                    </tbody>
                </table>
            </div>
            <p v-else>
                No created players
            </p>
        </div>
    </div>
</template>

<script>

    import AddPlayerView from "../Players/AddPlayerView.vue";
    import EditPlayerView from "../Players/EditPlayerView.vue";
    import PlayersService from "../../services/PlayersService";
    export default {
        name: 'PlayersView',
        data() {
            return {
                isModalAddVisible: false,
                isModalEditVisible: false,
                errorMessage: '',
                players: [],
                currentId: '',
            };
        },
        computed: {
            url(id) {
                return 'players' + id;
            }
        },
        components: {

            AddPlayerView,
            EditPlayerView
        },
        created() {
            this.getCreatedPlayers();
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
            getCreatedPlayers() {
                PlayersService.GetCreatedPlayers().then(response => {
                    this.players = response.data;
                })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },
            goToDelete(id) {
                PlayersService.DeletePlayer(id).then(response => {
                    if (response.status == 200) {
                        let i = this.players.map(item => item.id).indexOf(id)
                        this.players.splice(i, 1)
                    }
                })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },
        },
    }
</script>

<style lang="scss" scoped>
</style>
