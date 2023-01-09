<template>
    <div class="flex w-full items-start flex-wrap xl:!flex-nowrap ">
        <ModalWindow v-if="isModalEditVisible" @close="closeEditModal">
            <template v-slot:title>
                <h5>Edit game party</h5>
            </template>
            <template v-slot:body>
                <EditGamePartyView :gamePartyId="gameParty.id" @close="closeEditModal" @get-game-party="getGameParty"></EditGamePartyView>
            </template>
        </ModalWindow>

        <ContainerWhite class="xl:w-1/3 xl:mr-10 mr-0 w-full">
            <template v-slot:body>
                <h4 class="text-xl text-gray-900 font-bold">Game party info</h4>
                <ul class="mt-2 text-gray-700">
                    <li class="flex border-y py-2">
                        <span class="font-bold w-24">Date:</span>
                        <span>{{gameParty.date}}</span>
                    </li>
                    <li class="flex border-b py-2">
                        <span class="font-bold w-24">Game:</span>
                        <span v-if="gameParty.game!=null">{{gameParty.game.name}}</span>
                        <span v-else >deleted</span>
                    </li>
                    <li class="flex border-b py-2">
                        <span class="font-bold w-24">Place:</span>
                        <span>{{gameParty.userGamePlace.name}}</span>
                    </li>
                    <li class="flex border-b py-2">
                        <span class="font-bold w-24">Place:</span>
                        <span>{{gameParty.userGamePlace.name}}</span>
                    </li>
                    <li class="flex border-b py-2">
                        <span class="font-bold w-24">Party creator:</span>
                        <span>{{gameParty.partyCreatorName}}</span>
                    </li>
                </ul>
                <button v-on:click="showEditModal"
                        type="button"
                        class=" w-full px-4 py-2 text-sm text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
                    Edit
                </button>
            </template>
        </ContainerWhite>

        <ContainerWhite class=" xl:w-2/3 w-full">
            <template v-slot:body>
                <h4 class="text-xl text-center text-gray-700 font-bold">Party members</h4>
                <GamePartyMembers :gameId="gameParty.game.id" :gamePartyId="gameParty.id" :isCreator="isCreator" />
            </template>
        </ContainerWhite>
    </div>
</template>

<script>

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
                        name: '',
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
