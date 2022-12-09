<template>
    <form ref="form" class="col-sm" @submit.prevent="sendRequest" method="post">
        <h2>Add friend</h2>
        <div class="col-sm">
            <label class="control-label">User name:</label>
            <input type="text" v-model="userName" class="form-control" required />
            <button v-on:click="getFirstTenUsers()" type="button" class="btn btn-primary  mt-2">Search</button>

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
                            <td><button type="submit" v-on:click="sendRequest(item.id)" class="btn btn-info">+</button></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div v-show="users.length==0">
              <p> No users (without friends, incoming/outgoing requests)</p>
            </div>
        </div>
    </form>
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
        computed: {
            isValid() {
                return this.userName
            }
        },
        methods: {
            getFirstTenUsers: lodash.throttle(function () {
                if (!this.isValid) return false
                UserService.GetfirstTenUsers(this.userName)
                    .then(response => {
                        this.users = response.data;
                    })
                    .catch(e => {
                        console.log(e);
                    });
            }, 1000),
            sendRequest: function (id) {
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

        }
    }

</script>

<style lang="scss" scoped>
</style>
