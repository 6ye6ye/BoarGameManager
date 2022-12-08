<template>
    <div class="container container-white">
        <div class="pt-4">
            <div>
                <img class="game-image" :src="game.image">
            </div>
            <div v-on:click="goToDetails(item.id)" style="cursor: pointer;">
                <h4 class="dark-text ">{{game.name }}</h4>
                <p class="extended-title">{{game.nameRu}}|{{game.nameEng}}</p>

                <dl class=" d-flex row ">
                    <dt class="col-sm-2">
                        <label>Release year:</label>
                    </dt>
                    <dd class="col-sm-10">
                        {{game.releaseYear }}
                    </dd>

                    <dt class="col-sm-2">
                        <label>Min/max players:</label>
                    </dt>
                    <dd class="col-sm-10">
                        {{game.playersMinCount }}/{{game.playersMaxCount }}
                    </dd>
                    <dt class="col-sm-2">
                        <label>Min/max players:</label>
                    </dt>
                    <dd class="col-sm-10">
                        {{game.playersMinCount }}/{{game.playersMaxCount }}
                    </dd>
                    <dt class="col-sm-2">
                        <label> Min/max party time:</label>
                    </dt>
                    <dd class="col-sm-10">
                        {{game.minPartyTime }}/ {{game.maxPartyTime }}
                    </dd>
                    <dt class="col-sm-2">
                        <label> Min. age:</label>
                    </dt>
                    <dd class="col-sm-10">
                        {{game.minAge }}
                    </dd>
                    <dt class="col-sm-2">
                        <label>Game rate:</label>
                    </dt>
                    <dd class="col-sm-10">
                        <star-rating v-model:rating="game.rating" :rating="0.01" :max-rating="10" :read-only="true"></star-rating>
                    </dd>
                    <dt v-if="isAuth" class="col-sm-2">
                        <label>My rate:  </label>
                    </dt>
                    <dd v-if="isAuth" class="col-sm-10">
                        <star-rating v-model:rating="myRate" :max-rating="10"></star-rating>
                        <button v-on:click="setGameRate()" type="button" class="btn btn-info mt-3">Save rating</button>
                    </dd>
                </dl>

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
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            setGameRate() {
                GameRateService.PutGameRate(this.gameId,this.myRate).then(response => {
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
