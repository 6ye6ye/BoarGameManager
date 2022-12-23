<template>
    <ModalWindow v-if="isModalEditVisible" @close="closeEditModal">
        <template v-slot:title>
            <h5>Edit game</h5>
        </template>
        <template v-slot:body>
            <EditGameView :gameId="gameId" @get-games="getGame" @close="closeEditModal"></EditGameView>
        </template>
    </ModalWindow>

    <div class="xl:w-1/3 xl:mr-10 mr-0 w-full">
        <ContainerWhite class="w-full">
            <template v-slot:body>
                <div class="w-full flex justify-center">
                    <img class="game-image" :src="game.image">
                </div>
                <h4 class="text-xl text-gray-900 font-bold">{{game.name }}</h4>
                <ul class="mt-2 text-gray-700">
                    <li class="flex border-y py-2">
                        <span class="font-bold w-24">Release year:</span>
                        <span>{{game.releaseYear }}</span>
                    </li>
                    <li class="flex border-b py-2">
                        <span class="font-bold w-24">Players:</span>
                        <span>{{game.playersMinCount }}-{{game.playersMaxCount }}</span>
                    </li>
                    <li class="flex border-b py-2">
                        <span class="font-bold w-24">Party time (min)::</span>
                        <span>{{game.minPartyTime }}-{{game.maxPartyTime }}</span>
                    </li>
                    <li class="flex border-b py-2">
                        <span class="font-bold w-24">Min. age:</span>
                        <span> {{game.minAge }}</span>
                    </li>
                    <li class="flex border-b py-2">
                        <span class="font-bold w-24">Game rate:</span>
                        <star-rating class="d-flex flex-nowrap justify-content-center"
                                     style="display:block"
                                     v-model:rating="game.rating"
                                     :rating="0.01"
                                     :starSize="20"
                                     :max-rating="10"
                                     :read-only="true">
                        </star-rating>
                    </li>
                    <li v-if="isAuth" class="flex border-b py-2">
                        <span class="font-bold w-24">My rate:</span>
                        <star-rating v-on:click="setGameRate()"
                                     class="justify-content-center"
                                     v-model:rating="myRate"
                                     :starSize="20"
                                     :max-rating="10"></star-rating>
                    </li>
                </ul>
                <button v-on:click="showEditModal"
                        type="button"
                        class=" w-full px-4 py-2 text-sm text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
                    Edit
                </button>
            </template>
        </ContainerWhite>

        <ContainerWhite class="w-full">
            <template v-slot:body>
                <h4 class="text-xl text-center text-gray-700 font-bold">Game roles</h4>
                <hr />
                <GameRoles />
            </template>
        </ContainerWhite>
    </div>
    <ContainerWhite class=" xl:w-2/3 w-full">
        <template v-slot:body>
            <div class="mb-3">
                <h4 class="text-xl text-center text-gray-700 font-bold">Info short</h4>
                <hr />
                <div v-html="game.gameInfoShort" style="text-align: left; text-indent:30px" />
            </div>
            <div class="mb-3">
                <h4 class="text-xl text-center text-gray-700 font-bold">Details</h4>
                <hr />
                <div v-html="game.gameInfo" style="text-align: left; text-indent:30px" />
            </div>
        </template>

    </ContainerWhite>
</template>

<script>
    import GamesService from "../../services/GameService";
    import GameRateService from "../../services/GameRateService";
    import GameRoles from "../GameRoles/GameRoles.vue";
    import StarRating from 'vue-star-rating'
    import EditGameView from "../Games/EditGameView.vue";
    export default {
        name: 'GameView',
        data() {
            return {
                myRate: 0,
                gameId: this.$route.params.id.toString(),
                game: '',
                isAuth: localStorage.getItem('isAuth'),
                isModalEditVisible:false
            }
        },
        created() {
            this.getGame();
            if (this.isAuth) {
                this.getMyGameRate();
            }
        },
        components: {
            GameRoles,
            StarRating,
            EditGameView
        },
        methods: {
            showEditModal(id) {
                this.currentId = id;
                this.isModalEditVisible = true;
            },
            closeEditModal() {
                this.isModalEditVisible = false;
            },
            getGame() {
                GamesService.GetById(this.$route.params.id.toString()).then(response => {
                    this.game = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            setGameRate() {
                GameRateService.PutGameRate(this.gameId, this.myRate).then(response => {
                    this.game.rating = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getMyGameRate() {
                GameRateService.getCurrentUserGameRate(this.gameId).then(response => {
                    this.myRate = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            }
        }
    }
</script>

<style>
    dd {
        text-align: left;
        align-items: start;
    }

    dt {
        text-align: right;
        align-items: start;
    }
</style>
