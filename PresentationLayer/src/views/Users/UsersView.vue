<template>
    <div class="container container-white">
        <table class="table ">
            <thead>
                <tr class="filter">
                    <th>
                        <label class="form-label">login</label>
                        <input type="text" v-model="filter.name" placeholder="Input login" class="form-control" />
                    </th>
                    <th>
                        <label class="form-label">Email</label>
                        <input type="text" v-model="filter.email" placeholder="Input email" class="form-control" />
                    </th>
                    <th>
                        <label class="form-label">Role</label>
                        <select v-model="filter.roleId" class="form-select">
                            <option value=''>- All roles -</option>
                            <option v-for="role in roles" v-bind:key="role.id" v-bind:value="role.id"> {{role.name}}</option>
                        </select>
                    </th>
                    <th>
                        <img class="icon" type="button"  v-on:click="getUsersWithFilters()" :src="require('/src/assets/icon-search.png')" />
                       <!-- <button  v-on:click="getUsersWithFilters()" type="button" class="form-control btn btn-info">Search</button>-->
                    </th>
                    <th>
                    </th>
                </tr>
            </thead>
            <thead>
                <tr class="filter">
                    <th @click="sort('userName')" style="cursor: pointer;">Login⇅</th>
                    <th @click="sort('email')" style="cursor: pointer;">Email⇅</th>
                    <th>Role</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>

            <tbody>
                <tr v-for="user in users" :key="user.id">
                    <td>{{user.userName}}</td>
                    <td>{{user.email}}</td>
                    <td>{{user.role.name}}</td>
                    <td>
                        <div>
                            <img class="icon" v-on:click="goToDetails(user.id)" type="button" :src="require('/src/assets/icon-details.png')" />
                            <img class="icon" v-on:click="goToDelete(user.id)" type="button" :src="require('/src/assets/icon-remove.png')" />
                            <!--<button v-on:click="goToDetails(user.id)" type="button" class="btn btn-info">Details</button>
                            <button v-on:click="goToDelete(user.id)" type="button" class="btn btn-danger">Delete</button>-->
                        </div>
                    </td>

                </tr>
            </tbody>
        </table>
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
                    roleId:'',
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
