<template>
    <ModalWindow v-if="isModalVisible" @close="closeAddModal" :title="Test">
        <template v-slot:title>
            <h5>New game party</h5>
        </template>
        <template #body>
            <AddGamePartyView @close="closeAddModal" @get-game-parties="getGameParties"></AddGamePartyView>
        </template>
    </ModalWindow>
    <div class="w-full">
        <div class="bg-white  shadow-md rounded mb-6">
            <!--Filter-->
            <div class="my-2 flex md:flex-row md:flex-nowrap flex-col  items-stretch text-sm">
                <div class="w-full flex relative border">
                    <span class="h-full absolute inset-y-0 left-0 flex items-center pl-2">
                        Name:
                    </span>
                    <input input type="text"
                           v-model="filter.gameName"
                           placeholder="Input name"
                           class="appearance-none
                               block pl-16 pr-6 py-2 w-full bg-white
                               placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-200
                               focus:text-gray-700 focus:outline-none" />
                </div>
                <div class="w-full flex relative border">
                    <span class="h-full absolute inset-y-0 left-0 flex items-center pl-2">
                        From:
                    </span>
                    <input type="date"
                           v-model="filter.startDate"
                           placeholder="Input date"
                           class="appearance-none
                               block pl-12 pr-6 py-2 w-full bg-white
                               placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-200
                               focus:text-gray-700 focus:outline-none" />
                </div>
                <div class="w-full flex relative border">
                    <span class="h-full absolute inset-y-0 left-0 flex items-center pl-2">
                        To:
                    </span>
                    <input type="date"
                           v-model="filter.gamePlaceId"
                           placeholder="Input date"
                           class="appearance-none
                               block pl-8 pr-6 py-2 w-full bg-white
                               placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-200
                               focus:text-gray-700 focus:outline-none" />
                </div>
                <div class="w-full flex flex-row border">
                    <select v-model="filter.gamePlaceId"
                            class=" block  pr-6 py-2 w-full bg-white
                                placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-600 focus:text-gray-700 focus:outline-none">
                        <option value=''>- All game places -</option>
                        <option v-show="gamePlaces.length>0" v-for="gamePlace in gamePlaces" v-bind:key="gamePlace.id" v-bind:value="gamePlace.id"> {{gamePlace.name}}</option>
                    </select>
                </div>
                <div class="w-full flex flex-row border">
                    <select v-model="filter.playerId"
                            class=" block  pr-6 py-2 w-full bg-white
                                placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-600 focus:text-gray-700 focus:outline-none">
                        <option value=''>- All players -</option>
                     
                        <option  v-show="players.length>0" v-for="player in players" v-bind:key="player.id" v-bind:value="player.id"> {{player.name}}</option>
                    </select>
                </div>
                <div class="w-full flex flex-row border">
                    <select v-model="filter.created"
                            class=" block  pr-6 py-2 w-full bg-white
                                placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-600 focus:text-gray-700 focus:outline-none">
                        <option value=''>-  All (created/no) -</option>
                        <option value='true'> Created</option>
                        <option value='false'>No created</option>
                    </select>
                </div>
              
                <span v-on:click="getGamePartiesWithFilters()"
                      class="h-10 px-2 justify-center  bg-green-500 border-1 border-green-800  focus:outline-none hover:bg-green-400 inset-y-0 left-0 flex  items-center ">
                    <svg viewBox="0 0 24 24" class="h-7 lg:w-7 fill-current text-white">
                        <path d="M10 4a6 6 0 100 12 6 6 0 000-12zm-8 6a8 8 0 1114.32 4.906l5.387 5.387a1 1 0 01-1.414 1.414l-5.387-5.387A8 8 0 012 10z">
                        </path>
                    </svg>
                </span>
                <span @click="showAddModal" type="button"
                      class="h-10  font-bold px-2 justify-center text-white bg-green-500 border-1 border-green-800  focus:outline-none hover:bg-green-400 inset-y-0 left-0 flex  items-center ">
                    Add
                </span>
                <!--<div class="align-bottom">
        <img class="icon" type="button" @click="showAddModal" :src="require('/src/assets/icon-add.png')" />
    </div>-->
            </div>
        </div>
        <div class="bg-white shadow-md rounded my-6" >
            <table  class="min-w-max w-full table-auto">
                <thead>
                    <tr class="bg-blue-400 text-white uppercase  leading-normal">
                        <th @click="sort('date')"
                            style="cursor: pointer;"
                            class="py-3 px-2 text-left">Date</th>
                        <th @click="sort('game')"
                            style="cursor: pointer;"
                            class="py-3 px-2 text-left">Game</th>
                        <th @click="sort('gamePlace.name')"
                            style="cursor: pointer;"
                            class="py-3 px-2 text-left">Place</th>
                        <th @click="sort('partyCreatorName')"
                            style="cursor: pointer;"
                            class="py-3 px-2 text-left">Creator</th>
                        <th class="py-3 px-2 text-left"></th>
                    </tr>
                </thead>
                <tbody v-if="gameParties.length!=0" class="text-gray-600 ">
                    <tr v-for="item in gameParties"
                        :key="item.Id"
                        class="border-b border-gray-200 hover:bg-gray-100">
                        <td class="py-3 px-2 text-left whitespace-nowrap">{{item.date }}</td>
                        <td v-if="item.game!=null" class="py-3 px-2 text-left whitespace-nowrap">{{item.game.name}}</td>
                        <td v-else class="py-3 px-2 text-left whitespace-nowrap">deleted</td>
                        <td class="py-3 px-2 text-left whitespace-nowrap">{{item.userGamePlace.name }}</td>
                        <td class="py-3 px-2 text-left whitespace-nowrap">{{item.partyCreatorName }}</td>
                        <td class="py-3 px-2 text-center">
                            <div class="flex item-center justify-center">
                                <div v-on:click="goToDetails(item.id)"
                                     class="w-6 mr-2 transform hover:text-purple-500 hover:scale-110">
                                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
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
</template>  
  
