<template>
    <div class="container">
        <div class="mx-auto">
             <div>
                    <img class="game-image" :src="game.image">
              </div>
                <div class="info w-100" v-on:click="goToDetails(item.id)" style="cursor: pointer;">
                    <div class="row ">
                        <h4 class="dark-text mr-4">{{game.name }}</h4>
                        <p class="extended-title">{{game.nameRu}}|{{game.nameEng}}</p>
                    </div>
                    <div>
                        <p><span> {{game.releaseYear }}</span></p>
                        <span> Min/max players: {{game.playersMinCount }}/{{game.playersMaxCount }} || </span>
                        <span> Min/max players: {{game.playersMinCount }}/{{game.playersMaxCount }} || </span>
                        <span> Min/max party time: {{game.minPartyTime }}/ {{game.maxPartyTime }} || </span>
                        <span> Min. age: {{game.minAge }}</span>
                    </div>
                    <div>
                        <label>Game rate</label>
                        <star-rating v-model:rating="game.rating" :rating="0.01" :max-rating="10" :read-only="true" class="d-flex justify-content-center"></star-rating>
                    </div>
                    <div v-if="isAuth">
                        <label>My rate</label>
                        <star-rating v-model:rating="myRate" :max-rating="10" class="d-flex justify-content-center"></star-rating>
                        <button v-on:click="setGameRate()" type="button" class="btn btn-info mt-3">Save rating</button>
                    </div>
                </div>
        </div>
        <div class="mt-3">
            <GameRoles  />
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
                myRate:0,
                gameId: this.$route.params.id.toString(),
                game: '',
                isAuth: localStorage.getItem('isAuth'),
            }
        },
        created() {
            this.getGame();
            this.getMyGameRate();
        },
        components: {
            GameRoles,
            StarRating
        },
        methods: {
            getGame() {
                GamesService.GetById(this.$route.params.id.toString()).then(response => {
                    this.game = response.data;
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            setGameRate() {
                GameRateService.PutGameRate(this.gameId,this.myRate).then(response => {
                    this.game.rating = response.data;
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getMyGameRate() {
                GameRateService.getCurrentUserGameRate(this.gameId).then(response => {
                    this.myRate = response.data;
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            }
        }
    }
</script>

<style lang="scss" scoped>

</style>
