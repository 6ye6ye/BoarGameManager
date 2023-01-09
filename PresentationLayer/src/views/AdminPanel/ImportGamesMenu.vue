<template>
    <div class="w-full">
        <header class="text-center mb-4">
            <h2 class="text-2xl  text-gray-800 font-bold"> Import games from "Tesera"</h2>
            <ErrorMessage v-show="errorMessage!=''" :message="errorMessage" class="mt-2"></ErrorMessage>
            <InfoMessage v-show="currentCount>0" :message="getInfoMessage()" class="mt-2"></InfoMessage>
            <div v-show="status!=''">
                <svg aria-hidden="true" class="inline w-8 h-8 mr-2 text-gray-200 animate-spin dark:text-gray-600 fill-blue-600" viewBox="0 0 100 101" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z" fill="currentColor" />
                    <path d="M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z" fill="currentFill" />
                </svg>
                <p > {{status}}</p>
            </div>
          
        </header>
        <div class="grid gap-4 md:grid-cols-2 grid-cols-1 w-full flex-wrap justify-items-stretch  mb-4">
            <div class="grow  bg-white rounded-lg shadow-md p-6 ">
                <h3 class="text-xl text-center text-gray-900 font-bold pb-2">By top game rate</h3>
                <hr />
                <ul class="pt-2">
                    <li class="w-full flex items-end">
                        <span>Count:</span>
                        <input type="number"
                               v-model="countByRate"
                               min="0" max="100"
                               class="ml-2 pl-4 grow mt-1  mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500" />
                    </li>
                </ul>
                <button @click="getGames('top-by-rate')"
                        type="button"
                        class="mt-2 w-full px-4 py-2 text-sm text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
                    Download
                </button>
            </div>
            <div class="grow  bg-white rounded-lg shadow-md p-6">
                <h3 class="text-xl text-center text-gray-900 font-bold pb-2">Last added</h3>
                <hr />
                <ul class="pt-2">
                    <li class="w-full flex items-end">
                        <span>Count:</span>
                        <input type="number"
                               v-model="countLastAdded"
                               min="0" max="100"
                               class="ml-2 pl-4 grow mt-1  mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500" />
                    </li>
                </ul>
                <button @click="getGames('last-added')"
                        type="button"
                        class="mt-2 w-full px-4 py-2 text-sm text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
                    Download
                </button>
            </div>
            <div class="grow   bg-white rounded-lg shadow-md p-6">
                <h3 class="text-xl text-center text-gray-900 font-bold pb-2">By user collection</h3>
                <hr />
                <ul class="pt-2">
                    <li class="w-full flex items-end">
                        <span>Count:</span>
                        <input placeholder="Input games count"
                               type="number"
                               min="0" max="100"
                               v-model="countByUser"
                               class="ml-2 pl-4 grow mt-1  border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500" />
                    </li>
                    <li class="w-full flex items-end">
                        <span>User name:</span>
                        <input placeholder="Input  name"
                               type="text"
                               v-model="userName"
                               class="ml-2 pl-4 grow mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500" />
                    </li>
                </ul>
                <button @click="getGames('by-user-collection')"
                        type="button"
                        class="mt-2 w-full px-4 py-2 text-sm text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
                    Download
                </button>
            </div>
            <div class="grow  min-w-md bg-white rounded-lg shadow-md p-6">
                <h3 class="text-xl text-center text-gray-900 font-bold pb-2">By game alias</h3>
                <hr />
                <ul class="pt-2">
                    <li class="w-full flex items-end">
                        <label>Alias: </label>
                        <input placeholder="Input game alias"
                               type="text"
                               v-model="alias"
                               class="ml-2 pl-4 grow mt-1  mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500" />
                    </li>
                </ul>
                <button @click="getGames('by-alias')"
                        type="button"
                        class="mt-2 w-full px-4 py-2 text-sm text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
                    Download
                </button>
            </div>
        </div>
        <div v-show="games.length>0">
            <h2 class="text-2xl text-center text-gray-900 font-bold"> Added games </h2>
            <GameTable :games="games" />
        </div>
    </div>
</template>

<script>
    import GameParserService from "../../services/GameParserService";
    import GameTable from "../Games/GamesTable.vue";
    export default {
        name: 'GetGamesFromApiView',
        data() {
            return {
                status: '',
                errorMessage: '',
                countByRate: 0,
                countLastAdded: 0,
                countByUser: 0,
                userName: '',
                currentCount: 0,
                alias: '',
                games: []
            }
        },
        components: {
            GameTable
        },
        methods: {
            async getGames(param) {
                this.errorMessage = '';
                this.status = 'loading...'
                switch (param) {
                    case 'top-by-rate':
                        await this.getGamesByRateFromApi();
                        break;
                    case 'last-added':
                        await this.getLastAddedGames();
                        break;
                    case 'by-user-collection':
                        await this.getGamesByUserCollection();
                        break;
                    case 'by-alias':
                        await this.getGamesByAlias();
                        break;
                    default:
                        this.status = ''
                        this.errorMessage = "Get type not fount"
                        break;
                }
                this.status = '';
            },
            async getGamesByRateFromApi() {

                await GameParserService.GetTopByRate(this.countByRate)
                    .then(response => {
                        if (response.status == 200) {
                            this.games = this.games.concat(response.data);
                            this.currentCount += this.countByRate;
                        }
                    })
                    .catch(e => {
                        this.errorMessage = e.response.data;
                    });

            },
            async getLastAddedGames() {

                await GameParserService.GetLastAddedGamesFromApi(this.countLastAdded)
                    .then(response => {
                        if (response.status == 200) {
                            this.games = this.games.concat(response.data);
                            this.currentCount += this.countLastAdded;

                        }
                    })
                    .catch(e => {
                        this.errorMessage = e.response.data;
                    });
            },
            async getGamesByUserCollection() {
                if (this.userName.length != 0)
                    await GameParserService.GetByUserCollection(this.userName, this.countByUser)
                        .then(response => {
                            if (response.status == 200) {
                                this.games = this.games.concat(response.data);
                                this.currentCount += this.countByUser;
                            }
                        })
                        .catch(e => {
                            this.errorMessage = e.response.data;
                        });
                else
                    this.errorMessage = "User name required";

            },
            async getGamesByAlias() {
                if (this.alias.length != 0)
                    await GameParserService.GetByGameAlias(this.alias)
                        .then(response => {
                            if (response.status == 200) {
                                this.games.push(response.data);
                                this.currentCount += 1;
                            }
                        })
                        .catch(e => {
                            this.errorMessage = e.response.data;
                        });
                else
                    this.errorMessage = "Alias required";
            },
            getInfoMessage() {
                return this.games.length + '/' + this.currentCount + ' games was added'
            }
        }
    }
</script>

<style lang="scss" scoped>
</style>  