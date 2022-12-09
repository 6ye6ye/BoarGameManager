<template>
    <div class="container container-white">

        <h1>Game party</h1>
        <p class="extended-title">Info</p>
        <div class="row align-items-center">
            <div>
                <label>Date </label>


                <label for="gameParty.date">{{gameParty.date}}</label>
            </div>
            <div>
                <label>Game </label>

                <label>{{gameParty.game.name}}</label>
            </div>
            <div>
                <label>Place </label>

                {{gameParty.userGamePlaceName}}
            </div>
            <div>
                <label>Party creator </label>

                {{gameParty.partyCreatorName}}
            </div>

        </div>
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
                        name: '',
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
        },
        components: {
            GamePartyMembers,
        },
        methods: {
            checkIsCreator() {
                UsersService.GetCurrent().then(response => {
                    this.isCreator = this.gameParty.partyCreatorId == response.data.id
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getGameParty() {
                GamesPartyService.GetById(this.id).then(response => {
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
