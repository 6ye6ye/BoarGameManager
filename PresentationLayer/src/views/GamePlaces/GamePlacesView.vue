<template>
    <div class="container container-white">
        <h1 class="d-inline">Game places</h1>
        <img class="icon" type="button" @click="showModal" :src="require('/src/assets/icon-add.png')" />

        <ModalWindow v-if="isModalAddVisible" @close="closeAddModal">
            <template v-slot:body>
                <AddGamePlaceView @close="closeAddModal" @get-game-places="getGamePlaces"></AddGamePlaceView>
            </template>
        </ModalWindow>


        <ModalWindow v-if="isModalEditVisible" @close="closeEditModal">
            <template v-slot:body>
                <EditGamePlaceView :gamePlaceId="currentId" @close="closeEditModal" @get-game-places="getGamePlaces"></EditGamePlaceView>
            </template>
        </ModalWindow>


            <div class="row" style="margin-bottom: 10px;">
            </div>
            <p>{{errorMessage}}</p>
            <table v-if="gamePlaces.length!=0" class="table ">
                <thead>
                    <tr class="filter">
                        <th>Name</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in gamePlaces" :key="item.Id">
                        <td>{{item.name }}</td>
                        <td>
                            <img class="icon" @click="showEditModal(item.id)" type="button" :src="require('/src/assets/icon-edit.png')" />
                            <img class="icon" v-on:click="goToDelete(item.id)" type="button" :src="require('/src/assets/icon-remove.png')" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <p v-else>
                No created game places
            </p>
        </div>
  
</template>  
  
<script>  
    import ModalWindow from "../ModalWindow.vue";
    import AddGamePlaceView from "../GamePlaces/AddGamePlace.vue";
    import EditGamePlaceView from "../GamePlaces/EditGamePlace.vue";
    import GamePlaceService from "../../services/GamePlaceService";  
    export default {
        name: 'GamePlacesView',
        data() {
            return {
                isModalVisible: false,
                errorMessage:'',
                gamePlaces: [],
                isModalAddVisible: false,
                isModalEditVisible: false,
                currentId: '',
            };
        },
        computed: {
            url(id) {
               return 'gamePlace'+id;
            }
        },

        components: {
            ModalWindow,
            AddGamePlaceView,
            EditGamePlaceView
        },
        created() {
            this.getGamePlaces();
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
            getGamePlaces() {
                GamePlaceService.GetGamePlaces().then(response => {
                     this.gamePlaces = response.data;
                })
                     .catch(e => {
                         this.errorMesage = e.response.data;
                        console.log(e);
                    });
            },
            goToDelete(id) {
                GamePlaceService.DeleteGamePlace(id).then(response => {
                    if (response.status == 200) {
                        let i = this.gamePlaces.map(item => item.id).indexOf(id)
                        this.gamePlaces.splice(i, 1)
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
