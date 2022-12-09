<template>
    <div class="container container-white">
        <h1 class="d-inline">Game places</h1>
        <img class="icon" type="button" @click="showModal" :src="require('/src/assets/icon-add.png')" />

        <ModalWindow v-if="isModalVisible" @close="closeModal">
            <template v-slot:body>
                <AddGamePlaceView @close="closeModal" @get-game-places="getGamePlaces"></AddGamePlaceView>
            </template>
        </ModalWindow>

        <div class="post">
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
                            <img class="icon" v-on:click="goToDelete(item.id)" type="button" :src="require('/src/assets/icon-remove.png')" />
                        </td>

                    </tr>
                </tbody>
            </table>
            <p v-else>
                No created game places
            </p>
        </div>
    </div>
</template>  
  
<script>  
    import ModalWindow from "../ModalWindow.vue";
    import AddGamePlaceView from "../GamePlaces/AddGamePlace.vue";
    import GamePlaceService from "../../services/GamePlaceService";  
    export default {
        name: 'GamePlacesView',
        data() {
            return {
                isModalVisible: false,
                errorMessage:'',
                gamePlaces: [],
            };
        },
        computed: {
            url(id) {
               return 'gamePlace'+id;
            }
        },

        components: {
            ModalWindow,
            AddGamePlaceView
        },
        created() {
            this.getGamePlaces();
        },
        methods: {
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
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
