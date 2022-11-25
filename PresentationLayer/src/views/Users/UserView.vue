<template>
    <div class="container">
        <div class="row">
            <div>
                <h2>{{}}</h2>
            </div>

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

            <div>
                <GameRoles />
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
                user: undefined,
                userId: '',
                isAuth: localStorage.getItem('isAuth'),
            }
        },
        created() {
            this.getGame();
        },
        methods: {
            getGame() {
                if (this.$route.params.id != null) {
                    this.userId = this.$route.params.id.toString()
                    UsersService.GetById(this.$route.params.id.toString()).then(response => {
                        this.user = response.data;
                    })
                        .catch(e => {
                            console.log(e);
                        });
                }
                else
                    UsersService.GetCurrent().then(response => {
                        this.user = response.data;
                        console.log(response.data);
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
