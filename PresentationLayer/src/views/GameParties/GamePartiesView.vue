<template>
    <div class="container container-white ">
        <div>
            <h1 class="d-inline">Game parties list</h1>
            <img class="icon" type="button"  @click="showModal" :src="require('/src/assets/icon-add.png')" />
        </div>
        <ModalWindow v-if="isModalVisible" @close="closeModal">
            <template v-slot:body>
                <AddGamePartyView @close="closeModal" @get-game-parties="getGameParties"></AddGamePartyView>
            </template>
        </ModalWindow>

        <div class="post">
            <div class="row" style="margin-bottom: 10px;">
            </div>
            <p>{{errorMessage}}</p>
            <table id="gamesTable" class="table">
                <thead>
                    <tr class="filter">
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
                        <td>{{item.userGamePlace.name }}</td>
                        <td>{{item.partyCreatorName }}</td>
                        <td>
                            <div>
                                <img class="icon" v-on:click="goToDetails(item.id)" type="button" :src="require('/src/assets/icon-details.png')" />
                                <img class="icon" v-on:click="goToDelete(item.id)" type="button" :src="require('/src/assets/icon-remove.png')" />
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>  
  
<script>  
    import ModalWindow from "../ModalWindow.vue";
    import AddGamePartyView from "../GameParties/AddGameParty.vue";
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
