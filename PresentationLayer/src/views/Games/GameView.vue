<template>
    <div class="container">

        <div class="row">
            <div >
                <h2>{{game.name}}</h2>
            </div>
            <div>

                <img v-bind:src="game.image" width="50" height="80" />
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


    import GamesService from "../../services/GameService";
    import GameRoles from "../GameRoles/GameRoles.vue";

    export default {
        name: 'GameView',
        data() {
            return {
                gameId: this.$route.params.id.toString(),
                game: undefined,
            }
        },
        created() {
            this.getGame();
        },
        components: {
            GameRoles
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
            }

        }
    }

</script>

<style lang="scss" scoped>
</style>
