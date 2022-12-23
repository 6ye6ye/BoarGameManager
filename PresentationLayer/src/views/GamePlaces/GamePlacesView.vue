<template>
    <div class="w-full">

        <ModalWindow v-if="isModalAddVisible" @close="closeAddModal">
            <template v-slot:title>
                <h5>New game place</h5>
            </template>
            <template v-slot:body>
                <AddGamePlaceView @close="closeAddModal" @get-game-places="getGamePlaces"></AddGamePlaceView>
            </template>
        </ModalWindow>


        <ModalWindow v-if="isModalEditVisible" @close="closeEditModal">
            <template v-slot:body>
                <EditGamePlaceView :gamePlaceId="currentId" @close="closeEditModal" @get-game-places="getGamePlaces"></EditGamePlaceView>
            </template>
        </ModalWindow>

        <p>{{errorMessage}}</p>
        <div class="mb-6">
            <div class="relative flex justify-end z-0 ">
                <button v-on:click="showAddModal"
                        type="button"
                        class="bg-green-500 shadow-md text-white px-4 py-2  hover:bg-green-400 focus:outline-none">
                    add
                </button>
            </div>
            <div class="relative bg-white shadow-md rounded  z-40" v-if="gamePlaces.length>0">
                <table class="min-w-max w-full table-auto">
                    <thead>
                        <tr class="bg-blue-400 text-white uppercase  leading-normal">
                            <th class="py-3 px-2 text-center">Name</th>
                            <th class="py-3 px-2 text-center"></th>
                        </tr>
                    </thead>
                    <tbody class="text-gray-600 ">
                        <tr v-for="item in gamePlaces"
                            :key="item.Id"
                            class="border-b border-gray-200 hover:bg-gray-100">
                            <td class="py-3 px-2 text-center whitespace-nowrap">{{item.name }}</td>
                            <td class="py-3 px-2 text-center">
                                <div class="flex item-center justify-center">
                                    <div v-on:click="showEditModal(item.id)"
                                         class="w-6 mx-2 transform hover:text-purple-500 hover:scale-110">
                                        <svg xmlns="http://www.w3.org/2000/svg" w-7 h-7 viewBox="0 0 24 24" fill="none" stroke="currentColor"
                                             stroke-linecap="round" stroke-width="2" stroke-linejoin="round">
                                            <polygon points="16 3 21 8 8 21 3 21 3 16 16 3"></polygon>
                                        </svg>
                                    </div>

                                    <div v-on:click="goToDelete(item.id)"
                                         class="w-6 mx-2 transform hover:text-purple-500 hover:scale-110">
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
                No created game places
            </p>
        </div>
    </div>
</template>

<script>

    import AddGamePlaceView from "../GamePlaces/AddGamePlace.vue";
    import EditGamePlaceView from "../GamePlaces/EditGamePlace.vue";
    import GamePlaceService from "../../services/GamePlaceService";
    export default {
        name: 'GamePlacesView',
        data() {
            return {
                isModalVisible: false,
                errorMessage: '',
                gamePlaces: [],
                isModalAddVisible: false,
                isModalEditVisible: false,
                currentId: '',
            };
        },
        computed: {
            url(id) {
                return 'gamePlace' + id;
            }
        },

        components: {

            AddGamePlaceView,
            EditGamePlaceView
        },
        created() {
            this.getGamePlaces();
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
            getGamePlaces() {
                GamePlaceService.GetCurrentUserGamePlaces().then(response => {
                    this.gamePlaces = response.data;
                })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },
            goToDelete(id) {
                GamePlaceService.DeleteGamePlace(id).then(response => {
                    if (response.status == 200) {
                        let i = this.gamePlaces.map(item => item.id).indexOf(id)
                        this.gamePlaces.splice(i, 1)
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
