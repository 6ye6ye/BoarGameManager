<template>
    <div class="post">
        <div class="form-group ">
            <h2>Game party members list</h2>
            <button type="button" class="btn btn-primary" @click="showModal">+</button>
        </div>
        <ModalWindow v-if="isModalVisible" @close="closeModal">
            <template v-slot:body>
                <AddGamePartyMemberView @close="closeModal" @get-game-party-members="getGamePartyMembers" :gameId="gameId" :gamePartyId="gamePartyId"></AddGamePartyMemberView>
            </template>
        </ModalWindow>

        <table id="gamePartyMembersTable" class="table">
            <thead>
                <tr>
                    <th>Player</th>
                    <th>Game role</th>
                    <th>Points</th>
                    <th>IsWinner</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in gamePartyMembers" :key="item.Id">
                    <td>{{item.player.name }}</td>
                    <td>{{item.gameRole.name }}</td>
                    <td>{{item.points }}</td>
                    <td>{{item.isWinner }}</td>
                    <td><button v-on:click="goToDelete(item.id)" type="button" class="btn btn-danger">Delete</button></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>



<script>
    import ModalWindow from "../ModalWindow.vue";
    import AddGamePartyMemberView from "../GamePartiesMembers/AddGamePartyMember.vue";
    import GamePartyMemberService from "../../services/GamePartyMemberService";
    export default {
        name: 'GamePartyMembresView',
        props: ['gamePartyId', 'gameId'],
        data() {
            return {
                addModal: 'AddGamePartyMemberView',
                isModalVisible: false,
                gamePartyMembers: [],
            };
        },
        components: {
            AddGamePartyMemberView,
            ModalWindow
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
