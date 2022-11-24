<template>
    <div class="form-control border bg-light">
        <h2>Add friend</h2>
        <div class="row">
            <label class="control-label">User name:</label>
            <input type="text" v-model="userName" class="form-control"/>
            <button v-on:click="GetfirstTenUsers()" type="button" class="btn btn-primary">Search</button>-->
        </div>

        <table  class="table">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>

                <tr v-for="item in users" :key="item.id">
                    <td>{{item.id}}</td>
                    <td>{{item.userName }}</td>
                    <td><button v-on:click="goToAdd(item.id)" type="button" class="btn btn-info">+</button></td>
                </tr>
            </tbody>
        </table>
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
                users:[],
                userName: ''
            }
        },
        methods: {
            //debounceMethod: lodash.debounce(() => {
            //    this.getFirstTenUsers();
            //}, 2000),
            getFirstTenUsers: lodash.throttle(function () {
                UserService.GetfirstTenUsers(this.userName)
                    .then(response => {
                        this.users = response.data;
                    })
                    .catch(e => {
                        console.log(e);
                    });
            }, 200),

            //getFirstTenUsers: function () {
            //    UserService.getFirstTenUsers(this.name)
            //        .then(response => {
            //            this.users = response.data;
            //        })
            //        .catch(e => {
            //            console.log(e);
            //        });

            //},
            goToAdd: function (id) {
                FriendsService.AddFriend(id)
                    .then(response => {
                        console.log(response.data);
                        let i = this.users.map(item => item.id).indexOf(id) // find index of your object
                        this.users.splice(i, 1)
                    
                        //this.$emit('close');
                        //this.$emit('get-user-game-places');
                    })
                    .catch(e => {
                        console.log(e);
                    });

            },
            goToAccept: function (id) {
                FriendsService.AddFriend(id)
                    .then(response => {
                        console.log(response.data);
                        let i = this.users.map(item => item.id).indexOf(id) // find index of your object
                        this.users.splice(i, 1)

                        //this.$emit('close');
                        //this.$emit('get-user-game-places');
                    })
                    .catch(e => {
                        console.log(e);
                    });

            },
            goToDelete: function (id) {
                FriendsService.Delete(id)
                    .then(response => {
                        console.log(response.data);
                        let i = this.users.map(item => item.id).indexOf(id) // find index of your object
                        this.users.splice(i, 1)

                        //this.$emit('close');
                        //this.$emit('get-user-game-places');
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
