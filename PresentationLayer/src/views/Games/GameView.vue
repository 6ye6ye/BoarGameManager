<template>
    <div class="container container-white">
        <div class="pt-4">
            <div>
                <img class="game-image" :src="game.image">
            </div>
            <div v-on:click="goToDetails(item.id)" style="cursor: pointer;">
                <h4 class="dark-text ">{{game.name }}</h4>
                <p class="extended-title">{{game.nameRu}}|{{game.nameEng}}</p>

                <div class="  row align-items-center ">
                    <div>
                        <label>Release year:</label>
                        {{game.releaseYear }}
                    </div>
                    <div>
                        <label>Min/max players:</label>
                        {{game.playersMinCount }}/{{game.playersMaxCount }}
                    </div>
                    <div>
                        <label>Min/max players:</label>
                        {{game.playersMinCount }}/{{game.playersMaxCount }}
                    </div>
                    <div>
                        <label> Min/max party time:</label>
                        {{game.minPartyTime }}/ {{game.maxPartyTime }}
                    </div>
                    <div>
                        <label> Min. age:</label>
                        {{game.minAge }}
                    </div>
                    <div>
                        <label>Game rate:</label>
                        <star-rating class="d-flex flex-nowrap justify-content-center" style="display:block" v-model:rating="game.rating" :rating="0.01" :max-rating="10" :read-only="true"></star-rating>
                    </div>
                    <div v-if="isAuth">
                        <label>My rate:  </label>
                        <star-rating class="justify-content-center" v-model:rating="myRate" :max-rating="10"></star-rating>
                        <button v-on:click="setGameRate()" type="button" class="btn btn-info mt-3">Save </button>
                    </div>
                    <p class="extended-title">Info</p>
                    <div>
                        <p>{{game.gameInfo }}</p>
                    </div>
                </div>

            </div>
        </div>
        <div class="mt-3">
      
            <GameRoles />
        </div>
    </div>
</template>

<script>
    import GamesService from "../../services/GameService";
    import GameRateService from "../../services/GameRateService";
    import GameRoles from "../GameRoles/GameRoles.vue";
    import StarRating from 'vue-star-rating'

    export default {
        name: 'GameView',
        data() {
            return {
                myRate: 0,
                gameId: this.$route.params.id.toString(),
                game: '',
                isAuth: localStorage.getItem('isAuth'),
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
            StarRating
        },
        methods: {
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
