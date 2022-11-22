<template>
    <div class="mb-3">
        <h1>Game list</h1>
        <!--<button v-on:click="goToAdd()" type="button" class="btn btn-primary">Add game</button>-->

        <button v-show="isAuth&&isAdmin" type="button" class="btn btn-primary" @click="showModal">+</button>
        <!--<button v-on:click="getUserGames()" type="button" class="btn btn-danger">MyGames</button>-->
    </div>
    <ModalWindow v-show="isModalVisible" @close="closeModal">
        <template v-slot:body>
            <AddGameView @close="closeModal" @get-games="getGames"></AddGameView>
        </template>
    </ModalWindow>


    <div class="post">

        <div class="row row_filters">

            <div class="col-sm-2 sub_filters">
                <label class="form-label">Name</label>
                <input type="text" v-model="filter.name" class="form-control" />
            </div>
            <div class="col-sm-2 sub_filters">
                <label class="form-label">MinRate</label>
                <input type="number" v-model="filter.minRate" min="0" max="10" class="form-control" />
            </div>
            <div class="col-sm-2 sub_filters">
                <label class="form-label">MaxRate</label>
                <input type="number" v-model="filter.maxRate" min="0" max="10" class="form-control" />
            </div>
            <div class="col-sm-2 sub_filters">
                <label class="form-label">ReleaseYear</label>
                <input type="number" v-model="filter.releaseYear" min="1900" max="2022" class="form-control" />
            </div>
            <div v-show="isAuth" class="col-sm-2 sub_filters ">
                <label class="form-label">my games</label>
                <input class="form-check-input " type="checkbox" v-model="filter.showAdded"/>
            </div>
            <div class="col-sm-2  sub_filters">
                <button v-on:click="getGamesWithFilters()" type="button" class="form-control btn btn-info">Search</button>
            </div>
           </div>
        <table id="gamesTable" class="table">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Image</th>
                    <th @click="sort('name')">Name</th>
                    <th>Ru/Eng</th>
                    <th @click="sort('rate')">Rate</th>
                    <th @click="sort('playersMinCount')">Min player count</th>
                    <th @click="sort('playersMaxCount')">Max player count</th>
                    <th @click="sort('minAge')">Min age</th>
                    <th @click="sort('minPartyTime')">Min party time</th>
                    <th @click="sort('maxPartyTime')">Max party time</th>
                    <th @click="sort('releaseYear')">Release year</th>
                    <th @click="sort('addedToUserGames')">Added</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>

                <tr v-for="item in games" :key="item.Id">
                    <td>{{item.id}}</td>
                    <td>
                        <img v-bind:src="item.image" width="50" height="80" />
                    </td>

                    <td>{{item.name }}</td>
                    <td>{{item.nameRu}}|{{item.nameEng}}</td>
                    <td>{{item.rating }}</td>
                    <td>{{item.playersMinCount }}</td>
                    <td>{{item.playersMaxCount }}</td>
                    <td>{{item.minAge }}</td>
                    <td>{{item.minPartyTime }}</td>
                    <td>{{item.maxPartyTime }}</td>
                    <td>{{item.releaseYear }}</td>
                    <td v-show="isAuth">
                        <input class="form-check-input" type="checkbox"  v-on:click="changeGameAdded(item.id,item.addedToUserGames)" v-model="item.addedToUserGames" /> 
                    </td>
                    <td><button v-on:click="goToDetails(item.id)" type="button" class="btn btn-info">Details</button></td>
   
                    <td><button v-show="isAdmin && !isMyGamesPage" v-on:click="delete(item.id)" type="button" class="btn btn-danger">Delete</button></td>

                    <td><button v-show="isMyGamesPage" v-on:click="deleteFromUserGames(item.id)" type="button" class="btn btn-danger">Delete</button></td>

                </tr>
            </tbody>
        </table>

    </div>

</template>  
  



<script>  

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
                    showAdded:false,
                },
                isAuth: localStorage.getItem('isAuth'),
                isAdmin: localStorage.role=='Admin',
                isModalVisible: false,
                isMyGamesPage: false,
                games: [],

                currentSort: 'name',
                currentSortDir: 'asc'
            };
        },
        components: {
            ModalWindow,
            AddGameView
        },
        created() {
            this.getGames();
            this.isAuth = localStorage.isAuth;
            this.isAdmin = localStorage.getItem('role') === "Admin"
        },

        methods: {
   
            sort: function (s) {

                if (s === this.currentSort) {
                    this.currentSortDir = this.currentSortDir === 'asc' ? 'desc' : 'asc';
                }
                this.currentSort = s;
                this.games =this.games.sort((a, b) => {
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
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            
            getGamesWithFilters() {
                GamesService.GetAllWithFilters(this.filter).then(response => {
                    this.games = response.data;
                    //this.sortedGames = response.data;

                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getUserGames() {
                UserGamesService.GetUserGames().then(response => {
                    this.games = response.data;
                    this.isMyGamesPage = true;
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToAdd() {
                this.$router.push({ name: 'AddGameView' })
            },
            goToDetails(id) {
                this.$router.push({ name: 'GameView',params: { id: id } })
            },
            delete(id) {
                GamesService.Delete(id).then(response => {
                    console.log(response.data);
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
                UserGamesService.Add(id).then(response => {
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            deleteFromUserGames(id) {
                UserGamesService.Delete(id).then(response => {
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            
        },
    }
</script>  
  
<style >
    .row_filters {
        align-content: center;
        align-items: center;
        padding-bottom: 10px;
    }

    .sub_filters {
        align-content: center;
        align-items: center;
        padding-left: 5px;
        padding-right: 5px;
        margin: 0;
    }

</style>  
