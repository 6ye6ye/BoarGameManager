<template>
    <form>
        <div>
            <label class="form-label">Email address</label>
            <input type="email" v-model="email" class="form-control" />

        </div>
        <div>
            <label class="form-label" for="form2Example2">Password</label>
            <input type="password"  v-model="password" class="form-control" />

        </div>


        <div class="row">
            <div class="col d-flex justify-content-center">

                <div class="form-check">
                    <input class="form-check-input" v-model='rememberMe' type="checkbox"/>
                    <label class="form-check-label"> Remember me </label>
                </div>
            </div>

            <div class="col">
                <a href="#!">Forgot password?</a>
            </div>
        </div>
        <button v-on:click="trylogin()" type="button" class="btn">Войти</button>
        <div class="text-center">
            <p>Not a member? <a href="#!">Register</a></p>
        </div>
    </form>
</template>


<script>
    import AccountService from "../../services/AccountService";

    export default {
        name: 'LoginView',
        data() {
            return {
                email: '',
                password: '',
                rememberMe: false
            }
        },
        methods: {
            trylogin: function() {
                AccountService.login(this.email,this.password,true).then(response => {
 
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