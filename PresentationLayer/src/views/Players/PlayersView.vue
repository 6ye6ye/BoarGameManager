<template>
    <div class="container container-white">
        <h2 class="d-inline">Players</h2>
        <img class="icon" type="button" @click="showModal" :src="require('/src/assets/icon-add.png')" />

    
        <ModalWindow v-if="isModalVisible" @close="closeModal">
            <template v-slot:body>
                <AddPlayerView @close="closeModal" @get-players="getCreatedPlayers"></AddPlayerView>
            </template>
        </ModalWindow>

        <div class="post">
            <div class="row" style="margin-bottom: 10px;">
            </div>
            <p>{{errorMessage}}</p>

            <table v-if="players.length!=0" class="table">
                <thead>
                    <tr class="filter">
                        <th>Name</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in players" :key="item.Id">
                        <td>{{item.name }}</td>
                        <td>
                            <img class="icon" v-on:click="goToDelete(item.id)" type="button" :src="require('/src/assets/icon-remove.png')" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <p v-else>
                No created players
            </p>
        </div>
    </div>
</template>  
  
<script>  
    import ModalWindow from "../ModalWindow.vue";
    import AddPlayerView from "../Players/AddPlayerView.vue";
    import PlayersService from "../../services/PlayersService";  
    export default {
        name: 'PlayersView',
        data() {
            return {
                isModalVisible: false,
                errorMessage:'',
                players: [],
            };
        },
        computed: {
            url(id) {
               return 'players'+id;
            }
        },

        components: {
            ModalWindow,
            AddPlayerView
        },
        created() {
            this.getCreatedPlayers();
        },
        methods: {
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
            getCreatedPlayers() {
                PlayersService.GetCreatedPlayers().then(response => {
                    this.players = response.data;
                })
                     .catch(e => {
                         this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },
            goToDelete(id) {
                PlayersService.DeletePlayer(id).then(response => {
                    if (response.status == 200) {
                        let i = this.players.map(item => item.id).indexOf(id)
                        this.players.splice(i, 1)
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
