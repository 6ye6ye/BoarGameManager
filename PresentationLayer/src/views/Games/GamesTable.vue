<template>
    <div class="d-flex">
        <div class="container ">

            <ModalWindow v-if="isModalEditVisible" @close="closeEditModal">
                <template v-slot:body>
                    <EditGameView :gameId="currentId" @get-games="getGames" @close="closeEditModal"></EditGameView>
                </template>
            </ModalWindow>

            <table class="table ">
                <thead>
                    <tr class="filter">
                        <th>Image</th>
                        <th>Name </th>
                        <th>NameRu </th>
                        <th>NameEng </th>
                        <th>Release Year</th>
                        <th>Players</th>
                        <th>Party time</th>
                        <th> Min age</th>
                        <th>Game info Short</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in games" :key="item.id">
                        <td><img class="game-image" v-bind:src="item.image"></td>
                        <td>{{item.name }}</td>
                        <td>{{item.nameRu}}</td>
                        <td>{{item.nameEng}}</td>
                        <td>{{item.releaseYear}}</td>
                        <td>{{item.playersMinCount }}-{{item.playersMaxCount }}</td>
                        <td>{{item.minPartyTime }}-{{item.maxPartyTime }} </td>
                        <td>{{item.minAge }}</td>
                        <td class="text-justify">{{item.gameInfoShort }}</td>
                        <td>
                            <div>
                                <img class="icon" v-on:click="showEditModal(item.id)" type="button" :src="require('/src/assets/icon-edit.png')" />
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
    import EditGameView from "../Games/EditGameView.vue";
    import GamesService from "../../services/GameService";
    export default {
        name: 'GamesView',
        props: ['games'],
        data() {
            return {
                isModalEditVisible: false,
                currentId: '',
            };
        },
    
        components: {
            ModalWindow,
            EditGameView,
        },
       
        methods: {
            showEditModal(id) {
                this.currentId = id;
                this.isModalEditVisible = true;
            },
            closeEditModal() {
                this.isModalEditVisible = false;
            },

            goToDelete(id) {
                GamesService.Delete(id).then(response => {
                    if (response.status == 200) {
                        let i = this.games.map(item => item.id).indexOf(id)
                        this.games.splice(i, 1)
                    }
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
        },
    }
</script>

<style>
</style>
