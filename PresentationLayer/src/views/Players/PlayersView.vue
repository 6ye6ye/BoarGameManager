<template>
    <div class="container container-white">
        <h2 class="d-inline">Players</h2>
        <img class="icon" type="button" @click="showAddModal" :src="require('/src/assets/icon-add.png')" />


        <ModalWindow v-if="isModalAddVisible" @close="closeAddModal">
            <template v-slot:body>
                <AddPlayerView @close="closeAddModal" @get-players="getCreatedPlayers"></AddPlayerView>
            </template>
        </ModalWindow>

        <ModalWindow v-if="isModalEditVisible" @close="closeEditModal">
            <template v-slot:body>
                <EditPlayerView :playerId="currentId" @get-players="getCreatedPlayers" @close="closeEditModal"></EditPlayerView>
            </template>
        </ModalWindow>

      
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
                            <img class="icon" @click="showEditModal(item.id)" type="button" :src="require('/src/assets/icon-edit.png')" />
                            <img class="icon" @click="goToDelete(item.id)" type="button" :src="require('/src/assets/icon-remove.png')" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <p v-else>
                No created players
            </p>
        </div>

</template>  
  
<script>  
    import ModalWindow from "../ModalWindow.vue";
    import AddPlayerView from "../Players/AddPlayerView.vue";
    import EditPlayerView from "../Players/EditPlayerView.vue";
    import PlayersService from "../../services/PlayersService";  
    export default {
        name: 'PlayersView',
        data() {
            return {
                isModalAddVisible: false,
                isModalEditVisible: false,
                errorMessage:'',
                players: [],
                currentId: '',
            };
        },
        computed: {
            url(id) {
               return 'players'+id;
            }
        },
        components: {
            ModalWindow,
            AddPlayerView,
            EditPlayerView
        },
        created() {
            this.getCreatedPlayers();
        },
        methods: {
            showAddModal() {
                this.isModalAddVisible = true;
            },
            closeAddModal() {
                this.isModalAddVisible = false;
            },
            showEditModal(id) {
                this.currentId = id;
                this.isModalEditVisible = true;
            },
            closeEditModal() {
                this.isModalEditVisible = false;
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
