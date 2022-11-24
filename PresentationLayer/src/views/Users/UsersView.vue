<template>
    <h1>Users list</h1>
    <div>
        <div class="row row_filters">
            <div class="col-sm-2 sub_filters">
                <label class="form-label">Name</label>
                <input type="text" v-model="filter.name" class="form-control" />
            </div>
            <div class="col-sm-2 sub_filters">
                <label class="form-label">Role</label>
                <select v-model="filter.roleId" class="form-select">

                    <option value=''>- All roles -</option>
                    <option v-for="role in roles" v-bind:key="role.id" v-bind:value="role.id"> {{role.name}}</option>
                </select>
            </div>
            <div class="col-sm-2 sub_filters">
                <label class="form-label">Email</label>
                <input type="text" v-model="filter.email" class="form-control" />
            </div>

            <div class="col-sm-2  sub_filters">
                <button v-on:click="getUsersWithFilters()" type="button" class="form-control btn btn-info">Search</button>
            </div>
        </div>
        <table id="usersTable" class="table">
            <thead>
                <tr>
                    <th>Id</th>
                    <th @click="sort('userName')">User name</th>
                    <th @click="sort('email')">Email</th>
                    <th @click="sort('role')">Role</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>

                <tr v-for="item in users" :key="item.Id">
                    <td>{{item.id}}</td>
                    <td>{{item.userName }}</td>
                    <td>{{item.email}}</td>
                    <td>{{item.role.name }}</td>
                    <td><button v-on:click="goToDetails(item.id)" type="button" class="btn btn-info">Details</button></td>

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
                    roleId: '',
                    email: ''
                },
                isAdmin: localStorage.role == 'Admin',
                users: [],
                roles: [],
                currentSort: 'name',
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
            getUsersWithFilters() {
                UsersService.GetAllWithFilters(this.filter).then(response => {
                    this.users = response.data;
                    //this.sortedGames = response.data;

                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            }

        },
    }
</script>

<style>
    .row_filters {
        align-content: center;
        align-items: center;
        padding-bottom: 10px;
    }

    .sub_filters {
        align-content: center;
        align-items: center;
        padding-left: 5px;
        padding-right: 5px;
        margin: 0;
    }
</style>
