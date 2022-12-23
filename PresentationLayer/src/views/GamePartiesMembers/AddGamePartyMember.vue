<template>
    <form ref="form" class="col-sm" @submit.prevent="addGamePartyMember" method="post">
        <div class="row ">
            <h2>Game party member</h2>
            <div class="form-group ">
                <label class="control-label d-inline">Player</label><span class="required">*</span>
                <img class="icon" type="button" @click="showModal" :src="require('/src/assets/icon-add.png')" />
                <ModalWindow v-if="isModalVisible" @close="closeModal">
                    <template v-slot:title>
                        <h5>New game party</h5>
                    </template>
                    <template v-slot:body>
                        <AddPlayerView @close="closeModal" @get-players="getPlayers"></AddPlayerView>
                    </template>
                </ModalWindow>
                <select v-model="gamePartyMember.playerId" class="form-select" required>
                    <option label="- Select  player -" value="" disabled hidden></option>
                    <option v-for="player in players" v-bind:key="player.id" v-bind:value="player.id"> {{player.name}}</option>
                </select>
            </div>
            <div class="form-group " v-if="hasRoles">
                <label class="control-label">Role*</label>
                <select v-model="gamePartyMember.gameRoleId" class="form-select" required>
                    <option label="- Select  game role -" value="" disabled hidden></option>
                    <option v-for="gameRole in gameRoles" v-bind:key="gameRole.id" v-bind:value="gameRole.id"> {{gameRole.name}}</option>
                </select>
            </div>
            <div class="form-group ">
                <label class="control-label">Points</label>
                <input type="number" v-model="gamePartyMember.points" min="-1000000" max="1000000" class="form-control" required />
            </div>
            <div class="form-group ">
                <label class="control-label">Winner</label>
                <input type="checkbox" v-model="gamePartyMember.isWinner" />
            </div>

        </div>
        <ErrorMessage :message="errorMessage"></ErrorMessage>
        <button type="submit" class="btn btn-primary">Add</button>
    </form>
</template>

<script>
   import PlayersService from "../../services/PlayersService";
    import GameRolesService from "../../services/GameRolesService";
    import GamePartyMemberService from "../../services/GamePartyMemberService";
    import AddPlayerView from "../Players/AddPlayerView.vue";
     import ModalWindow from "../../components/ModalWindow.vue";
    export default {
        name: 'AddGameRoleView',
        props: ['gamePartyId', 'gameId'],
        emits: ['close', 'get-game-party-members'],
        data() {

            return {
                errorMessage:"",
                isModalVisible: false,
                show: false,
                players: [],
                gameRoles: [],
                gamePartyMember: {
                    gamePartyId: this.gamePartyId,
                    playerId: "",
                    gameRoleId: null,
                    points: 0,
                    isWinner: false
                }
            }
        },

        components: {
            AddPlayerView,
            ModalWindow
        },
        created() {
            this.getGameRoles(this.gameId);
            this.getPlayers();
        },
        computed: {
            isValid() {
                return (this.gamePartyMember.gameRoleId || this.gameRoles.length == 0)
                    && (this.gamePartyMember.points || this.gamePartyMember.points==0)
                    && this.gamePartyMember.playerId
            },
            hasRoles() {
                return this.gameRoles.length!=0
            }
        },
        methods: {
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
            async addGamePartyMember() {
                if (!this.isValid) return false
                GamePartyMemberService.Add(this.gamePartyMember)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-game-party-members');
                        }
                    })
                    .catch(e => {
                        this.errorMessage = e.response;
                        console.log(e);
                    });
            },
            getGameRoles: function () {
                GameRolesService.GetGameRolesByGame(this.gameId)
                    .then(response => {
                        this.gameRoles = response.data
                    })
                    .catch(e => {
                        this.errorMessage = e.response.data;
                        console.log(e);
                    });
            },
            getPlayers: function () {
                PlayersService.GetPlayersForUser()
                    .then(response => {
                        this.players = response.data
                    })
                    .catch(e => {
                        this.errorMessage = e.response.data;
                        console.log(e);
                    });
            },
        }
    }
</script>

<style lang="scss" scoped>
</style>
