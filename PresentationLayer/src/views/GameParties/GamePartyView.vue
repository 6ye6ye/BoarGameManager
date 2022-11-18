<template>
    <div class="container">

        <h4>Game party</h4>
        <hr />
        <dl class="row">
            <dt class="col-sm-2">
               <label>Date </label>
            </dt>
            <dd class="col-sm-10">
                <label>{{gameParty.date}}</label>
            </dd>
            <dt class="col-sm-2">
                <label>Game </label>
            </dt>
            <dd class="col-sm-10">
                <label>{{gameParty.game.name}}</label>
            </dd>
            <dt class="col-sm-2">
                <label>Place </label>
            </dt>
            <dd class="col-sm-10">
                {{gameParty.userGamePlaceName}}
            </dd>
            <dt class="col-sm-2">
                <label>Party creator </label>
            </dt>
            <dd class="col-sm-10">
                {{gameParty.partyCreatorName}}
            </dd>
  
        </dl>

        <div>

            <GamePartyMembers  :gameId="gameParty.game.id" :gamePartyId="id" />
            <!--  <button сlass="show-add-member-modal-button" @click="showAddMemberModal">add member</button>-->
            <!--  <GamePartyMembers ref="membermodal" :gameId="gameParty.game.id" :gamePartyId="id" />-->
        </div>
    </div>
</template>

<script>


    import GamesPartyService from "../../services/GamePartiesService";
    import GamePartyMembers from "../GamePartiesMembers/GamePartiesMembers.vue";
 

    export default {
        name: 'GamePartyView',
        data() {
            return {
                id: this.$route.params.id,
                gameParty: undefined,
            }
        },
        created() {
            this.getGameParty();
        },
        components: {
            GamePartyMembers,
        },

        methods: {
           
            getGameParty() {
                GamesPartyService.GetById(this.id).then(response => {
                    this.gameParty = response.data;
                    console.log(response.data);
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
