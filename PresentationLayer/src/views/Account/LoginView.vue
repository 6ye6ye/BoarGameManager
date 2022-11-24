<template>
    <form class="col-sm">
        <div>
            <label class="form-label">Login</label>
            <input type="email" v-model="email" class="form-control" />

        </div>
        <div>
            <label class="form-label" >Password</label>
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

        <p class="text-danger"> {{errorMessage}}</p>
        <button v-on:click="trylogin()" type="button" class="btn">Sign in</button>
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
                errorMessage:'',
                email: '',
                password: '',
                rememberMe: false
            }
        },
        methods: {
            trylogin: function() {
                AccountService.login(this.email, this.password, this.rememberMe).then(response => {
                    console.log('setrole' + response.status)
                    switch (response.status) {
                        case (200):
                            {
                                AccountService.getCurrentUserRole().then(response => {
                                    localStorage.setItem('role', response.data[0]); 
                                });
                        
                                AccountService.getCurrentUserName().then(response => {
                                    localStorage.setItem('userName', response.data)
                                });

                                console.log('setrole')
                                localStorage.setItem('isAuth', 'true')
                             //  window.location.href = '/'; 
                              
                                this.$router.push('/')
                               
                               
                            return { ok: true }
                            }
                        case (400):
                            {
                                this.errorMessage = response;
                                return {ok: false}
                            }
                    }
                    console.log(response.data);
                })
                    .catch(e => {
                        this.errorMessage = e.response.data;
                        console.log(e);
                    });
            },

        }
    }

    

</script>

<style lang="scss" scoped>
</style>  