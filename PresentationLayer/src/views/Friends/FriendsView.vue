<template>
    <div class="container ">

        <ModalWindow v-show="isModalVisible" @close="closeModal">
            <template v-slot:body>
                <AddFriendView  ></AddFriendView>
            </template>
        </ModalWindow>

        <div class="filter row" aria-label="Basic example">
            <div>
                <button v-on:click="getFriends" type="button" class=" btn ">Friends</button>
                <button v-on:click="getIncomingRequests" type="button" class="btn ">Incoming</button>
                <button v-on:click="getOutRequests" type="button" class="btn ">Outgoing</button>
            </div>
        </div>
        <div class="container-white ">
        <div>
            <h2 class="d-inline">{{header}}</h2>
            <img class="icon" v-show="showButtonAddFriend" type="button" @click="showModal" :src="require('/src/assets/icon-add.png')" />
        </div>
        <div class="post">
            <div class="row" style="margin-bottom: 10px;">
            </div>
            <div v-show="friends.length!=0">
                <table class="table">
                    <thead>
                        <tr class="filter">
                            <th>Login</th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="item in friends" :key="item.id">
                            <td>{{item.friend.userName }}</td>
                            <td>
                                <img class="icon" v-show="showButtonsConfirm" v-on:click="goToAccept(item.id)" type="button" :src="require('/src/assets/icon-accept.png')" />
                            </td>
                            <td>
                                <img class="icon" v-show="showButtonsConfirm" v-on:click="goToIgnore(item.id)" type="button" :src="require('/src/assets/icon-ignore.png')" />
                            </td>
                            <td>
                                <img class="icon" v-on:click="goToDelete(item.id)" type="button" :src="require('/src/assets/icon-remove.png')" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div v-show="friends.length==0">
                <p>No users</p>
            </div>
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
                if (this.needToUpdate == true) { 
                    this.getFriends();
                }
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
