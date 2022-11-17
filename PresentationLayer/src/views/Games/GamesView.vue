<template>
    <h1>Game list</h1> 
    <button v-on:click="goToAdd()" type="button" class="btn btn-primary">Add game</button>
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

                        <td><button v-on:click="goToDetails(item.id)" type="button" class="btn btn-info">Details</button></td>
                        <td><button v-on:click="goToDelete(item.id)" type="button" class="btn btn-danger">Delete</button></td>

                    </tr>
                </tbody>
            </table>
        </div>
       
</template>  
  



<script>  



    import GamesService from "../../services/GameService";  
    export default {
        name: 'GamesView',
      
        data() {
            return {
                games: [],
            };
        },
        created() {
            this.getGames();
        },
         methods: {
            getGames() {
                GamesService.GetAll().then(response => {
                    this.games = response.data;
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
        },
    }
</script>  
  
<style lang="scss" scoped>  
  
</style>  
