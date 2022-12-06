<template>
    
    <ModalWindow v-show="isModalVisible" @close="closeModal">
        <template v-slot:body>
            <AddGameView @close="closeModal" @get-games="getGames"></AddGameView>
        </template>
    </ModalWindow>

        <table class="table">
            <thead>
                <tr class="table filter">
                    <th>
                        <label class="form-label">Name</label>
                        <input type="text" v-model="filter.name" placeholder="Input name" class="form-control" />
                    </th>
                    <th>
                        <label class="form-label">MinRate</label>
                        <input type="number" v-model="filter.minRate" min="0" max="10" class="form-control" />
                    </th>
                    <th>
                        <label class="form-label">MaxRate</label>
                        <input type="number" v-model="filter.maxRate" min="0" max="10" class="form-control" />
                    </th>
                    <th>
                        <label class="form-label">ReleaseYear</label>
                        <input type="number" v-model="filter.releaseYear" min="1900" max="2022" placeholder="Input year" class="form-control" />
                    </th>
                    <th>
                        <label class="form-label">My games</label>
                        <select v-model="filter.showAdded" class="form-select">
                            <option value='false'>- All -</option>
                            <option value='true'>my games</option>
                        </select>
                    </th>
                    <th>
                        <button v-on:click="getGamesWithFilters()" type="button" class="btn btn-info ">Search</button>
                    </th>
                    <th>
                        <button v-if="isAuth&&isAdmin" type="button" class="btn btn-primary" @click="showModal">+</button>
                    </th>
                </tr>
            </thead>
        </table>
        <div class="post">
            <table class="table ">
                <thead>
                    <tr class="table filter">
                        <th @click="sort('name')" style="cursor: pointer;">Name ⇅</th>
                        <th @click="sort('rating')" style="cursor: pointer;">Rate ⇅</th>
                        <th @click="sort('playersMinCount')" style="cursor: pointer;">Min player count ⇅</th>
                        <th @click="sort('playersMaxCount')" style="cursor: pointer;">Max player count ⇅</th>
                        <th @click="sort('minAge')" style="cursor: pointer;">Min age ⇅</th>
                        <th @click="sort('minPartyTime')" style="cursor: pointer;">Min party time ⇅</th>
                        <th @click="sort('maxPartyTime')" style="cursor: pointer;">Max party time ⇅</th>
                        <th @click="sort('releaseYear')" style="cursor: pointer;">Release year ⇅</th>
                        <th v-if="isAuth" @click="sort('addedToUserGames')" style="cursor: pointer;">Added</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
            </table>


            <div class=" d-flex justify-content-start card-strip" v-for="item in games" :key="item.Id">
                <div>
                    <img class="game-image" v-bind:src="item.image">
                    <div v-if="isAuth">
                        <label>Add to my games:</label>
                        <input class="form-check-input" type="checkbox" v-on:click="changeGameAdded(item.id,item.addedToUserGames)" v-model="item.addedToUserGames" />
                    </div>
                    <button v-if="isAdmin && !isMyGamesPage" v-on:click="goToDelete(item.id)" type="button" class="btn btn-danger">Delete</button>
                </div>
                <div class="info w-100" v-on:click="goToDetails(item.id)" style="cursor: pointer;">
                    <div class="row px-3 mb-2">
                        <h4 class="mr-4">{{item.name }}</h4>
                        <p class="mt-1 mr-4 extended-title">{{item.nameRu}}|{{item.nameEng}}</p>
                    </div>
                    <div>
                        <p><span> {{item.releaseYear }}</span></p>
                        <span> Min/max players: {{item.playersMinCount }}/{{item.playersMaxCount }} || </span>
                        <span> Min/max players: {{item.playersMinCount }}/{{item.playersMaxCount }} || </span>
                        <span> Min/max party time: {{item.minPartyTime }}/ {{item.maxPartyTime }} || </span>
                        <span> Min. age: {{item.minAge }}</span>
                    </div>
                    <div>
                        <star-rating v-model:rating="item.rating" :rating="0.01" :max-rating="10" :read-only="true" class="d-flex justify-content-center"></star-rating>
                    </div>
                </div>
            </div>
        </div>
  
</template>

<script>
    import StarRating from 'vue-star-rating'
    import ModalWindow from "../ModalWindow.vue";
    import AddGameView from "../Games/AddGameView.vue";
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
                isModalVisible: false,
                isMyGamesPage: false,
                games: [],

                currentSort: 'name',
                currentSortDir: 'asc'
            };
        },
        components: {
            ModalWindow,
            AddGameView,
            StarRating
        },
        created() {
            this.getGames();
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
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
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
  
    .info{
        margin:20px;
    }
    .card-strip {
        background-color: #fff;
        padding: 25px;
        width: 100%;
        margin: 20px auto;
        border-radius: 3px;
        box-shadow: 0px 8px 16px 0px #E0E0E0;
    }

    .extended-title {
        color: #757575;
        background-color: #E0E0E0;
     
    }

    .game-image {
        width: 150px;
        height: 150px;
    }

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
    }
</style>
