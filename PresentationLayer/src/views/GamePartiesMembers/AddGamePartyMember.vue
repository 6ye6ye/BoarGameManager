<template>

    <div class="row ">
        <div class="col-md-4 mx-auto">
            <div class="form-group ">
                <label class="control-label">Player</label><span class="required">*</span>

                <button type="button" class="btn btn-primary" @click="showModal">+</button>

                <!--//  <button v-on:click="showGamePartyMemberAdd= !showGamePartyMemberAdd" class="btn btn-primary">Show add party member window</button>-->
                <ModalWindow v-show="isModalVisible" @close="closeModal">
                    <template v-slot:body>
                        <AddPlayerView @close="closeModal" @get-players="getPlayers"></AddPlayerView>
                    </template>
                </ModalWindow>


                <select v-model="gamePartyMember.playerId" class="form-select">
                    <option value=0>- Select  player -</option>
                    <option v-for="player in players" v-bind:key="player.id" v-bind:value="player.id"> {{player.name}}</option>
                </select>

                <!--//  <AddGamePartyMemberView ref="modal" :gameId="gameId" :gamePartyId="gamePartyId" />-->
            </div>
            <div class="form-group ">
                <label class="control-label">Role</label><span class="required">*</span>
                <select v-model="gamePartyMember.gameRoleId" class="form-select">
                    <option value=0>- Select  game role -</option>
                    <option v-for="gameRole in gameRoles" v-bind:key="gameRole.id" v-bind:value="gameRole.id"> {{gameRole.name}}</option>
                </select>
            </div>
            <div class="form-group ">
                <label class="control-label">Points</label>
                <input type="number" v-model="gamePartyMember.points" class="form-control" />
            </div>
            <div class="form-group ">
                <label class="control-label">Winner</label>
                <input type="checkbox" v-model="gamePartyMember.isWinner" />
            </div>
            <div class="form-group">
                <label class="control-label"></label>
                <button v-on:click="addGamePartyMember()" type="button" class="btn btn-success ">Add</button>
            </div>
        </div>
    </div>

</template>

<script>
    import PlayersService from "../../services/PlayersService";
    import GameRolesService from "../../services/GameRolesService";
    import GamePartyMemberService from "../../services/GamePartyMemberService";
    import AddPlayerView from "../Players/AddPlayerView.vue";
    import ModalWindow from "../ModalWindow.vue";
    export default {
        name: 'AddGameRoleView',
        props: ['gamePartyId', 'gameId'],
        data() {

            return {
                isModalVisible: false,
                show: false,
                players: [],
                gameRoles: [],
                gamePartyMember: {
                    gamePartyId: this.gamePartyId,
                    playerId: 0,
                    gameRoleId: 0,
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
        methods: {
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
            addGamePartyMember: function () {
                GamePartyMemberService.Add(this.gamePartyMember)
                    .then(response => {
                        console.log(response.data);
                        this.$emit('close');
                        this.$emit('get-game-party-members');
                    })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getGameRoles: function () {
                GameRolesService.GetGameRolesByGame(this.gameId)
                    .then(response => {
                        this.gameRoles = response.data
                    })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getPlayers: function () {
                PlayersService.GetPlayersForUser()
                    .then(response => {
                        this.players = response.data
                    })
                    .catch(e => {
                        console.log(e);
                    });
            },

        }
    }

</script>

<style lang="scss" scoped>
</style>
