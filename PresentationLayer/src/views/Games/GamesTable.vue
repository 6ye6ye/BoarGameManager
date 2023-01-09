<template>
    <div class="d-flex">
        <div class="container ">

            <ModalWindow v-if="isModalEditVisible" @close="closeEditModal">
                <template v-slot:title>
                    <h5>Edit game</h5>
                </template>
                <template v-slot:body>
                    <EditGameView :gameId="currentId" @get-games="getGames" @close="closeEditModal"></EditGameView>
                </template>
            </ModalWindow>
            <div class="bg-white shadow-md rounded my-6">
                <table class=" w-full table-auto">
                    <thead>
                        <tr class="bg-blue-400 text-white leading-normal">
                            <th class="py-3 px-2 text-left">Image</th>
                            <th class="py-3 px-2 text-left">Name </th>
                            <th class="py-3 px-2 text-left">NameRu </th>
                            <th class="py-3 px-2 text-left">NameEng </th>
                            <th class="py-3 px-2 text-left">Release Year</th>
                            <th class="py-3 px-2 text-left">Players</th>
                            <th class="py-3 px-2 text-left">Party time</th>
                            <th class="py-3 px-2 text-left"> Min age</th>
                            <th class="py-3 px-2 text-left">Game info Short</th>
                            <th class="py-3 px-2 text-left"></th>
                        </tr>
                    </thead>
                    <tbody class="text-gray-600">
                        <tr v-for="item in games" :key="item.id"
                            class="border-b border-gray-200 hover:bg-gray-100">
                            <td class="py-3 px-2  whitespace-nowrap"><img v-bind:src="item.image"></td>
                            <td class="py-3 px-2 text-left">{{item.name }}</td>
                            <td class="py-3 px-2 text-left">{{item.nameRu}}</td>
                            <td class="py-3 px-2 text-left">{{item.nameEng}}</td>
                            <td class="py-3 px-2 text-left">{{item.releaseYear}}</td>
                            <td class="py-3 px-2 text-left">{{item.playersMinCount }}-{{item.playersMaxCount }}</td>
                            <td class="py-3 px-2 text-left">{{item.minPartyTime }}-{{item.maxPartyTime }} </td>
                            <td class="py-3 px-2 text-left">{{item.minAge }}</td>
                            <td class="py-3 px-2 text-left">{{item.gameInfoShort }}</td>
                            <td class="py-3 px-2 text-center">
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
        </div>
    </div>
</template>

<script>

    import EditGameView from "../Games/EditGameView.vue";
    import GamesService from "../../services/GameService";
    export default {
        name: 'GamesView',
        props: ['games'],
        data() {
            return {
                isModalEditVisible: false,
                currentId: '',
            };
        },

        components: {

            EditGameView,
        },

        methods: {
            showEditModal(id) {
                this.currentId = id;
                this.isModalEditVisible = true;
            },
            closeEditModal() {
                this.isModalEditVisible = false;
            },

            goToDelete(id) {
                GamesService.Delete(id).then(response => {
                    if (response.status == 200) {
                        let i = this.games.map(item => item.id).indexOf(id)
                        this.games.splice(i, 1)
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
