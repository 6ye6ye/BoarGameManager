<template>
    <div class="form-control border bg-light">
        <h2>Add friend</h2>
        <div class="row">
            <label class="control-label">User name:</label>
            <input type="text" v-model="userName" class="form-control" />
            <button v-on:click="getFirstTenUsers()" type="button" class="btn btn-primary">Search</button>
        </div>
        <div v-show="users.length!=0">
            <table class="table">
                <thead>
                    <tr>
                        <th>login</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in users" :key="item.id">
                        <td>{{item.userName }}</td>
                        <td><button v-on:click="goToAdd(item.id)" type="button" class="btn btn-info">+</button></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
    import UserService from "../../services/UsersService";
    import FriendsService from "../../services/FriendsService";
    import lodash from 'lodash';
    export default {
        name: 'AddFriend',
        data() {
            return {
                users: [],
                userName: ''
            }
        },
        methods: {
            getFirstTenUsers: lodash.throttle(function () {
                UserService.GetfirstTenUsers(this.userName)
                    .then(response => {
                        this.users = response.data;
                    })
                    .catch(e => {
                        console.log(e);
                    });
            }, 1000),

            goToAdd: function (id) {
                FriendsService.AddFriend(id)
                    .then(response => {
                        if (response.status == 200) {
                            let i = this.users.map(item => item.id).indexOf(id)
                            this.users.splice(i, 1)
                        }
                    })
                    .catch(e => {
                        console.log(e);
                    });

            },
            goToAccept: function (id) {
                FriendsService.AddFriend(id)
                    .then(response => {
                        if (response.status == 200) {
                            let i = this.users.map(item => item.id).indexOf(id)
                            this.users.splice(i, 1)
                        }
                    })
                    .catch(e => {
                        console.log(e);
                    });

            },
            goToDelete: function (id) {
                FriendsService.Delete(id)
                    .then(response => {
                        if (response.status == 200) {
                            let i = this.users.map(item => item.id).indexOf(id)
                            this.users.splice(i, 1)
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
