<template>
    <form ref="form" class="col-sm" @submit.prevent="addGameParty" method="post">

        <label class="block">
            <span class=" text-gray-700">Date</span>
            <input type="date"
                   class="block pl-4 w-full  border-gray-200 rounded-md border  
                   focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   v-model="gameParty.date" required />
        </label>

        <div class="block">
            <span class=" text-gray-700">Game place</span>
            <div class="flex rounded-md shadow-sm rounded-md" role="group">
                <select v-model="gameParty.userGamePlaceId" 
                        class="block pl-4 w-full  border-gray-200 rounded-md border 
                        focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                        required>
                    <option label="- Select game place -" value="" disabled hidden></option>
                    <option v-for="place in userGamePlaces" v-bind:key="place.id" v-bind:value="place.id"> {{place.name}}</option>
                </select>
                <button type="button"
                        class="w-full px-4  text-center 
                        text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400
                        rounded-r-md border "
                        @click="showModal">
                    +
                </button>

                <ModalWindow v-if="isModalVisible" @close="closeModal">
                    <template v-slot:title>
                        <h5>New game place</h5>
                    </template>
                    <template v-slot:body>
                        <AddGamePlace @close="closeModal" @get-game-places="getUserGamePlaces"></AddGamePlace>
                    </template>
                </ModalWindow>
            </div>
        </div>

        <label class="block">
            <span class="text-gray-700">Game</span>
            <select v-model="gameParty.gameId" 
                    class="block pl-4 w-full  border-gray-200 rounded-md border 
                        focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                    required>
                <option label="- Select  game -" value="" disabled hidden></option>
                <option v-for="game in games" v-bind:key="game.id" v-bind:value="game.id"> {{game.name}}</option>
            </select>
        </label>
        <ErrorMessage :message="errorMessage"></ErrorMessage>

        <button type="submit"
                class="mt-2 w-full px-4 py-2 text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
            Add
        </button>
    </form>
</template>



<script>
    import ModalWindow from "../../components/ModalWindow.vue";

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
