<template>
    <form ref="form" @submit.prevent="sendRequest" method="post">

        <span class=" text-gray-700">User name:</span>
        <div class="flex rounded-md shadow-sm rounded-md mb-3" role="group">
            <label class="block w-full ">
                <input type="text"
                       class="block h-full  pl-4 w-full  border-gray-200 rounded-md border
                   focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                       v-model="userName" required />
            </label>
            <div type="button  "
                 class="ml-1 flex-none rounded  items-center bg-green-500"
                 @click="getFirstTenUsers()">
                <svg viewBox="0 0 24 24" class="h-7 w-7 text-white fill-current text-gray-500">
                    <path d="M10 4a6 6 0 100 12 6 6 0 000-12zm-8 6a8 8 0 1114.32 4.906l5.387 5.387a1 1 0 01-1.414 1.414l-5.387-5.387A8 8 0 012 10z">
                    </path>
                </svg>
            </div>
        </div>

        <div class="relative bg-white shadow-md rounded  z-40" v-show="users.length!=0">
            <table class="min-w-max w-full table-auto">
                <thead>
                    <tr class="bg-blue-400 text-white uppercase  leading-normal">
                        <th class="py-1 px-2 text-center">login</th>
                        <th class="py-1 px-2 text-center"></th>
                    </tr>
                </thead>
                <tbody class="text-gray-600 ">
                    <tr v-for="item in users" :key="item.id">
                        <td class="py-1 px-2 text-center whitespace-nowrap">{{item.userName }}</td>
                        <td class="py-1 px-2 text-center whitespace-nowrap">
                            <button type="submit" v-on:click="sendRequest(item.id)" class="btn btn-info">+</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <InfoMessage v-show="users.length==0" message="No users (without friends, incoming/outgoing requests)"></InfoMessage>
    

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
