<template>
    <div class="container container-white ">

        <ModalWindow v-show="isModalVisible" @close="closeModal">
            <template v-slot:body>
                <AddFriendView @close="closeModal" @get-players="getFriends"></AddFriendView>
            </template>
        </ModalWindow>

        <div class="filter row" aria-label="Basic example">
            <div>
                <button v-on:click="getFriends" type="button" class=" btn ">Friends</button>
                <button v-on:click="getIncomingRequests" type="button" class="btn ">Incoming</button>
                <button v-on:click="getOutRequests" type="button" class="btn ">Outgoing</button>
            </div>
        </div>
        <div>
            <h2 class="d-inline">{{header}}</h2>
            <button v-show="showButtonAddFriend" type="button" class="d-inline btn btn-primary" @click="showModal">+</button>
        </div>
        <div class="post">
            <div class="row" style="margin-bottom: 10px;">
            </div>
            <div v-show="friends.length!=0">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Login</th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="item in friends" :key="item.id">
                            <td>{{item.friend.userName }}</td>
                            <td><button v-show="showButtonsConfirm" v-on:click="goToIgnore(item.id)" type="button" class="btn btn-secondary">Ignore</button></td>
                            <td><button v-on:click="goToDelete(item.id)" type="button" class="btn btn-danger">{{btnDelText}}</button></td>
                            <td><button v-show="showButtonsConfirm" v-on:click="goToAccept(item.id)" type="button" class="btn btn-success">Accept</button></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div v-show="friends.length==0">
                <p>No users</p>
            </div>
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
                showButtonsConfirm: false,
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
                    if (response.status == 200) {
                        let i = this.friends.map(item => item.id).indexOf(id) 
                        this.friends.splice(i, 1);
                      
                    }
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToAccept(id) {
                FriendsService.AcceptRequest(id).then(response => {
                    if (response.status == 200) {
                        let i = this.friends.map(item => item.id).indexOf(id) 
                        this.friends.splice(i, 1);
                     
                    }
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getFriends() {
                FriendsService.getAllFriends().then(response => {
                    this.friends = response.data;
                    this.header = 'Friends';
                    this.showButtonsConfirm = false;
                    this.showButtonAddFriend = true;
                    this.btnDelText = 'Delete';
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getIncomingRequests() {
                FriendsService.getAllIncomingRequests().then(response => {
                    this.friends = response.data;
                    this.showButtonAddFriend = false;
                    this.showButtonsConfirm = true;
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
                    this.showButtonAddFriend = false;
                    this.showButtonsConfirm = false;
              
                    this.btnDelText = 'Cancel';
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToDelete(id) {
                FriendsService.Delete(id).then(response => {
                    if (response.status == 200) {
                        let i = this.friends.map(item => item.id).indexOf(id)
                        this.friends.splice(i, 1)
                    }
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
