<template>
    <div class="flex w-full justify-items-stretch">
        <ModalWindow v-show="isModalVisible" @close="closeModal">
            <template v-slot:title>
                <h5>Change password</h5>
            </template>
            <template v-slot:body>
                <ChangePassword @close="closeModal"></ChangePassword>
            </template>
        </ModalWindow>

        <div class=" w-1/3 mr-20 bg-white rounded-lg shadow-md p-8">
            <h4 class="text-xl text-gray-900 font-bold">Personal Info</h4>
            <ul class="mt-2 text-gray-700">
                <li class="flex border-y py-2">
                    <span class="font-bold w-24">Name:</span>
                    <span>{{user.userName}}</span>
                </li>
                <li class="flex border-b py-2">
                    <span class="font-bold w-24">Email:</span>
                    <span>{{user.email}}</span>
                </li>
                <li class="flex border-b py-2">
                    <span class="font-bold w-24">Role:</span>
                    <span>{{user.role.name}}</span>
                </li>
            </ul>
            <button v-on:click="showModal"
                    type="button"
                    class=" w-full px-4 py-2 text-sm text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
                Change password
            </button>
        </div>
        <div class="w-2/3 bg-white rounded-lg shadow-md p-8">
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
    import ModalWindow from "../../components/ModalWindow.vue";
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
