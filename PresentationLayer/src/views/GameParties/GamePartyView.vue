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
                <label>{{gameParty.gameName}}</label>
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
            <GamePartyMembers :gamePartyId="id" />
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
                id: this.$route.params.id.toString(),
                gameParty: undefined,
            }
        },
        created() {
            this.getGameParty();
        },
        components: {
            GamePartyMembers
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
