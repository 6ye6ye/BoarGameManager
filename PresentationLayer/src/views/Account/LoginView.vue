<template>
    <div class="flex items-center justify-center h-screen px-6 ">
        <div class="w-full max-w-sm p-6 bg-white rounded-md shadow-md">
            <div class="flex items-center justify-center">
                <img class="icon" :src="require('/src/assets/icon-main.png')" />
                <span class="text-2xl font-semibold text-gray-700">Board games</span>
            </div>
            <form ref="form" @submit.prevent="trylogin" method="post" class="mt-4">
                <label class="block">
                    <span class="text-sm text-gray-700">Login</span>

                    <input type="text"
                           class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                           v-model="userName" />
                </label>

                <label class="block mt-3">
                    <span class="text-sm text-gray-700">Password</span>
                    <input type="password"
                           class="block pl-4 w-full mt-1 border-gray-200 rounded-md border  focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                           v-model="password" />
                </label>

                <div class="flex items-center justify-between mt-4">
                    <div>
                        <label class="inline-flex items-center">
                            <input type="checkbox" class="text-indigo-600 border  border-gray-200 rounded-md focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500" />
                            <span class="mx-2 text-sm text-gray-600">Remember me</span>
                        </label>
                    </div>
                </div>
                <ErrorMessage  :message="errorMessage" />
  
                <div class="mt-6">
                    <button type="submit"   data-ripple-light="true"
                            class=" w-full px-4 py-2 text-sm text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
                        Sign in
                    </button>
                </div>
            </form>
        </div>
    </div>

</template>

<script>
    import AccountService from "../../services/AccountService";
    import ErrorMessage from "../../components/ErrorMessage.vue";
    export default {
        name: 'LoginView',
        data() {
            return {
                errorMessage: '',
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
        components: {
            ErrorMessage
        },
        methods: {
            async trylogin() {
                if (!this.isValid) return false
                AccountService.login(this.userName, this.password, this.rememberMe).then(response => {
                    switch (response.status) {
                        case (200):
                            {
                                AccountService.getCurrentUserRole().then(response => {
                                    localStorage.setItem('role', response.data[0]);
                                    AccountService.getCurrentUserName().then(response => {
                                        localStorage.setItem('userName', response.data)
                                        localStorage.setItem('isAuth', 'true')
                                    });
                                });



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




<!--<template>
    <form ref="form" class="row d-flex justify-content-center" @submit.prevent="trylogin" method="post">
        <h2> Authorization</h2>

        <div class="col-md-4">
            <div>
                <label class="form-label">Login</label>
                <input type="text" v-model="userName" class="form-control" required />
            </div>
            <div>
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


<style lang="scss" scoped>
</style>-->
  