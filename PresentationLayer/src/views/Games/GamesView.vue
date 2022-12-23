<template>
    <ModalWindow v-show="isModalAddVisible" @close="closeAddModal">
        <template v-slot:title>
            <h5>New game</h5>
        </template>
        <template v-slot:body>
            <AddGameView @get-games="getGames"></AddGameView>
        </template>
    </ModalWindow>
    <ModalWindow v-if="isModalEditVisible" @close="closeEditModal">
        <template v-slot:title>
            <h5>Edit game</h5>
        </template>
        <template v-slot:body>
            <EditGameView :gameId="currentId" @get-games="getGames" @close="closeEditModal"></EditGameView>
        </template>
    </ModalWindow>

    <div class="flex w-full items-start flex-wrap xl:!flex-nowrap ">
        <div class="xl:w-3/4 px-6 xl:mr-10  w-full">
            <FilterBox>
                <template v-slot:body>
                    <div class="w-full flex relative border">
                        <span class="h-full absolute inset-y-0 left-0 flex items-center pl-2">
                            Name:
                        </span>
                        <input input type="text"
                               v-model="filter.gameName"
                               placeholder="Input name"
                               class="appearance-none
                               block pl-16 pr-2 py-2 w-full bg-white
                               placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-200
                               focus:text-gray-700 focus:outline-none" />
                    </div>
                    <div class="w-full flex relative border">
                        <span class="h-full absolute inset-y-0 left-0 flex items-center pl-2">
                            Min rate:
                        </span>
                        <input type="number"
                               v-model="filter.minRate"
                               min="0" max="10"
                               placeholder="Input min rate"
                               class="appearance-none
                               block pl-20 pr-2 py-2 w-full bg-white
                               placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-200
                               focus:text-gray-700 focus:outline-none" />
                    </div>
                    <div class="w-full flex relative border">
                        <span class="h-full absolute inset-y-0 left-0 flex items-center pl-2">
                            Max rate:
                        </span>
                        <input type="number"
                               v-model="filter.maxRate"
                               min="0" max="10"
                               placeholder="Input max rate"
                               class="appearance-none
                               block pl-20 pr-2 py-2 w-full bg-white
                               placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-200
                               focus:text-gray-700 focus:outline-none" />
                    </div>
                    <div class="w-full flex relative border">
                        <span class="h-full absolute inset-y-0 left-0 flex items-center pl-2">
                            Release year:
                        </span>
                        <input type="number"
                               v-model="filter.releaseYear"
                               min="1900" max="2022"
                               placeholder="Input max rate"
                               class="appearance-none
                               block pl-24  pr-2 py-2 w-full bg-white
                               placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-200
                               focus:text-gray-700 focus:outline-none" />
                    </div>

                    <div class="w-full flex flex-row border">
                        <select v-model="filter.showAdded"
                                class=" block  pr-3 py-2  w-full bg-white
                                placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-600 focus:text-gray-700 focus:outline-none">
                            <option value='false'>- All -</option>
                            <option value='true'>my games</option>
                        </select>
                    </div>
                    <span v-on:click="getGamesWithFilters()"
                          class="h-10 px-2 justify-center  bg-green-500 border-1 border-green-800  focus:outline-none hover:bg-green-400 inset-y-0 left-0 flex  items-center ">
                        <svg viewBox="0 0 24 24" class="h-7 lg:w-7 fill-current text-white">
                            <path d="M10 4a6 6 0 100 12 6 6 0 000-12zm-8 6a8 8 0 1114.32 4.906l5.387 5.387a1 1 0 01-1.414 1.414l-5.387-5.387A8 8 0 012 10z">
                            </path>
                        </svg>
                    </span>
                    <span @click="showAddModal" type="button"
                          class="h-10 px-2 justify-center text-white bg-green-500 border-1 border-green-800  focus:outline-none hover:bg-green-400 inset-y-0 left-0 flex  items-center ">
                        Add
                    </span>
                    <button class="bg-green-500 text-white  focus:outline-none hover:bg-green-400 w-full h-10"
                            v-if="isAuth&&isAdmin" type="button" @click="goToImportGamesMenu">
                        Import from Tesera
                    </button>

                </template>
            </FilterBox>
            <!-- Sort -->
            <FilterBox>
                <template v-slot:body>
                    <div class="w-full flex justify-around divide-x relative border">
                        <span @click="sort('rating')"
                              class="cursor-pointer text-center">Rate ⇅</span>
                        <span @click="sort('playersMinCount')"
                              style="cursor: pointer;"
                              class="text-center">Min player count ⇅</span>
                        <span @click="sort('playersMaxCount')"
                              style="cursor: pointer;"
                              class="text-center">Max player count ⇅</span>
                        <span @click="sort('minAge')"
                              style="cursor: pointer;"
                              class="text-center">Min age ⇅</span>
                        <span @click="sort('minPartyTime')"
                              style="cursor: pointer;"
                              class="text-center">Min party time ⇅</span>
                        <span @click="sort('maxPartyTime')"
                              style="cursor: pointer;"
                              class="text-center">Max party time ⇅</span>
                        <span @click="sort('releaseYear')"
                              style="cursor: pointer;"
                              class=" text-center">Release year ⇅</span>
                        <span v-if="isAuth"
                              @click="sort('addedToUserGames')"
                              style="cursor: pointer;"
                              class="text-center">Added</span>
                    </div>
                </template>
            </FilterBox>

            <!-- game card -->
            <div class="ease  duration-300 hover:scale-105 cursor-pointer flex bg-white rounded shadow-md p-8 justify-content-start my-4" v-for="item in games" :key="item.Id">
                <div class="flex flex-col w-1/4 mr-2 items-center">
                    <img class="w-140px h-140px" v-bind:src="item.image">
                    <star-rating v-model:rating="item.rating"
                                 :rating="0.01"
                                 :star-size="20"
                                 :max-rating="10"
                                 :read-only="true"
                                 :show-rating="false"
                                 class="flex-wrap justify-center">
                    </star-rating>

                    <div v-if="isAuth">
                        <label>Add to my games:</label>
                        <input class="form-check-input" type="checkbox" v-on:click="changeGameAdded(item.id,item.addedToUserGames)" v-model="item.addedToUserGames" />
                    </div>

                    <div class="flex item-center justify-center">
                        <div v-if="isAuth&&isAdmin"
                             v-on:click="showEditModal(item.id)"
                             class="w-6 mr-2 transform hover:text-purple-500 hover:scale-110">
                            <svg xmlns="http://www.w3.org/2000/svg" w-7 h-7 viewBox="0 0 24 24" fill="none" stroke="currentColor"
                                 stroke-linecap="round" stroke-width="2" stroke-linejoin="round">
                                <polygon points="16 3 21 8 8 21 3 21 3 16 16 3"></polygon>
                            </svg>

                        </div>

                        <div v-if="isAdmin && !isMyGamesPage"
                             v-on:click="goToDelete(item.id)"
                             class="w-6 mr-2 transform hover:text-purple-500 hover:scale-110">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                            </svg>
                        </div>
                    </div>
                </div>
                <div class="w-3/4 flex flex-col items-center text-center" v-on:click="goToDetails(item.id)" style="cursor: pointer;">
                    <div class="">

                        <h2 class="text-xl font-medium leading-normal text-gray-800">{{item.name }}</h2>
                        <p class="">{{item.nameRu}}|{{item.nameEng}}</p>
                    </div>
                    <div>
                        <p><span> {{item.releaseYear }}</span></p>
                        <span> Players: {{item.playersMinCount }}-{{item.playersMaxCount }} || </span>
                        <span> Party time: {{item.minPartyTime }}-{{item.maxPartyTime }} || </span>
                        <span> Min. age: {{item.minAge }}</span>
                    </div>
                    <span class="text-justify">  {{item.gameInfoShort }}</span>
                </div>
            </div>
        </div>
        <ContainerWhite class=" xl:w-1/4 w-full pt-4">
            <template v-slot:body>
                <h5 class="text-xl  text-center font-medium leading-normal text-gray-800 pb-2">
                    Top 10 games
                </h5>
                <hr/>
                <ol>
                    <li v-on:click="goToDetails(item.id)"
                        v-for="item in topGames"
                        :key="item.Id"
                        class="ease duration-300 transition-none hover:scale-105 cursor-pointer hover:text-green-400 list-decimal list-inside">
                        {{item.name}}
                    </li>
                </ol>
            </template>
        </ContainerWhite>
    </div>
