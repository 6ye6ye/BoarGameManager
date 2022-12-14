<template>
    <form ref="form" class="row d-flex justify-content-center" @submit.prevent="trylogin" method="post">
        <h2> Authorization</h2>
        <div class="col-md-4">
            <div>
                <label class="form-label">Login</label>
                <input type="text" v-model="userName" class="form-control" required />
            </div>
            <div >
                <label class="form-label">Password</label>
                <input type="password" v-model="password" class="form-control" required />
            </div>
            <div class="row">
                <div class="col d-flex justify-content-center">
                    <div class="form-check">
                        <input class="form-check-input" v-model='rememberMe' type="checkbox" />
                        <label class="form-check-label"> Remember me </label>
                    </div>
                </div>
            </div>
            <p class="text-danger"> {{errorMessage}}</p>
            <button type="submit" class="btn btn-primary">Sign in</button>
            <div class="text-center">
                <p>
                    Not a member?
                    <router-link to="/register"> Sign up</router-link>
                </p>
            </div>
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
        computed: {
            isValid() {
                return this.userName && this.password
                }
            },
        methods: {
            async trylogin () {
                if (!this.isValid) return false
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
                    })
                        .catch(e => {
                            this.errorMessage = e.response.data;
                        });
            },
        }
    }
</script>

<style lang="scss" scoped>
</style>  