<template>
    <div class="container ">
        <ModalWindow v-show="isModalVisible" @close="closeModal">
            <template v-slot:title>
                <h5>New friend</h5>
            </template>
            <template v-slot:body>
                <AddFriendView></AddFriendView>
            </template>
        </ModalWindow>
        <!--<div>
            <h2 class="d-inline">{{header}}</h2>

        </div>-->
        <div class="filter flex " aria-label="Basic example">
            <div class="flex flex-row w-full bg-green-500 shadow-md text-white">
                <button v-on:click="getFriends"
                        type="button"
                        class="px-4 py-2 basis-1/3   hover:bg-green-400 focus:outline-none">
                    Friends
                </button>
                <button v-on:click="getIncomingRequests"
                        type="button"
                        class="px-4 py-2 basis-1/3  hover:bg-green-400 focus:outline-none">
                    Incoming
                </button>
                <button v-on:click="getOutRequests"
                        type="button"
                        class="px-4 py-2 basis-1/3 hover:bg-green-400 focus:outline-none">
                    Outgoing
                </button>
            </div>
        </div>


        <div class="post my-6">
            <div class=" flex justify-end ">
                <button v-on:click="showModal"
                        type="button"
                        class="bg-green-500 shadow-md text-white px-4 py-2  hover:bg-green-400 focus:outline-none">
                    add
                </button>
            </div>


            <div v-show="friends.length!=0"
                 class="bg-white shadow-md rounded " v-if="friends.length>0">

                <table class="min-w-max w-full table-auto">
                    <thead>
                        <tr class="bg-blue-400 text-white uppercase  leading-normal">
                            <th class="py-3 px-6 text-left">Login</th>
                            <th class="py-3 px-6 text-left"></th>
                        </tr>
                    </thead>
                    <tbody class="text-gray-600 ">
                        <tr v-for="item in friends" :key="item.id">
                            <td class="py-3 px-6 text-left whitespace-nowrap">{{item.friend.userName }}</td>
                            <td class="py-3 px-6 text-center">
                                <div class="flex item-center justify-center">
                                    <img class="icon" v-show="showButtonsConfirm" v-on:click="goToAccept(item.id)" type="button" :src="require('/src/assets/icon-accept.png')" />
                                    <img class="icon" v-show="showButtonsConfirm" v-on:click="goToIgnore(item.id)" type="button" :src="require('/src/assets/icon-ignore.png')" />
                                    <div v-on:click="goToDelete(item.id)"
                                         class="w-6 mr-2 transform hover:text-purple-500 hover:scale-110">
                                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                                        </svg>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <h2 v-show="friends.length==0"  >
                No users!
            </h2>
        </div>
    </div>
</template>

<script>

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
