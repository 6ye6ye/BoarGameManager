<template>
    <div class="w-full">
        <div class="bg-white  shadow-md rounded mb-6">
            <!--Filter-->
            <div class=" flex md:flex-row md:flex-nowrap flex-col  items-stretch text-sm">
                <div class="flex flex-row border pl-2 ">
                    <select v-model="filter.roleId"
                            class=" block  pr-6 py-2 w-full bg-white
                                placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-600 focus:text-gray-700 focus:outline-none">
                        <option value=''>- All roles -</option>
                        <option v-for="role in roles" v-bind:key="role.id" v-bind:value="role.id"> {{role.name}}</option>
                    </select>
                </div>
                <div class="block relative border">
                    <span class="h-full absolute inset-y-0 left-0 flex items-center pl-2">
                        Login:
                    </span>
                    <input type="text"
                           v-model="filter.name"
                           placeholder="Input login"
                           class="appearance-none
                               block pl-16 pr-6 py-2 w-full bg-white
                               placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-200
                               focus:text-gray-700 focus:outline-none" />
                </div>
                <div class="block relative border ">
                    <span class="h-full absolute inset-y-0 left-0 flex items-center pl-2">
                        Email:
                    </span>
                    <input type="text"
                           v-model="filter.email"
                           placeholder="Input email"
                           class="appearance-none  block pl-16 pr-6 py-2 w-full bg-white placeholder-gray-400 text-gray-700 focus:bg-white focus:placeholder-gray-600 focus:text-gray-700 focus:outline-none" />
                </div>
                <span v-on:click="getUsersWithFilters()" class="border inset-y-0 left-0 flex items-center px-2">
                    <svg viewBox="0 0 24 24" class="h-7 w-7 fill-current text-gray-500">
                        <path d="M10 4a6 6 0 100 12 6 6 0 000-12zm-8 6a8 8 0 1114.32 4.906l5.387 5.387a1 1 0 01-1.414 1.414l-5.387-5.387A8 8 0 012 10z">
                        </path>
                    </svg>
                </span>
            </div>
        </div>
        <div class="bg-white shadow-md rounded my-6">
            <table class="min-w-max w-full table-auto">
                <thead>
                    <tr class="bg-blue-400 text-white uppercase  leading-normal">
                        <th @click="sort('userName')"
                            style="cursor: pointer;"
                            class="py-3 px-6 text-left">Login⇅</th>
                        <th @click="sort('email')"
                            style="cursor: pointer;"
                            class="py-3 px-6 text-left">Email⇅</th>
                        <th class="py-3 px-6 text-left">Role</th>
                        <th class="py-3 px-6 text-center">Actions</th>
                    </tr>
                </thead>
                <tbody class="text-gray-600 ">
                    <tr v-for="user in users"
                        :key="user.id"
                        class="border-b border-gray-200 hover:bg-gray-100">
                        <td class="py-3 px-6 text-left whitespace-nowrap">{{user.userName}}</td>
                        <td class="py-3 px-6 text-left">{{user.email}}</td>
                        <td class="py-3 px-6 text-left">{{user.role.name}}</td>
                        <td class="py-3 px-6 text-center">
                            <div class="flex item-center justify-center">
                                <div v-on:click="goToDetails(user.id)"
                                     class="w-6 mr-2 transform hover:text-purple-500 hover:scale-110">
                                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                                    </svg>
                                </div>

                                <div v-on:click="goToDelete(user.id)"
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
    </div>

</template>



<script>
    import UsersService from "../../services/UsersService";
    import RolesService from "../../services/RolesService";

    export default {
        name: 'UsersView',
        data() {
            return {
                filter: {
                    name: '',
                    roleId: '',
                    email: ''
                },
                isAdmin: localStorage.role == 'Admin',
                users: [],
                roles: [],
                currentSort: 'userName',
                currentSortDir: 'asc',
            };
        },
        created() {
            this.getUsers();
            this.getUserRoles();
            this.isAuth = localStorage.isAuth;
            this.isAdmin = localStorage.getItem('role') === "Admin"
        },
        methods: {
            sort: function (s) {
                if (s === this.currentSort) {
                    this.currentSortDir = this.currentSortDir === 'asc' ? 'desc' : 'asc';
                }
                this.currentSort = s;
                this.users = this.users.sort((a, b) => {
                    let modifier = 1;
                    if (this.currentSortDir === 'desc') modifier = -1;
                    if (a[this.currentSort] < b[this.currentSort]) return -1 * modifier;
                    if (a[this.currentSort] > b[this.currentSort]) return 1 * modifier;
                    return 0;
                });
            },
            getUsers() {
                UsersService.GetAll().then(response => {
                    this.users = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getUserRoles() {
                RolesService.getAll().then(response => {
                    this.roles = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToDetails(id) {
                this.$router.push({ name: 'UserView', params: { id: id } })
            },
            goToDelete(id) {

                UsersService.Delete(id).then(response => {

                    if (response.status == 200) {
                        let i = this.users.map(item => item.id).indexOf(id)
                        this.users.splice(i, 1)
                    }
                    else
                        console.log(response.request);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            getUsersWithFilters() {
                UsersService.GetAllWithFilters(this.filter).then(response => {
                    this.users = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            }
        },
    }
</script>

<style>
</style>
