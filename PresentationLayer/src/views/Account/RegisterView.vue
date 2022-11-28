<template>
    <h2> Registration</h2>
    <form class="col-sm" >
        <div>
            <label class="form-label">Login</label>
            <input type="text" v-model="login" minlength="3" maxlength="50" class="form-control" required />
        </div>
        <div>
            <label class="form-label">Email address</label>
            <input type="email" v-model="email" class="form-control" minlength="3" maxlength="100" required />
        </div>
        <div>
            <label class="form-label">Name</label>
            <input type="text" v-model="name" class="form-control" minlength="3" maxlength="100" required />
        </div>
        <div>
            <label class="form-label" for="form2Example2">Password</label>
            <input type="password" v-model="password" class="form-control" minlength="6" maxlength="100" required />
        </div>
        <div>
            <label class="form-label" for="form2Example2">Password repeat</label>
            <input type="password" v-model="passwordRepeat" class="form-control" minlength="6" maxlength="100" required />
        </div>

        <p class="text-danger">{{errorMessage}}</p>
        <!--  <button type="submit" class="btn btn-primary">Register</button>-->
        <button type="button" value="Register" @click="tryRegister" class="btn btn-primary"/>
    </form>
</template>


<script>
    import AccountService from "../../services/AccountService";

    export default {
        name: 'RegisterView',

        data() {
            return {
                errorMessage: '',
                login: '',
                email: '',
                password: '',
                passwordRepeat: '',
                name: ''

            }
        },
        methods: {
            tryRegister: function () {
                AccountService.register(this.login, this.email, this.password, this.passwordRepeat, this.name).then(response => {
                    AccountService.getCurrentUserRole().then(response => {
                        localStorage.setItem('role', response.data[0]);
                    });

                    AccountService.getCurrentUserName().then(response => {
                        localStorage.setItem('userName', response.data)
                    });
                    console.log('setrole')
                    localStorage.setItem('isAuth', 'true')
                    window.location.reload()
                    window.location.href = '/'; 
                    console.log(response);
                })
                    .catch(e => {
                        if (e.response) {
                            this.errorMessage = e.response.data;
                            console.log(e.response.data);
                        }

                    });
            },

        }
    }



</script>

<style lang="scss" scoped>
</style>  