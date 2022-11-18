<template>
    <h2>{{header}}</h2>
    <div >
        <button type="button" class="btn btn-primary" @click="showModal">Add friends</button>
        <ModalWindow v-show="isModalVisible" @close="closeModal">
            <template v-slot:body>
                <AddFriendView @close="closeModal" @get-players="getFriends"></AddFriendView>
            </template>
        </ModalWindow>
    </div>
    <button v-on:click="getFriends" type="button" class="btn btn-danger">Friends</button>
    <button v-on:click="getIncomingRequests" type="button" class="btn btn-danger">Requests</button>
    <button v-on:click="getOutRequests" type="button" class="btn btn-danger">Requests</button>
    <div class="post">
        <div class="row" style="margin-bottom: 10px;">
        </div>
        <div>
            <table class="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <!--  <th>FriendId</th>-->
                        <th>Name</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>

                    <tr v-for="item in friends" :key="item.Id">
                        <td>{{item.id}}</td>
                        <!-- <td>{{item.friend.id }}</td>-->
                        <td>{{item.friend.userName }}</td>
                        <td><button v-on:click="goToDelete(item.id)" type="button" class="btn btn-danger">Delete</button></td>

                        <td><button v-show="showButtonAccept" v-on:click="goToAccept(item.id)" type="button" class="btn btn-danger">Accept</button></td>

                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>  
  
<script>  
    import ModalWindow from "../ModalWindow.vue";
    import AddFriendView from "../Friends/AddFriend.vue"
    import FriendsService from "../../services/FriendsService";
    export default {
        name: 'FriendsView',
        data() {
            return {
                header: 'Friends',
              
                isModalVisible: false,
                showButtonAddFriend: true,
                showButtonAccept: false,
                friends: [],
            };
        },
        components: {
            ModalWindow,
            AddFriendView
        },

        created() {
            this.getFriends();
        },

        methods: {
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
            getFriends() {
                FriendsService.getAllFriends().then(response => {
                    this.friends = response.data;
                    this.header = 'Friends';
                    this.showButtonAccept = false;
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getIncomingRequests() {
                FriendsService.getAllIncomingRequests().then(response => {
                    this.friends = response.data;
                    this.showButtonAccept = true;
                    this.header = 'Incoming requests';
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getOutRequests() {
                FriendsService.getAllIncomingRequests().then(response => {
                    this.friends = response.data;
                    this.header = 'Outgoing requests';
                    this.showButtonAccept = false;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToDelete(id) {
                FriendsService.Delete(id).then(response => {
                    console.log(response.data);
                    let i = this.friends.map(item => item.id).indexOf(id) // find index of your object
                    this.friends.splice(i, 1)
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
