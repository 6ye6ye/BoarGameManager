<template>
    <h1>Game parties list</h1>
    <button type="button" class="btn btn-primary" @click="showModal">+</button>
  
   <ModalWindow v-if="isModalVisible" @close="closeModal">
        <template v-slot:body>
            <AddGamePartyView @close="closeModal" @get-game-parties="getGameParties" ></AddGamePartyView>
        </template>
    </ModalWindow>

    <div class="post">
        <div class="row" style="margin-bottom: 10px;">
        </div>
        <p>{{errorMessage}}</p>
        <table id="gamesTable" class="table">
            <thead>
                <tr>
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
                    <td>{{item.date }}</td>
                    <td>{{item.game.name}}</td>
                    <td>{{item.userGamePlaceName }}</td>
                    <td>{{item.partyCreatorName }}</td>
                    <td>
                        <div>
                             <button v-on:click="goToDetails(item.id)" type="button" class="btn btn-info">Details</button>
                             <button v-on:click="goToDelete(item.id)" type="button" class="btn btn-danger">Delete</button>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>  
  
<script>  
    import ModalWindow from "../ModalWindow.vue";
    import AddGamePartyView from "../GameParties/AddGamePartyView.vue";
    import GamePartiesService from "../../services/GamePartiesService";  
    export default {
        name: 'GamePartiesView',
      
        data() {
            return {
                isModalVisible: false,
                errorMessage:'',
                gameParties: [],
            };
        },
        computed: {
            url(id) {
               return 'gameParty'+id;
            }
        },

        components: {
            ModalWindow,
            AddGamePartyView
        },
        created() {
            this.getGameParties();
        },
        methods: {
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
            getGameParties() {
                 GamePartiesService.GetAll().then(response => {
                     this.gameParties = response.data;
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
                    if (response.status == 200) {
                        let i = this.gameParties.map(item => item.id).indexOf(id)
                        this.gameParties.splice(i, 1)
                    }
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
