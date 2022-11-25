<template>
    <h2>New game party</h2>
    <div class="form-group  mb-3">
        <label class="control-label">Date</label><span class="required">*</span>
        <input type="date" v-model="gameParty.date" class="form-control" />
    </div>
    <div class="form-group ">
        <label class="control-label">Game place</label><span class="required">*</span>
        <button type="button" class="btn btn-primary" @click="showModal">+</button>

        <ModalWindow v-show="isModalVisible" @close="closeModal">
            <template v-slot:body>
                <AddGamePlace @close="closeModal" @get-user-game-places="getUserGamePlaces"></AddGamePlace>
            </template>
        </ModalWindow>

        <select v-model="gameParty.userGamePlaceId" class="form-select">
            <option value=0>- Select game place -</option>
            <option v-for="place in userGamePlaces" v-bind:key="place.id" v-bind:value="place.id"> {{place.name}}</option>
        </select>
    </div>

    <div class="form-group ">
        <label class="control-label">Game</label><span class="required">*</span>
        <select v-model="gameParty.gameId" class="form-select">
            <option value=0>- Select  game -</option>
            <option v-for="game in games" v-bind:key="game.id" v-bind:value="game.id"> {{game.name}}</option>
        </select>
    </div>
    <p> {{errorMessage}}</p>
    <button v-on:click="addGameParty()" type="button" class="btn btn-primary">Add</button>
</template>



<script>
    import ModalWindow from "../ModalWindow.vue";

    import AddGamePlace from "../../views/GamePlaces/AddGamePlace.vue";
    import GamePartiesService from "../../services/GamePartiesService";
    import GameService from "../../services/GameService";
    import GamePlaceService from "../../services/GamePlaceService";
    export default {
        name: 'AddGamePartyView',
        data() {
            return {
                errorMesage: '',
                isModalVisible: false,
                showGamePlaceAdd: false,
                games: [],
                userGamePlaces: [],
                gameParty: {
                    date: new Date().toISOString().substr(0, 10),
                    gameId: 0,
                    userGamePlaceId: 0
                }
            }
        },
        components: {
            AddGamePlace,
            ModalWindow
        },
        created() {
            this.getGames();
            this.getUserGamePlaces();
        },
        methods: {
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
            getGames: function () {
                GameService.GetAllShort().then(response => {
                    this.games = response.data;
                    console.log(response.data);
                })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    })
            },
            getUserGamePlaces: function () {
                GamePlaceService.GetGamePlaces().then(response => {
                    this.userGamePlaces = response.data;
                    console.log(response.data);
                })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    })
            },
            addGameParty: function () {
                GamePartiesService.Add(this.gameParty)
                    .then(response => {
                        this.$emit('close');
                        this.$emit('get-game-parties');
                        console.log(response.data);
                    })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },

        }
    }

</script>

<style lang="scss" scoped>
</style>
