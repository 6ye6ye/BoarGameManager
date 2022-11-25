<template>
    <h2>New game</h2>
    <div class="post">
        <div>
            <label class="form-label">Name</label>
            <input type="text" v-model="game.name" class="form-control" />
        </div>
        <div>
            <label class="form-label">NameRu</label>
            <input type="text" v-model="game.nameRu" class="form-control" />
        </div>
        <div>
            <label class="form-label">NameEng</label>
            <input type="text" v-model="game.nameEng" class="form-control" />
        </div>
        <div>
            <label class="form-label">Image</label>
            <input type="file"
                   accept="image/png, image/jpeg"
                   ref="file"
                   @change="selectImage()"
                   class="form-control" />
        </div>
        <div>
            <label class="form-label">PlayersMinCount</label>
            <input type="number" v-model="game.playersMinCount" min="1" max="50" class="form-control" />
        </div>
        <div>
            <label class="form-label">PlayersMaxCount</label>
            <input type="number" v-model="game.playersMaxCount" min="1" max="50" class="form-control" />
        </div>
        <div>
            <label class="form-label">MinAge</label>
            <input type="number" v-model="game.minAge" min="0" max="80" class="form-control" />
        </div>
        <div>
            <label class="form-label">MinPartyTime(min)</label>
            <input type="number" v-model="game.minPartyTime" min="1" max="1000" class="form-control" />
        </div>
        <div>
            <label class="form-label">MaxPartyTime(min)</label>
            <input type="number" v-model="game.maxPartyTime" min="1" max="1000" class="form-control" />
        </div>
        <div>
            <label class="form-label">ReleaseYear</label>
            <input type="number" v-model="game.releaseYear" min="1900" max="2030" class="form-control" />
        </div>
        <ErrorMessage :errorMessage="errorMessage" />
        <button v-on:click="addGame()" type="button" class="btn btn-primary">Add</button>
    </div>

</template>

<script>
    import GamesService from "../../services/GameService";
    import ErrorMessage from "../ErrorMessage.vue";

    export default {
        name: 'AddGameView',
        data() {
            return {
                imageFile: undefined,
                game: {
                    image: '',
                    name: '',
                    nameRu: '',
                    nameEng: '',
                    playersMinCount: 1,
                    playersMaxCount: 1,
                    minAge: 0,
                    minPartyTime: 0,
                    maxPartyTime: 0,
                    releaseYear: 2022
                },
                errorMessage: ''
            }
        },
        components: {
            ErrorMessage
        },
        methods: {
            selectImage() {
                this.imageFile = this.$refs.file.files[0];
            },
            addGame: function () {
                GamesService.Add(this.imageFile, this.game)
                    .then(response => {
                        switch (response.status) {
                            case (200):
                                {
                                    this.$emit('close');
                                    this.$emit('get-games');
                                    console.log(response.data);
                                    return { ok: true }
                                }
                            default:
                                {
                                    console.log(response.statusText);
                                    this.errorMessage = response.data;
                                    console.log(response);
                                    return { ok: false }
                                }
                        }
                    })
                    .catch(e => {

                        if (e.status == 400)
                            this.errorMessage = "Not valid input"
                        else

                            this.errorMessage = e.response.data;
                    });
            },
        }
    }

</script>

<style lang="scss" scoped>
</style>
