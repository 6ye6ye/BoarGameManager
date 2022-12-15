<template>
    <form ref="form" class="col-sm" @submit.prevent="editGame" method="post">
        <h2>Edit game</h2>
        <div>
            <img class="game-image" :src="game.image">
        </div>
        <div>
            <label class="form-label">Name</label>
            <input type="text" v-model="game.name" minlength="3" maxlength="100" class="form-control" required />
        </div>
        <div>
            <label class="form-label">NameRu</label>
            <input type="text" v-model="game.nameRu" minlength="3" maxlength="100" class="form-control" required />
        </div>
        <div>
            <label class="form-label">NameEng</label>
            <input type="text" v-model="game.nameEng" minlength="3" maxlength="100" class="form-control" required />
        </div>
        <div>
            <label class="form-label">Game info short</label>
            <input type="text" v-model="game.gameInfoShort" minlength="1" maxlength="300" rows="3" class="form-control"  required />
        </div>
        <div>
            <label class="form-label">Game info</label>
            <textarea type="text" v-model="game.gameInfo" maxlength="2000" rows="3"  class="form-control"  />
        </div>
        <div>
            <label class="form-label">PlayersMinCount</label>
            <textarea type="number" v-model="game.playersMinCount" min="1" max="50" class="form-control" required />
        </div>
        <div>
            <label class="form-label">PlayersMaxCount</label>
            <input type="number" v-model="game.playersMaxCount" min="1" max="50" class="form-control" required />
        </div>
        <div>
            <label class="form-label">MinAge</label>
            <input type="number" v-model="game.minAge" min="1" max="80" class="form-control" required />
        </div>
        <div>
            <label class="form-label">MinPartyTime(min)</label>
            <input type="number" v-model="game.minPartyTime" min="1" max="1000" class="form-control" required />
        </div>
        <div>
            <label class="form-label">MaxPartyTime(min)</label>
            <input type="number" v-model="game.maxPartyTime" min="1" max="1000" class="form-control" required />
        </div>
        <div>
            <label class="form-label">ReleaseYear</label>
            <input type="number" v-model="game.releaseYear" min="1900" max="2030" class="form-control" required />
        </div>

        <hr>
        <button type="submit" class="btn btn-primary">Save</button>
        <p class="text-danger"> {{errorMessage}}</p>
    </form>
</template>

<script>
    import GamesService from "../../services/GameService";

    export default {
        name: 'EditGameView',
        emits: ['close', 'get-games'],
        props: [ 'gameId'],
        data() {
            return {
                imageFile: undefined,
                game: {
                    id: this.gameId, 
                    image: '',
                    name: '',
                    nameRu: '',
                    nameEng: '',
                    gameInfoShort: '',
                    gameInfo: '',
                    playersMinCount:'',
                    playersMaxCount: '',
                    minAge: '',
                    minPartyTime: '',
                    maxPartyTime: '',
                    releaseYear: ''
                },
                errorMessage: ''
            }
        },
        computed: {
            isValid() {
                return this.game.name
                    && this.game.nameRu
                    && this.game.nameEng
                    && this.game.gameInfoShort
                    && this.game.gameInfo
                    && this.game.playersMinCount
                    && this.game.playersMaxCount
                    && this.game.minAge
                    && this.game.minPartyTime
                    && this.game.maxPartyTime
                    && this.game.releaseYear
            }
        },
        created() {
            this.getGame();
        },
        methods: {
            async getGame() {
                GamesService.GetById(this.game.id).then(response => {
                    this.game = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            async editGame() {
                if (!this.isValid) return false
                GamesService.Edit(this.game)
                    .then(response => {
                        if (response.status==200) {
                            this.$emit('close');
                            this.$emit('get-games');
                            return { ok: true }
                        }
                    })
                    .catch(e => {
                        this.errorMessage = e.response;
                    });
            },
        }
    }
</script>

<style lang="scss" scoped>
</style>
