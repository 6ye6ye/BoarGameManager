<template>
    <form>
        <div>
            <label class="form-label">Login</label>
            <input type="text" v-model="login" class="form-control" />
        </div>
        <div>
            <label class="form-label">Email address</label>
            <input type="email" v-model="email" class="form-control" />
        </div>
        <div>
            <label class="form-label">Name</label>
            <input type="text" v-model="name" class="form-control" />
        </div>
        <div>
            <label class="form-label" for="form2Example2">Password</label>
            <input type="password" v-model="password" class="form-control" />
        </div>
        <div>
            <label class="form-label" for="form2Example2">Password repeat</label>
            <input type="password" v-model="passwordRepeat" class="form-control" />
        </div>
        <div class="row">
        </div>
        <button v-on:click="tryregister()" type="button" class="btn">Register</button>

    </form>
</template>


<script>
    import AccountService from "../../services/AccountService";

    export default {
        name: 'RegisterView',
        data() {
            return {
                login:'',
                email: '',
                password: '',
                passwordRepeat: '',
                name:''

            }
        },
        methods: {
            tryregister: function() {
                AccountService.register(this.login, this.email, this.password, this.passwordRepeat, this.name).then(response => {

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