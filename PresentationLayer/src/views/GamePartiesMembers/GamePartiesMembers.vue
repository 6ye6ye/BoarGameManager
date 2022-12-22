<template>
    <ModalWindow v-if="isModalVisible" @close="closeModal">
        <template v-slot:body>
            <AddGamePartyMemberView @close="closeModal" @get-game-party-members="getGamePartyMembers" :gameId="gameId" :gamePartyId="gamePartyId"></AddGamePartyMemberView>
        </template>
    </ModalWindow>

    <div class="mb-6">
        <div class="relative flex justify-end z-0 ">
            <button v-on:click="showModal"
                    type="button"
                    class="bg-green-500 shadow-md text-white px-4 py-2  hover:bg-green-400 focus:outline-none">
                add
            </button>
        </div>

        <div class="relative bg-white shadow-md rounded z-40" v-if="gamePartyMembers.length>0">
            <table class="min-w-max w-full table-auto">
                <thead>
                    <tr class="bg-blue-400 text-white uppercase  leading-normal">

                        <th class="py-3 px-6 text-left">Player</th>
                        <th class="py-3 px-6 text-left">Game role</th>
                        <th class="py-3 px-6 text-left">Points</th>
                        <th class="py-3 px-6 text-left">IsWinner</th>
                        <th class="py-3 px-6 text-left"></th>
                    </tr>
                </thead>
                <tbody class="text-gray-600 ">
                    <tr v-for="item in gamePartyMembers"
                        :key="item.Id"
                        class="border-b border-gray-200 hover:bg-gray-100">
                        <td class="py-3 px-6 text-left whitespace-nowrap">{{item.player.name }}</td>
                        <td class="py-3 px-6 text-left whitespace-nowrap" v-if="item.gameRole!=null">{{item.gameRole.name }}</td>
                        <td class="py-3 px-6 text-left whitespace-nowrap" v-else> default </td>
                        <td class="py-3 px-6 text-left whitespace-nowrap">{{item.points }}</td>
                        <td class="py-3 px-6 text-left whitespace-nowrap">{{item.isWinner }}</td>
                        <td class="py-3 px-6 text-left whitespace-nowrap" v-if="isCreator">
                            <div v-on:click="goToDelete(item.id)"
                                 class="w-6 mr-2 transform hover:text-purple-500 hover:scale-110">
                                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                                </svg>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>



<script>
    import AddGamePartyMemberView from "../GamePartiesMembers/AddGamePartyMember.vue";
    import GamePartyMemberService from "../../services/GamePartyMemberService";
    export default {
        name: 'GamePartyMembresView',
        props: ['gamePartyId', 'gameId', 'isCreator'],
        data() {
            return {
                addModal: 'AddGamePartyMemberView',
                isModalVisible: false,
                gamePartyMembers: [{
                    id: '',
                    gameRole: {
                        id: '',
                        name:'',
                    },
                    points: '',
                    isWinner:'false',

                    player: {
                        id: '',
                        name:'',
                    },
                }],
            };
        },
        components: {
            AddGamePartyMemberView
        },
        created() {
            this.getGamePartyMembers();
        },
        methods: {
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
            getGamePartyMembers() {
                GamePartyMemberService.GetAll(this.gamePartyId).then(response => {
                    this.gamePartyMembers = response.data;

                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToDelete(id) {
                GamePartyMemberService.Delete(id).then(response => {
                    if (response.status == 200) {
                        let i = this.gamePartyMembers.map(item => item.id).indexOf(id)
                        this.gamePartyMembers.splice(i, 1)
                    }
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
        },
    }
</script>

<style lang="scss" scoped>
</style>
