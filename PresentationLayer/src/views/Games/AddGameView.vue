<template>
    <form ref="form" class="col-sm text-sm text-gray-700" @submit.prevent="addGame" method="post">
        <div>
            <span >
                Alias
            </span>
            <input type="text" 
                   v-model="game.alias" 
                   minlength="3" maxlength="100" 
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div class="block pb-2">
            <span >Name</span>

            <input type="text" 
                   v-model="game.name" 
                   minlength="3" maxlength="100" 
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500" 
                   required />
        </div>
        <div class="block pb-2">
            <span >NameRu</span>
            <input type="text" 
                   v-model="game.nameRu" 
                   minlength="3" maxlength="100" 
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500" 
                   required />
        </div>
        <div class="block pb-2">
            <span >NameEng</span>
            <input type="text" 
                   v-model="game.nameEng" 
                   minlength="3" maxlength="100" 
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div class="block pb-2">
            <span>Game info short</span>
            <textarea type="text" 
                      v-model="game.gameInfoShort" 
                      minlength="1" maxlength="300" rows="3" 
                      class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                      required />
        </div>
        <div class="block pb-2">
            <span>Game info</span>
            <textarea type="text" 
                      v-model="game.gameInfo" 
                      minlength="1" maxlength="2000" rows="3" 
                      class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                      required />
        </div>
        <div class="block pb-2">
            <span>Image</span>
            <input type="file"
                   accept="image/png, image/jpeg"
                   ref="file"
                   @change="selectImage()"
                   class="form-control block w-full text-sm text-gray-700
                     rounded transition ease-in-out "/>
        </div>
        <div class="block pb-2">
            <span >PlayersMinCount</span>
            <input type="number" 
                   v-model="game.playersMinCount" 
                   min="1" max="50" 
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div class="block pb-2">
            <span >PlayersMaxCount</span>
            <input type="number" 
                   v-model="game.playersMaxCount" 
                   min="1" max="50" 
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div class="block pb-2">
            <span>MinAge</span>
            <input type="number" 
                   v-model="game.minAge" 
                   min="1" max="80" 
                    class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div class="block">
            <span>MinPartyTime(min)</span>
            <input type="number" 
                   v-model="game.minPartyTime" 
                   min="1" max="1000" 
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div class="block">
            <span>MaxPartyTime(min)</span>
            <input type="number" 
                   v-model="game.maxPartyTime" 
                   min="1" max="1000" 
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>
        <div class="block">
            <span>ReleaseYear</span>
            <input type="number" 
                   v-model="game.releaseYear" 
                   min="1900" max="2030" 
                   class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   required />
        </div>

        <button type="submit" 
                class="mt-2 w-full px-4 py-2 text-sm text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
            Add
        </button>
        <ErrorMessage :message="errorMessage"></ErrorMessage>
    </form>
</template>

<script>
    import GamesService from "../../services/GameService";

    export default {
        name: 'AddGameView',
        emits: ['close', 'get-games'],
        data() {
            return {
                imageFile: undefined,
                game: {
                    image: '',
                    alias: '',
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
                    && this.game.alias
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
        methods: {
            selectImage() {
                this.imageFile = this.$refs.file.files[0];
            },
            async addGame() {
                if (!this.isValid) return false
                GamesService.Add(this.imageFile, this.game)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-games');
                            return { ok: true }
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
