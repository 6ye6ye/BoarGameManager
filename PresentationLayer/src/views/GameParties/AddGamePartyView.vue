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
                <AddGamePlace @close="closeModal" @get-game-places="getUserGamePlaces"></AddGamePlace>
            </template>
        </ModalWindow>

        <select v-model="gameParty.userGamePlaceId" class="form-select" required>

            <option v-for="place in userGamePlaces" v-bind:key="place.id" v-bind:value="place.id"> {{place.name}}</option>
            <option value=0 disabled selected hidden>- Select game place -</option>
        </select>
    </div>

    <div class="form-group ">
        <label class="control-label">Game</label><span class="required">*</span>
        <select v-model="gameParty.gameId" class="form-select" required>
            <option v-for="game in games" v-bind:key="game.id" v-bind:value="game.id"> {{game.name}}</option>
            <option value=0 disabled selected hidden>- Select  game -</option>
        </select>
    </div>
    <ErrorMessage :errorMessage="errMessage" />
    <button type="button" @click="addGameParty" class="btn btn-primary">Add</button>
</template>



<script>
    import ModalWindow from "../ModalWindow.vue";
    import ErrorMessage from "../ErrorMessage.vue";
    import AddGamePlace from "../../views/GamePlaces/AddGamePlace.vue";
    import GamePartiesService from "../../services/GamePartiesService";
    import GameService from "../../services/GameService";
    import GamePlaceService from "../../services/GamePlaceService";
    export default {
        name: 'AddGamePartyView',
        emits: ['close', 'get-game-parties'],
        data() {
            return {
                errMessage: "",
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
            ModalWindow,
            ErrorMessage
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
                })
                    .catch(e => {
                        this.errMesage = e.response.data;
                        console.log(e);
                    })
            },
            getUserGamePlaces: function () {
                GamePlaceService.GetGamePlaces().then(response => {
                    this.userGamePlaces = response.data;
                })
                    .catch(e => {
                        this.errMesage = e.response.data;
                        console.log(e);
                    })
            },
            addGameParty() {
                GamePartiesService.Add(this.gameParty)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-game-parties');
                        }

                    })
                    .catch(e => {
                        this.errMesage = e.response.data;
                        console.log(e);
                    });
            },

        }
    }

</script>

<style lang="scss" scoped>
</style>
