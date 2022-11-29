<template>
    <div class="container">
        <div class="row">
            <div>
                Id
                <p>{{user.id}} </p>
            </div>
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
    </div>
</template>

<script>
    import UsersService from "../../services/UsersService";
    export default {
        name: 'UserView',
        data() {
            return {
                user: {
                    id: '',
                    userName: '',
                    email: '',
                    role: {
                        id:'',
                        name:''
                    }
                },
                userId: '',
                isAuth: localStorage.getItem('isAuth'),
            }
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
        }
    }
</script>

<style lang="scss" scoped>
</style>