<script>  

    import AddGamePartyView from "../GameParties/AddGameParty.vue";
    import GamePartiesService from "../../services/GamePartiesService";
    import PlayersService from "../../services/PlayersService";
    import GamePlacesService from "../../services/GamePlaceService";
    export default {
        name: 'GamePartiesView',

        data() {
            return {
                isModalVisible: false,
                errorMessage: '',
                gameParties: [],
                gamePlaces: [],
                players: [],
                filter: {
                    gameName: '',
                    startDate: '',
                    endDate: '',
                    gamePlaceId: '',
                    playerId: '',
                    created: '',
                },
                currentSort: 'date',
                currentSortDir: 'desc'
            };
        },
        computed: {
            url(id) {
                return 'gameParty' + id;
            }
        },
        components: {
            AddGamePartyView,
      
        },
        created() {
            this.getGameParties();
            this.getPlayers();
            this.getGamePlaces();
        },
        methods: {
            sort: function (s) {
                if (s === this.currentSort) {
                    this.currentSortDir = this.currentSortDir === 'asc' ? 'desc' : 'asc';
                }
                this.currentSort = s;
                this.gameParties = this.gameParties.sort((a, b) => {
                    let modifier = 1;
                    if (this.currentSortDir === 'desc') modifier = -1;
                    if (a[this.currentSort] < b[this.currentSort]) return -1 * modifier;
                    if (a[this.currentSort] > b[this.currentSort]) return 1 * modifier;
                    return 0;
                });
            },
            showAddModal() {
                this.isModalVisible = true;
            },
            closeAddModal() {
                this.isModalVisible = false;
            },
            getGameParties() {
                GamePartiesService.GetAll().then(response => {
                    this.gameParties = response.data;
                })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },
            getGamePartiesWithFilters() {
                GamePartiesService.GetAllWithFilters(this.filter).then(response => {
                    this.gameParties = response.data;
                })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },
            goToDetails(id) {
                this.$router.push({ name: 'GamePartyView', params: { id: id } })
            },
            goToDelete(id) {
                GamePartiesService.Delete(id).then(response => {
                    if (response.status == 200) {
                        let i = this.gameParties.map(item => item.id).indexOf(id)
                        this.gameParties.splice(i, 1)
                    }
                })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },

            async getPlayers() {
                PlayersService.GetCreatedPlayers().then(response => {
                    this.players = response.data;
                })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },
             async getGamePlaces() {
                 GamePlacesService.GetCurrentUserGamePlaces().then(response => {
                    this.gamePlaces = response.data;
                })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    });
            }
        },
    }
</script>  
  
<style lang="scss" scoped>  
  
</style>  
