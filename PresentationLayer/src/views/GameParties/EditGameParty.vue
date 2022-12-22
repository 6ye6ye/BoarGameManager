<template>
    <form ref="form" class="col-sm" @submit.prevent="editGameParty" method="post">
        <div class="row ">
            <div class=" mx-auto">
                <h2>Game party</h2>

                <label class="control-label">Date</label><span class="required">*</span>
                <input type="date" v-model="gameParty.date" class="form-control" />

                <label class="control-label">Game place</label><span class="required">*</span>
                <button type="button" class="btn btn-primary" @click="showModal">+</button>

                <ModalWindow v-if="isModalVisible" @close="closeModal">
                    <template v-slot:title>
                        <h5>New game place</h5>
                    </template>
                    <template v-slot:body>
                        <AddGamePlace @close="closeModal" @get-game-places="getUserGamePlaces"></AddGamePlace>
                    </template>
                </ModalWindow>

                <select v-model="gameParty.userGamePlace.id" class="form-select" required>
                    <option v-for="gamePlace in userGamePlaces" :key="gamePlace.id" :value="gamePlace.id"> {{gamePlace.name}}</option>
                </select>


                <label class="control-label">Game</label><span class="required">*</span>

                <select v-model="gameParty.game.id" class="form-select" required>
                    <option @change="onChangeGameParty" v-for="game in games" :key="game.id" :value="game.id"> {{game.name}}</option>
                </select>

                <p class="text-danger"> {{errorMessage}}</p>
                <button type="submit" class="button-submit btn btn-primary">Save</button>
            </div>
        </div>
    </form>
</template>



<script>
     import ModalWindow from "../../components/ModalWindow.vue";
    import GamesPartyService from "../../services/GamePartiesService";
    import AddGamePlace from "../../views/GamePlaces/AddGamePlace.vue";

    import GameService from "../../services/GameService";
    import GamePlaceService from "../../services/GamePlaceService";
    export default {
        name: 'EditGamePartyView',
        props: ['gamePartyId'],
        emits: ['close', 'get-game-party'],
        data() {
            return {
                gameId: '',
                errorMessage: '',
                isModalVisible: false,
                showGamePlaceAdd: false,
                games: [],
                userGamePlaces: [],
                gameParty: {
                    id: this.gamePartyId,
                    date: '',
                    game:
                    {
                        id: '',
                        name: '',
                    },
                    userGamePlace: {
                        id: '',
                        name: '',
                    },
                },
            }
        },
        components: {
            AddGamePlace,
            ModalWindow
        },

        created() {
            this.getGames();
            this.getUserGamePlaces();
            this.getGameParty();
        },
        methods: {

            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
            async getGameParty() {
                GamesPartyService.GetById(this.gamePartyId).then(response => {
                    if (response.status == 200) {
                        this.gameParty = response.data;
                        this.gameId = response.data.gameId;
                    }
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            async getGames() {
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
            async editGameParty() {
          
                GamesPartyService.Edit(this.gameParty)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-game-party');
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
