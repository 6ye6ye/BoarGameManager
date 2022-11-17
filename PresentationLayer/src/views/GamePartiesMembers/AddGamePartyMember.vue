<template>
    <div class="row ">
        <div class="col-md-4 mx-auto">
            <div class="form-group">
                <label class="form-label">Name</label>
                <input type="text" v-model="role.name" class="form-control" />
            </div>
            <div class="form-group ">
                <label class="control-label">Player</label><span class="required">*</span>
                <select v-model="gamePartyMember.playerId" class="form-select">
                    <option value=0>- Select  player -</option>
                    <option v-for="player in players" v-bind:key="player.id" v-bind:value="player.id"> {{player.name}}</option>
                </select>
            </div>
            <div class="form-group ">
                <label class="control-label">Role</label><span class="required">*</span>
                <select v-model="gamePartyMember.gameRoleId" class="form-select">
                    <option value=0>- Select  game role -</option>
                    <option v-for="gameRole in gameRoles" v-bind:key="gameRole.id" v-bind:value="gameRole.id"> {{gameRole.name}}</option>
                </select>
            </div>

            <div class="form-group">
                <button v-on:click="addGamePartyMember()" type="button" class="btn btn-success ">Confirm</button>
            </div>
        </div>
    </div>

</template>

<script>


    import GamePartyMemberService from "../../services/GamePartyMemberService";


    export default {
        name: 'AddGameRoleView',
        data() {
            return {
                players: [],
                gameRoles:[],
                gamePartyMember: {
                    gamePartyId: this.$route.params.id * 1,
                    playerId: 0,
                    gameRoleId:0,
                    points: 0,
                    isWinner: false
                }
            }
        },
        methods: {
            addGamePartyMember: function () {
                GamePartyMemberService.Add(this.gamePartyMember)
                //GamesService.AddGame(this.game)
                    .then(response => {
                        console.log(response.data);
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
