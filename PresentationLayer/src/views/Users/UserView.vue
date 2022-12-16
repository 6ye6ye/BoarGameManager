<template>

    <div class="d-flex container">
        <div class="container container-white user-info ">
            <ModalWindow v-show="isModalVisible" @close="closeModal">
                <template v-slot:body>
                    <ChangePassword @close="closeModal"></ChangePassword>
                </template>
            </ModalWindow>
            <div class="title">
                <h3>User info</h3>
            </div>
            <div class="row">
                <div>
                    Login
                    <p>{{user.userName}}</p>
                </div>
                <div>
                    Email
                    <p>{{user.email}}</p>
                </div>
                <div>
                    Role
                    <p>{{user.role.name}}</p>
                </div>

            </div>
            <button v-on:click="showModal" type="button" class="btn btn-primary"> Change password </button>
        </div>
        <div class="container container-white">
                <h3>Statistic</h3>
    
            <p class="title">Played games</p>
            <div class="row">
            </div>
            <p class="title">Friends</p>
            <p class="title">More played games</p>
        </div>
    </div>
</template>

<script>
    import UsersService from "../../services/UsersService";
    import ChangePassword from "../Account/ChangePassword.vue";
    import ModalWindow from "../ModalWindow.vue";
    export default {
        name: 'UserView',
        data() {
            return {
                user: {
                    id: '',
                    userName: '',
                    email: '',
                    role: {
                        id: '',
                        name: ''
                    }
                },
                userId: '',
                isModalVisible: false,
                isAuth: localStorage.getItem('isAuth'),
            }
        },
        components: {
            ChangePassword,
            ModalWindow
        },
        created() {
            this.getUser();
        },
        methods: {
            getUser() {
                if (this.$route.params.id != null) {
                    this.userId = this.$route.params.id.toString()
                    UsersService.GetById(this.userId).then(response => {
                        this.user = response.data;
                    })
                        .catch(e => {
                            console.log(e);
                        });
                }
                else
                    UsersService.GetCurrent().then(response => {
                        this.user = response.data;
                    })
                        .catch(e => {
                            console.log(e);
                        });
            },
            showModal() {
                this.isModalVisible = true;
            },
            closeModal() {
                this.isModalVisible = false;
            },
        }
    }
</script>

<style lang="scss" scoped>
</style>