</template>

<script>
    import StarRating from 'vue-star-rating'
    import AddGameView from "../Games/AddGameView.vue";
    import EditGameView from "../Games/EditGameView.vue";
    import GamesService from "../../services/GameService";
    import UserGamesService from "../../services/UserGamesService";
    export default {
        name: 'GamesView',

        data() {
            return {
                filter: {
                    name: '',
                    minRate: 0,
                    maxRate: 10,
                    releaseYear: '',
                    showAdded: false,
                },
                isAuth: localStorage.getItem('isAuth'),
                isAdmin: localStorage.role == 'Admin',
                isModalEditVisible: false,
                isModalAddVisible: false,
                isMyGamesPage: false,
                games: [],
                topGames: [],
                currentId: '',
                currentSort: 'name',
                currentSortDir: 'asc'
            };
        },
        components: {

            AddGameView,
            EditGameView,
            StarRating
        },
        created() {
            this.getGames();
            this.getTopTenGames();
            this.isAuth = localStorage.isAuth;
            this.isAdmin = localStorage.getItem('role') === "Admin"
        },
        mounted() {
            this.isAuth = localStorage.isAuth;
            this.isAdmin = localStorage.getItem('role') === "Admin"
        },
        methods: {
            sort: function (s) {
                if (s === this.currentSort) {
                    this.currentSortDir = this.currentSortDir === 'asc' ? 'desc' : 'asc';
                }
                this.currentSort = s;
                this.games = this.games.sort((a, b) => {
                    let modifier = 1;
                    if (this.currentSortDir === 'desc') modifier = -1;
                    if (a[this.currentSort] < b[this.currentSort]) return -1 * modifier;
                    if (a[this.currentSort] > b[this.currentSort]) return 1 * modifier;
                    return 0;
                });
            },
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
            getGames() {
                GamesService.GetAll().then(response => {
                    this.games = response.data;
                    this.isMyGamesPage = false;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getTopTenGames() {
                GamesService.GetTopTenGames().then(response => {
                    this.topGames = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getGamesWithFilters() {
                GamesService.GetAllWithFilters(this.filter).then(response => {
                    this.games = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getUserGames() {
                UserGamesService.GetUserGames().then(response => {
                    this.games = response.data;
                    this.isMyGamesPage = true;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToAdd() {
                this.$router.push({ name: 'AddGameView' })
            },
            goToDetails(id) {
                this.$router.push({ name: 'GameView', params: { id: id } })
            },

            goToImportGamesMenu() {
                this.$router.push({ name: 'ImportGamesMenu' })
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
            changeGameAdded(id, status) {
                if (status == false)
                    this.addUserGames(id);
                else
                    this.deleteFromUserGames(id);
            },
            addUserGames(id) {
                UserGamesService.Add(id).then()
                    .catch(e => {
                        console.log(e);
                    });
            },
            deleteFromUserGames(id) {
                UserGamesService.Delete(id).then()
                    .catch(e => {
                        console.log(e);
                    });
            },
        },
    }
</script>

<style>
    body {
        color: #616161;
        overflow-x: hidden;
        height: 100%;
        background-color: #ECEFF1;
        background-repeat: no-repeat;
    }

    .info {
        margin: 20px;
    }




    .card-strip {
        background-color: #fff;
        /*     padding: 25px;*/
        width: 100%;
        margin: 20px auto;
        border-radius: 3px;
        box-shadow: 0px 8px 16px 0px #E0E0E0;
    }

    .game-image {
        width: 150px;
        height: 150px;
        padding: 20px;
    }

    /*
    @media screen and (max-width: 1012px) {
        .card-strip {
            width: 100%;
        }
    }

    @media screen and (max-width: 859px) {
        .v-line {
            display: none;
        }

        .price {
            width: 100%;
            margin-left: 95px;
        }
    }

    @media screen and (max-width: 529px) {
        .price {
            margin-left: 0px;
        }
    }*/
</style>
