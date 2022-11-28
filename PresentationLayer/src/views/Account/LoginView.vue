<template>
    <form ref="form" class="col-sm" method="post">
        <div>
            <label class="form-label">Login</label>
            <input type="text" v-model="userName" class="form-control" required />
        </div>
        <div>
            <label class="form-label" >Password</label>
            <input type="password"  v-model="password" class="form-control" required/>
        </div>
        <div class="row">
            <div class="col d-flex justify-content-center">
                <div class="form-check">
                    <input class="form-check-input" v-model='rememberMe' type="checkbox"/>
                    <label class="form-check-label"> Remember me </label>
                </div>
            </div>
        </div>

        <p class="text-danger"> {{errorMessage}}</p>
        <button v-on:click="trylogin" type="button" class="btn btn-primary" >Sign in</button>
        <div class="text-center">
            <p>Not a member?      
                <router-link  to="/register"> Sing up</router-link>
            </p>
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
                userName: '',
                password: '',
                rememberMe: false
            }
        },
        
        methods: {
           
            trylogin: function () {
              
                //console.log(this.$refs.form.validate())
                //if (this.$refs['form'].valid == true) {
               //     console.log('true')
                    AccountService.login(this.userName, this.password, this.rememberMe).then(response => {

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
                                    window.location.reload()
                                    window.location.href = '/';
                                    return { ok: true }
                                }
                            case (400):
                                {
                                    this.errorMessage = response;
                                    return { ok: false }
                                }
                        }
                        console.log(response.data);
                    })
                        .catch(e => {
                            this.errorMessage = e.response.data;

                        });
               // }
               // else 
               //     console.log('false')
            },

        }
    }

    

</script>

<style lang="scss" scoped>
</style>  