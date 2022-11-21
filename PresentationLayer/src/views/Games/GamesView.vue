<template>
    <h1>Game list</h1>
    <!--<button v-on:click="goToAdd()" type="button" class="btn btn-primary">Add game</button>-->

    <button type="button" class="btn btn-primary" @click="showModal">+</button>

    <ModalWindow v-show="isModalVisible" @close="closeModal">
        <template v-slot:body>
            <AddGameView @close="closeModal" @get-games="getGames"></AddGameView>
        </template>
    </ModalWindow>

    <button v-on:click="getUserGames()" type="button" class="btn btn-danger">MyGames</button>

    <div class="post">
        <div class="row" style="margin-bottom: 10px;">
        </div>

        <table id="gamesTable" class="table">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Image</th>
                    <th>Name</th>
                    <th>Ru/Eng</th>
                    <th>Rate</th>
                    <th>Min player count</th>
                    <th>Max player count</th>
                    <th>Min age</th>
                    <th>Min party time</th>
                    <th>Max party time</th>
                    <th>Release year</th>
                    <th>Added</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>

                <tr v-for="item in games" :key="item.Id">
                    <td>{{item.id}}</td>
                    <td>
                        <img v-bind:src="item.image" width="50" height="80" />
                    </td>

                    <td>{{item.name }}</td>
                    <td>{{item.nameRu}}|{{item.nameEng}}</td>
                    <td>{{item.rating }}</td>
                    <td>{{item.playersMinCount }}</td>
                    <td>{{item.playersMaxCount }}</td>
                    <td>{{item.minAge }}</td>
                    <td>{{item.minPartyTime }}</td>
                    <td>{{item.maxPartyTime }}</td>
                    <td>{{item.releaseYear }}</td>
                    <td v-show="isAuth"><input class="form-check-input" type="checkbox" v-model="item.addedToUserGames" /> </td>
                    <td><button v-on:click="goToDetails(item.id)" type="button" class="btn btn-info">Details</button></td>
                    <td><button v-show="!isMyGamesPage" v-on:click="goToAddToUserGames(item.id)" type="button" class="btn btn-danger">Add to my</button></td>

                    <td><button v-show="role=='Admin' && !isMyGamesPage" v-on:click="goToDelete(item.id)" type="button" class="btn btn-danger">Delete</button></td>

                    <td><button v-show="isMyGamesPage" v-on:click="goToDeleteFromUserGames(item.id)" type="button" class="btn btn-danger">Delete</button></td>

                </tr>
            </tbody>
        </table>
    </div>

</template>  
  



<script>  

    import ModalWindow from "../ModalWindow.vue";
    import AddGameView from "../Games/AddGameView.vue";
    import GamesService from "../../services/GameService";  
    import UserGamesService from "../../services/UserGamesService";  
    export default {
        name: 'GamesView',
      
        data() {
            return {
                isAuth: localStorage.getItem('isAuth'),
                role: localStorage.role,
                isModalVisible: false,
                isMyGamesPage: false,
                games: [],
            };
        },
        components: {
            ModalWindow,
            AddGameView
        },
        created() {
            this.getGames();
            this.isAuth = localStorage.isAuth;
            this.role= localStorage.role
        },
        methods: {
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
            getGames() {
                GamesService.GetAll().then(response => {
                    this.games = response.data;
                    this.isMyGamesPage = false;
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getUserGames() {
                UserGamesService.GetUserGames().then(response => {
                    this.games = response.data;
                    this.isMyGamesPage = true;
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToAdd() {
                this.$router.push({ name: 'AddGameView' })
            },
            goToDetails(id) {
                this.$router.push({ name: 'GameView',params: { id: id } })
            },
            goToDelete(id) {
                GamesService.Delete(id).then(response => {
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            
            goToAddToUserGames(id) {
                UserGamesService.Add(id).then(response => {
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToDeleteFromUserGames(id) {
                UserGamesService.Delete(id).then(response => {
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            
        },
    }
</script>  
  
<style lang="scss" scoped>  
  
</style>  
