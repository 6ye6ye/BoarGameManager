<template>
    <h1>Game parties list</h1> 
    <button v-on:click="goToAdd()" type="button" class="btn btn-primary">Add game party</button>
    <div class="post">
        <div class="row" style="margin-bottom: 10px;">
        </div>
       <p>{{errorMessage}}</p>
            <table id="gamesTable" class="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Date</th>
                        <th>Game</th>
                        <th>Place</th>
                        <th>Creator</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    
                    <tr v-for="item in gameParties" :key="item.Id">
                        <td>{{item.id}}</td>

                        <td>{{item.date }}</td>
                        <td>{{item.gameName}}</td>
                        <td>{{item.userGamePlace }}</td>
                        <td>{{item.partyCreatorName }}</td>


                        <td><button v-on:click="goToDetails(item.id)" type="button" class="btn btn-info">Details</button></td>
                        <td><button v-on:click="goToDelete(item.id)" type="button" class="btn btn-danger">Delete</button></td>

                    </tr>
                </tbody>
            </table>
        </div>
       
</template>  
  



<script>  



    import GamePartiesService from "../../services/GamePartiesService";  
    export default {
        name: 'GamePartiesView',
      
        data() {
            return {
                errorMessage:'',
                gameParties: [],
            };
        },
        created() {
            this.getGameParties();
        },
         methods: {
            getGameParties() {
                 GamePartiesService.GetAll().then(response => {
                     this.gameParties = response.data;
                    console.log(response.data);
                })
                     .catch(e => {
                         this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },
            goToAdd() {
                this.$router.push({ name: 'AddGamePartyView' })
            },
            goToDetails(id) {
                this.$router.push({ name: 'GamePartyView',params: { id: id } })
            },
            goToDelete(id) {
                GamePartiesService.Delete(id).then(response => {
                    console.log(response.data);
                })
                    .catch(e => {
                        this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },
        },
    }
</script>  
  
<style lang="scss" scoped>  
  
</style>  
