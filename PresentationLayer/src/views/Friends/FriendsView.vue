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
    <div class="btn-group" role="group" aria-label="Basic example">
        <button v-on:click="getFriends" type="button" class="btn btn-outline-primary">Friends</button>
        <button v-on:click="getIncomingRequests" type="button" class="btn btn-outline-primary">Incoming</button>
        <button v-on:click="getOutRequests" type="button" class="btn btn-outline-primary">Outgoing</button>
        </div>
    <div class="post">
        <div class="row" style="margin-bottom: 10px;">
        </div>
        <div v-show="friends.length!=0">
            <table class="table">
                <thead>
                    <tr>
                        <th>login</th>
                        <th></th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>

                    <tr v-for="item in friends" :key="item.id">
                        <td>{{item.friend.userName }}</td>
                        <td><button v-show="showButtonIgnore" v-on:click="goToIgnore(item.id)" type="button" class="btn btn-danger">Ignore</button></td>
                        <td><button v-on:click="goToDelete(item.id)" type="button" class="btn btn-danger">{{btnDelText}}</button></td>

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
                btnDelText: 'Delete',
                isModalVisible: false,
                showButtonAddFriend: true,
                showButtonIgnore:false,
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

            goToIgnore(id) {
                FriendsService.Ignore(id).then(response => {
                    let i = this.friends.map(item => item.id).indexOf(id) // find index of your object
                    this.friends.splice(i, 1);
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToAccept(id) {
                FriendsService.AcceptRequest(id).then(response => {
                    let i = this.friends.map(item => item.id).indexOf(id) // find index of your object
                    this.friends.splice(i, 1);
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getFriends() {
                FriendsService.getAllFriends().then(response => {
                    this.friends = response.data;
                    this.header = 'Friends';
                    this.showButtonAccept = false;
                    this.showButtonIgnore = false;
                    this.btnDelText='Delete',
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
                    this.showButtonIgnore = true;
                    this.btnDelText = 'Reject',
                    this.header = 'Incoming requests';
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getOutRequests() {
                FriendsService.getAllOutrequests().then(response => {
                    this.friends = response.data;
                    this.header = 'Outgoing requests';
                    this.showButtonAccept = false;
                    this.showButtonIgnore = false;
                    this.btnDelText = 'Cancel';
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
