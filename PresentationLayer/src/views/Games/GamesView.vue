<template>
    <div class="grid grid-cols-3 gap-4">
        <div class="col-span-2">
            <ModalWindow v-show="isModalAddVisible" @close="closeAddModal" :title="Test">
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
                               block pl-16 pr-6 py-2 w-full bg-white
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
                               block pl-20 pr-6 py-2 w-full bg-white
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
                               block pl-20 pr-6 py-2 w-full bg-white
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
                               block pl-24  pr-6 py-2 w-full bg-white
                               placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-200
                               focus:text-gray-700 focus:outline-none" />
                    </div>

                    <div class="w-full flex flex-row border">
                        <select v-model="filter.showAdded"
                                class=" block  pr-6 py-2 w-full bg-white
                                placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-600 focus:text-gray-700 focus:outline-none">
                            <option value='false'>- All -</option>
                            <option value='true'>my games</option>
                        </select>
                    </div>
                    <span v-on:click="getGamesWithFilters()" class="justify-center bg-green-400 border-1 border-green-800  inset-y-0 left-0 flex  items-center ">
                        <svg viewBox="0 0 24 24" class="h-7 lg:w-7 fill-current text-white">
                            <path d="M10 4a6 6 0 100 12 6 6 0 000-12zm-8 6a8 8 0 1114.32 4.906l5.387 5.387a1 1 0 01-1.414 1.414l-5.387-5.387A8 8 0 012 10z">
                            </path>
                        </svg>
                    </span>
                    <span @click="showAddModal" type="button" class="justify-center bg-green-400 border-1 border-green-800 inset-y-0 left-0 flex  items-center ">
                        <svg xmlns="http://www.w3.org/2000/svg" width="28" height="28" 
                             class=" lg:w-10 h-10 fill-current text-normal text-white" viewBox="0 0 16 16"> <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z" /> </svg>
                    </span>
                    <button class="bg-green-400 text-white  lg:w-20 h-10"
                            v-if="isAuth&&isAdmin" type="button" @click="goToImportGamesMenu"> Import from Tesera</button>
               
                </template>
            </FilterBox>

            <!-- Sort -->
            <FilterBox>
                <template v-slot:body>

                    <div class="w-full flex justify-around divide-x relative border">

                        <span @click="sort('rating')"
                              style="cursor: pointer;"
                              class="font-light text-left">Rate ⇅</span>
                        <span @click="sort('playersMinCount')"
                              style="cursor: pointer;"
                              class="font-light text-left">Min player count ⇅</span>
                        <span @click="sort('playersMaxCount')"
                              style="cursor: pointer;"
                              class="font-light text-left">Max player count ⇅</span>
                        <span @click="sort('minAge')"
                              style="cursor: pointer;"
                              class="font-light text-left">Min age ⇅</span>
                        <span @click="sort('minPartyTime')"
                              style="cursor: pointer;"
                              class="font-light text-left">Min party time ⇅</span>
                        <span @click="sort('maxPartyTime')"
                              style="cursor: pointer;"
                              class="font-light text-left">Max party time ⇅</span>
                        <span @click="sort('releaseYear')"
                              style="cursor: pointer;"
                              class="font-light text-left">Release year ⇅</span>
                        <span v-if="isAuth"
                              @click="sort('addedToUserGames')"
                              style="cursor: pointer;"
                              class="font-light text-left">Added</span>

                    </div>

                </template>
            </FilterBox>
            <div class="post">
                

                <div class="flex bg-white rounded-lg shadow-xl p-8 justify-content-start card-strip" v-for="item in games" :key="item.Id">
                    <div>
                        <img class="game-image" v-bind:src="item.image">
                        <div v-if="isAuth">
                            <label>Add to my games:</label>
                            <input class="form-check-input" type="checkbox" v-on:click="changeGameAdded(item.id,item.addedToUserGames)" v-model="item.addedToUserGames" />
                        </div>
                        <img class="w-7 h-7" v-if="isAuth&&isAdmin" @click="showEditModal(item.id)" type="button" :src="require('/src/assets/icon-edit.png')" />
                        <img class="w-7 h-7" v-if="isAdmin && !isMyGamesPage" v-on:click="goToDelete(item.id)" type="button" :src="require('/src/assets/icon-remove.png')" />
                    </div>
                    <div class="info w-100 col" v-on:click="goToDetails(item.id)" style="cursor: pointer;">
                        <div class="row px-3 mb-2">
                            <h4 class="mr-4">{{item.name }}</h4>
                            <p class="mt-1 mr-4 extended-title">{{item.nameRu}}|{{item.nameEng}}</p>
                        </div>
                        <div>
                            <p><span> {{item.releaseYear }}</span></p>
                            <span> Players: {{item.playersMinCount }}-{{item.playersMaxCount }} || </span>
                            <span> Party time: {{item.minPartyTime }}-{{item.maxPartyTime }} || </span>
                            <span> Min. age: {{item.minAge }}</span>
                        </div>

                        <star-rating v-model:rating="item.rating" :rating="0.01" :max-rating="10" :read-only="true" class="flex-wrap justify-content-center"></star-rating>
                        <span class="text-justify">  {{item.gameInfoShort }}</span>
                    </div>
                </div>
            </div>


        </div>
        <div>
            <h3>Top 10 games</h3>
            <ol>
                <li v-on:click="goToDetails(item.id)" v-for="item in topGames" :key="item.Id">
                    {{item.name}}
                </li>
            </ol>
        </div>
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
