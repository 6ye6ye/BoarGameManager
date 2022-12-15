<template>
    <div class="container">
        <ModalWindow v-if="isModalVisible" @close="closeAddModal">
            <template v-slot:body>
                <AddGamePartyView @close="closeAddModal" @get-game-parties="getGameParties"></AddGamePartyView>
            </template>
        </ModalWindow>
        <div class="filter flex ">
   
        <div>
            <label class="form-label">Game name</label>
            <input type="text" v-model="filter.gameName" placeholder="Input name" class="form-control" />
        </div>
        <div>
            <label class="form-label">From:</label>
            <input type="date" v-model="filter.startDate" class="form-control" />
        </div>
        <div>
            <label class="form-label">To:</label>
            <input type="date" v-model="filter.endDate" class="form-control" />
        </div>
        <div>
            <label class="form-label">Game place</label>
            <select v-model="filter.gamePlaceId" class="form-select">
                <option value=''>- All places -</option>
                <option v-for="gamePlace in gamePlaces" v-bind:key="gamePlace.id" v-bind:value="gamePlace.id"> {{gamePlace.name}}</option>
            </select>
        </div>
        <div>
            <label class="form-label">Player</label>
            <select v-model="filter.playerId" class="form-select">
                <option value=''>- All players-</option>
                <option v-for="player in players" v-bind:key="player.id" v-bind:value="player.id"> {{player.name}}</option>
            </select>
        </div>
        <div>
            <label class="form-label">Created</label>
            <select v-model="filter.created" class="form-select">
                <option value=''>- All -</option>
                <option value='true'>Just created</option>
                <option value='false'>Just no created</option>
            </select>
        </div>
        <div class="align-bottom">
            <img class="icon" v-on:click="getGamePartiesWithFilters()" type="button" :src="require('/src/assets/icon-search.png')" />
        </div>
        <div class="align-bottom">
            <img class="icon" type="button" @click="showAddModal" :src="require('/src/assets/icon-add.png')" />
        </div>
    </div>
  
    <div class="post container-white">
        <div class="row" style="margin-bottom: 10px;">
        </div>
        <p>{{errorMessage}}</p>
        <table id="gamesTable" class="table">
            <thead>
                <tr class="filter">
                    <th @click="sort('date')" style="cursor: pointer;">Date</th>
                    <th @click="sort('game')" style="cursor: pointer;">Game</th>
                    <th @click="sort('gamePlace.name')" style="cursor: pointer;">Place</th>
                    <th @click="sort('partyCreatorName')" style="cursor: pointer;">Creator</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in gameParties" :key="item.Id">
                    <td>{{item.date }}</td>
                    <td>{{item.game.name}}</td>
                    <td>{{item.userGamePlace.name }}</td>
                    <td>{{item.partyCreatorName }}</td>
                    <td>
                        <div>
                            <img class="icon" v-on:click="goToDetails(item.id)" type="button" :src="require('/src/assets/icon-details.png')" />
                            <img class="icon" v-on:click="goToDelete(item.id)" type="button" :src="require('/src/assets/icon-remove.png')" />
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </div>
</template>  
  
<script>  
    import ModalWindow from "../ModalWindow.vue";
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
                players:[],
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
            ModalWindow,
            AddGamePartyView
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
