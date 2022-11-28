<template>
    <div class="row ">
        <div class="col-md-4 mx-auto">
            <div class="form-group ">
                <label class="control-label">Player</label><span class="required">*</span>
                <button type="button" class="btn btn-primary" @click="showModal">+</button>
                <ModalWindow v-show="isModalVisible" @close="closeModal">
                    <template v-slot:body>
                        <AddPlayerView @close="closeModal" @get-players="getPlayers"></AddPlayerView>
                    </template>
                </ModalWindow>
                <select v-model="gamePartyMember.playerId" class="form-select" required>
                    <option value="" selected disabled hidden>- Select  player -</option>
                    <option v-for="player in players" v-bind:key="player.id" v-bind:value="player.id"> {{player.name}}</option>
                </select>
            </div>
            <div class="form-group ">
                <label class="control-label">Role*</label>
                <select v-model="gamePartyMember.gameRoleId" class="form-select" >
                    <option value="" selected disabled hidden>- Select  game role -</option>
                    <option v-for="gameRole in gameRoles" v-bind:key="gameRole.id" v-bind:value="gameRole.id"> {{gameRole.name}}</option>
                </select>
            </div>
            <div class="form-group ">
                <label class="control-label">Points</label>
                <input type="number" v-model="gamePartyMember.points" min="0" max="1000000" class="form-control" required />
            </div>
            <div class="form-group ">
                <label class="control-label">Winner</label>
                <input type="checkbox" v-model="gamePartyMember.isWinner" />
            </div>
            <div class="form-group">
                <label class="control-label"></label>
                <button type="button" @click="addGamePartyMember" class="btn btn-success ">Add</button>
            </div>
        </div>
        <ErrorMessage :errorMessage="errMessage" />
    </div>
</template>

<script>
    import ErrorMessage from "../ErrorMessage.vue";
    import PlayersService from "../../services/PlayersService";
    import GameRolesService from "../../services/GameRolesService";
    import GamePartyMemberService from "../../services/GamePartyMemberService";
    import AddPlayerView from "../Players/AddPlayerView.vue";
    import ModalWindow from "../ModalWindow.vue";
    export default {
        name: 'AddGameRoleView',
        props: ['gamePartyId', 'gameId'],
        emits: ['close', 'get-game-party-members'],
        data() {

            return {
                errMesage:"",
                isModalVisible: false,
                show: false,
                players: [],
                gameRoles: [],
                gamePartyMember: {
                    gamePartyId: this.gamePartyId,
                    playerId: "",
                    gameRoleId: "",
                    points: 0,
                    isWinner: false
                }
            }
        },
        components: {
            AddPlayerView,
            ModalWindow,
            ErrorMessage
        },
        created() {
            this.getGameRoles(this.gameId);
            this.getPlayers();
        },
        methods: {
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
            addGamePartyMember() {
              
                GamePartyMemberService.Add(this.gamePartyMember)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-game-party-members');
                        }
                    })
                    .catch(e => {
                        this.errMesage = e.response;
                        console.log(e);
                    });
            },
            getGameRoles: function () {
                GameRolesService.GetGameRolesByGame(this.gameId)
                    .then(response => {
                        this.gameRoles = response.data
                    })
                    .catch(e => {
                        this.errMesage = e.response.data;
                        console.log(e);
                    });
            },
            getPlayers: function () {
                PlayersService.GetPlayersForUser()
                    .then(response => {
                        this.players = response.data
                    })
                    .catch(e => {
                        this.errMesage = e.response.data;
                        console.log(e);
                    });
            },
        }
    }
</script>

<style lang="scss" scoped>
</style>
