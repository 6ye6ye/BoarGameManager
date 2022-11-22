<template>
    <div class="container">

        <div class="row">
            <div>
                <h2>{{game.name}}</h2>
            </div>
            <div>

                <img v-bind:src="game.image" width="50" height="80" />
            </div>

             <div v-show="isAuth">
                My rate
                <vue3-star-ratings v-model="myRate" :step="1" :numberOfStars="10" :disableClick="true"/>
                   <button  v-on:click="setGameRate()" type="button" class="btn btn-info">Save</button>

             </div>
            <div>
                Rate
                <p>{{game.rating}}/10 </p>
            </div>
            <div>
                Min player count

                <p>{{game.playersMinCount}}</p>
            </div>
            <div>
                Max player count

                <p>{{game.playersMaxCount}}</p>
            </div>
            <div>
                Min age

                <p>{{game.minAge}}</p>
            </div>
            <div>
                Min party time
                <p>{{game.minPartyTime}}</p>
            </div>
            <div>
                Max party time
                <p>{{game.maxPartyTime}}</p>
            </div>
            <div>
                Max party time
                <p>{{game.releaseYear}}</p>
            </div>
            <div>
                <GameRoles />

            </div>
        </div>
    </div>
</template>

<script>

    import vue3StarRatings from "vue3-star-ratings";
    import GamesService from "../../services/GameService";
    import GameRateService from "../../services/GameRateService";
    import GameRoles from "../GameRoles/GameRoles.vue";

    export default {
        name: 'GameView',
        data() {
            return {
                myRate:0,
                gameId: this.$route.params.id.toString(),
                game: undefined,
                isAuth: localStorage.getItem('isAuth'),
            }
        },
        created() {
            this.getGame();
            this.getMyGameRate();
        },
        components: {
            GameRoles,
            vue3StarRatings
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
                    this.game.rating = response.data;
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
