<template>
    <div class="container container-white">
        <ModalWindow v-if="isModalEditVisible" @close="closeEditModal">
            <template v-slot:body>
                <EditGamePartyView :gamePartyId="gameParty.id" @close="closeEditModal" @get-game-party="getGameParty"></EditGamePartyView>
            </template>
        </ModalWindow>
        <h1>Game party</h1>
        <div class="extended-title">
            <p class="d-inline">Info</p>
            <img class="icon" @click="showEditModal()" type="button" :src="require('/src/assets/icon-edit.png')" />
        </div>
        <div class="row align-items-center">
            <div>
                <label>Date: </label>
                <label for="gameParty.date">{{gameParty.date}}</label>
            </div>
            <div>
                <label>Game: </label>
                <label>{{gameParty.game.name}}</label>
            </div>
            <div>
                <label>Place: </label>
                {{gameParty.userGamePlace.name}}
            </div>
            <div>
                <label>Party creator: </label>
                {{gameParty.partyCreatorName}}
            </div>
        </div>
        <div>
            <GamePartyMembers :gameId="gameParty.game.id" :gamePartyId="gameParty.id" :isCreator="isCreator" />
        </div>
    </div>
</template>

<script>
    import ModalWindow from "../ModalWindow.vue";
    import UsersService from "../../services/UsersService";
    import GamesPartyService from "../../services/GamePartiesService";
    import EditGamePartyView from "../GameParties/EditGameParty.vue";
    import GamePartyMembers from "../GamePartiesMembers/GamePartiesMembers.vue";
    export default {
        name: 'GamePartyView',
        data() {
            return {
                gameParty: {
                    id: this.$route.params.id.toString(),
                    date: '',
                    game: {
                        name: '',
                        id: ''
                    },
                    userGamePlace: {
                        id: '',
                        name:'',
                    },
                   
                    partyCreatorId: '',
                    partyCreatorName: ''
                },
                isCreator: false,
                isModalEditVisible: false
            }
        },

        created() {
            this.getGameParty();
        },
        components: {
            GamePartyMembers,
            EditGamePartyView,
            ModalWindow
        },
        methods: {
            showEditModal() {
                this.isModalEditVisible = true;
            },
            closeEditModal() {
                this.isModalEditVisible = false;
            },
            checkIsCreator() {
                UsersService.GetCurrent().then(response => {
                    this.isCreator = this.gameParty.partyCreatorId == response.data.id
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getGameParty() {
                GamesPartyService.GetById(this.gameParty.id).then(response => {
                    this.gameParty = response.data;
                    this.checkIsCreator();
                })
                    .catch(e => {
                        console.log(e);
                    });
            }
        }
    }

</script>

<style lang="scss" scoped>
</style>
