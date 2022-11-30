<template>
    <div class="container">

        <h4>Game party</h4>
        <hr />
        <dl class="row">
            <dt class="col-sm-2">
                <label>Date </label>
            </dt>
            <dd class="col-sm-10">
                <label for="gameParty.date">{{gameParty.date}}</label>
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
            <GamePartyMembers :gameId="gameParty.game.id" :gamePartyId="id" :isCreator="isCreator" />
        </div>
    </div>
</template>

<script>
    import UsersService from "../../services/UsersService";
    import GamesPartyService from "../../services/GamePartiesService";
    import GamePartyMembers from "../GamePartiesMembers/GamePartiesMembers.vue";
    export default {
        name: 'GamePartyView',
        data() {
            return {
                id: this.$route.params.id,
                gameParty: {
                    date: '',
                    game: {
                        name:'',
                        id: ''
                    },
                    userGamePlaceName: '',
                    partyCreatorId: '',
                    partyCreatorName: ''
                },
                isCreator: false
            }
        },
        created() {
            this.getGameParty();
            this.checkIsCreator();
        },
        components: {
            GamePartyMembers,
        },
        
        methods: {
            checkIsCreator() {
                UsersService.GetCurrent().then(response => {
                    this.isCreator = this.gameParty.partyCreatorId == response.data.id
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getGameParty() {
                GamesPartyService.GetById(this.id).then(response => {
                    this.gameParty = response.data;
                 
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
