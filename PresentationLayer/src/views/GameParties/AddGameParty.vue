<template>
    <form ref="form" class="col-sm" @submit.prevent="addGameParty" method="post">
        <h2>Game party</h2>
        <div class="form-group  mb-3">
            <label class="control-label">Date</label><span class="required">*</span>
            <input type="date" v-model="gameParty.date" class="form-control" />
        </div>
        <div class="form-group ">
            <label class="control-label">Game place</label><span class="required">*</span>
            <button type="button" class="btn btn-primary" @click="showModal">+</button>

            <ModalWindow v-if="isModalVisible" @close="closeModal">
                <template v-slot:body>
                    <AddGamePlace @close="closeModal" @get-game-places="getUserGamePlaces"></AddGamePlace>
                </template>
            </ModalWindow>

            <select v-model="gameParty.userGamePlaceId" class="form-select" required>
                <option label="- Select game place -" value="" disabled hidden></option>
                <option v-for="place in userGamePlaces" v-bind:key="place.id" v-bind:value="place.id"> {{place.name}}</option>
            </select>
        </div>

        <div class="form-group ">
            <label class="control-label">Game</label><span class="required">*</span>

            <select v-model="gameParty.gameId" class="form-select" required>
                <option label="- Select  game -" value="" disabled hidden></option>
                <option v-for="game in games" v-bind:key="game.id" v-bind:value="game.id"> {{game.name}}</option>

            </select>
        </div>
        <p class="text-danger"> {{errorMessage}}</p>
      
        <button type="submit" class="btn btn-primary">Add</button>
    </form>
</template>



<script>
    import ModalWindow from "../ModalWindow.vue";

    import AddGamePlace from "../../views/GamePlaces/AddGamePlace.vue";
    import GamePartiesService from "../../services/GamePartiesService";
    import GameService from "../../services/GameService";
    import GamePlaceService from "../../services/GamePlaceService";
    export default {
        name: 'AddGamePartyView',
        emits: ['close', 'get-game-parties'],
        data() {
            return {
                errorMessage: '',
                isModalVisible: false,
                showGamePlaceAdd: false,
                games: [],
                userGamePlaces: [],
                gameParty: {
                    date: new Date().toISOString().substr(0, 10),
                    gameId: '',
                    userGamePlaceId: ''
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
        computed: {
            isValid() {
                return this.gameParty.date && this.gameParty.gameId && this.gameParty.userGamePlaceId
            }
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
                        this.errorMessage = e.response.data;
                        console.log(e);
                    })
            },
            getUserGamePlaces: function () {
                GamePlaceService.GetCurrentUserGamePlaces().then(response => {
                    this.userGamePlaces = response.data;
                })
                    .catch(e => {
                        this.errorMessage = e.response.data;
                        console.log(e);
                    })
            },
            async addGameParty() {
                if (!this.isValid) return false
                GamePartiesService.Add(this.gameParty)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-game-parties');
                        }

                    })
                    .catch(e => {
                        this.errorMessage = e.response.data;
                        console.log(e);
                    });
            },

        }
    }

</script>

<style lang="scss" scoped>
</style>
