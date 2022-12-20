<template>
    <form ref="form" class="container ">
        <div class="container-white input-container row d-flex justify-content-center">
            <h2> Get games </h2>
            <p v-show="status!=''" class="text-warning"> {{status}}</p>
            <p v-show="errorMessage!=''" class="text-danger"> {{errorMessage}}</p>
            <p class="text-primary"> {{games.length}}/{{currentCount}} games was added</p>
            <h5 class="extended-title">By top game rate</h5>
            <div class="col-md-6">
                <label class="form-label">Count:</label>
                <input type="number" v-model="countByRate" min="0" max="100" />
                <button @click="getGames('top-by-rate')" type="button" class="m-rl-20">download</button>
            </div>

            <h5 class="extended-title">Last added</h5>
            <div class="col-md-6">
                <label class="d-inline">Count:</label>
                <input type="number" v-model="countLastAdded" min="0" max="100" />
                <button @click="getGames('last-added')" type="button" class="m-rl-20">download</button>
            </div>

            <h5 class="extended-title">By user collection</h5>
            <div class="col-md-6">
                <label>Count:</label>
                <input placeholder="Input games count" type="number" min="0" max="100" v-model="countByUser" />
                <label>User name: </label>
                <input placeholder="Input  name" type="text" v-model="userName" />
                <button @click="getGames('by-user-collection')" type="button" class="m-rl-20">download</button>
            </div>

            <h5 class="extended-title">Game alias</h5>
            <div class="col-md-6">
                <label>Alias: </label>
                <input placeholder="Input game alias" type="text" v-model="alias" />
                <button @click="getGames('by-alias')" type="button" class="m-rl-20">download</button>
            </div>
        </div>
        <div v-show="games.length>0">
            <h3> Added games </h3>
            <GameTable :games="games" />
        </div>

    </form>
</template>

<script>
    import GameParserService from "../../services/GameParserService";

    import GameTable from "../Games/GamesTable.vue";
    export default {
        name: 'GetGamesFromApiView',
        data() {
            return {
                status: '',
                errorMessage: '',
                countByRate: 0,
                countLastAdded: 0,
                countByUser: 0,
                userName: '',
                currentCount: 0,
                alias:'',
                games: []
            }
        },
        components: {
            GameTable
        },
        methods: {
            async getGames(param) {
                this.errorMessage = '';

                if (this.games.length > 0) {
                    if (confirm("The list of added games will be cleared.Are you sure you want to continue?")) {
                        this.status = 'loading...'
                        this.getByParamType(param);
                    }
                }
                else {
                    this.status = 'loading...'
                    this.getByParamType(param);
                }
            },
            async getByParamType(param) {
                switch (param) {
                    case 'top-by-rate':
                        await this.getGamesByRateFromApi();
                        break;
                    case 'last-added':
                        await this.getLastAddedGames();
                        break;
                    case 'by-user-collection':
                        await this.getGamesByUserCollection();
                        break;
                    case 'by-alias':
                        await this.getGamesByUserCollection();
                        break;
                    default:
                        this.errorMessage = "Get type not fount"
                        break;
                }

            },
            async getGamesByRateFromApi() {

                await GameParserService.GetTopByRate(this.countByRate)
                    .then(response => {
                        if (response.status == 200) {
                            this.games = response.data;
                            this.currentCount = this.countByRate;
                        }
                    })
                    .catch(e => {
                        this.errorMessage = e.response.data;
                    });
                this.status = '';
            },
            async getLastAddedGames() {

                await  GameParserService.GetLastAddedGamesFromApi(this.countLastAdded)
                    .then(response => {
                        if (response.status == 200) {
                            this.games = response.data;
                            this.currentCount = this.countLastAdded;
                           
                        }
                    })
                    .catch(e => {
                        this.errorMessage = e.response.data;
                    });
                this.status = '';
            },
            async getGamesByUserCollection() {
                if (this.userName.length != 0)
                    await GameParserService.GetByUserCollection(this.userName, this.countByUser)
                        .then(response => {
                            if (response.status == 200) {
                                this.games = response.data;
                                this.currentCount = this.countByUser;
                            }
                        })
                        .catch(e => {
                            this.errorMessage = e.response.data;
                        });
                else 
                    this.errorMessage = "User name required";
              
                this.status = '';
            },
            async getGamesByUserCollection() {
                if (this.alias.length != 0)
                    await GameParserService.GetByGameAlias(this.alias)
                        .then(response => {
                            if (response.status == 200) {
                                this.games = response.data;
                                this.currentCount = this.countByUser;
                            }
                        })
                        .catch(e => {
                            this.errorMessage = e.response.data;
                        });
                else 
                    this.errorMessage = "Alias required";
                this.status = '';

            }
        }
    }
</script>

<style lang="scss" scoped>
</style>  