<template>
    <form ref="form" class="col-sm" @submit.prevent="editGame" method="post">
        <div class="flex justify-center">
            <img class="game-image" :src="game.image">
        </div>

        <div>
            <span>Name</span>
            <input type="text"
                   v-model="game.name"
                   minlength="3" maxlength="100"
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div>
            <span>NameRu</span>
            <input type="text"
                   v-model="game.nameRu"
                   minlength="3" maxlength="100"
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div>
            <span>NameEng</span>
            <input type="text"
                   v-model="game.nameEng"
                   minlength="3" maxlength="100"
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div>
            <span>Game info short</span>
            <textarea type="text"
                      v-model="game.gameInfoShort"
                      minlength="1" maxlength="300" rows="3"
                      class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                      required />
        </div>
        <div>
            <span>Game info</span>
            <textarea type="text"
                      v-model="game.gameInfo"
                      maxlength="2000" rows="3"
                      class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500" />
        </div>
        <div>
            <span>PlayersMinCount</span>
            <input type="number"
                   v-model="game.playersMinCount"
                   min="1" max="50"
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div>
            <span>PlayersMaxCount</span>
            <input type="number"
                   v-model="game.playersMaxCount"
                   min="1" max="50"
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div>
            <span>MinAge</span>
            <input type="number"
                   v-model="game.minAge"
                   min="1" max="80"
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div>
            <span>MinPartyTime(min)</span>
            <input type="number"
                   v-model="game.minPartyTime"
                   min="1" max="1000"
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div>
            <span>MaxPartyTime(min)</span>
            <input type="number"
                   v-model="game.maxPartyTime"
                   min="1" max="1000"
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div>
            <span>ReleaseYear</span>
            <input type="number"
                   v-model="game.releaseYear"
                   min="1900" max="2030"
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <button type="submit"
                class="mt-2 w-full px-4 py-2 text-sm text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
            Save
        </button>
        <ErrorMessage :message="errorMessage"></ErrorMessage>
    </form>
</template>

<script>
    import GamesService from "../../services/GameService";

    export default {
        name: 'EditGameView',
        emits: ['close', 'get-games'],
        props: ['gameId'],
        data() {
            return {
                imageFile: undefined,
                game: {
                    id: this.gameId,
                    alias: '',
                    image: '',
                    name: '',
                    nameRu: '',
                    nameEng: '',
                    gameInfoShort: '',
                    gameInfo: '',
                    playersMinCount: '',
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
                        if (response.status == 200) {
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
