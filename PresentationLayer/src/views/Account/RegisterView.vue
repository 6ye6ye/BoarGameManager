<template>

        <div class="w-full max-w-md p-6 bg-white rounded-md shadow-md">
            <div class="flex items-center justify-center">
                <img class="icon" :src="require('/src/assets/icon-main.png')" />
                <span class="text-2xl font-semibold text-gray-700">Board games</span>
            </div>
            <form ref="form" @submit.prevent="tryRegister()" method="post" class="mt-4">
                <label class="block">
                    <span class="text-sm text-gray-700">Login</span>

                    <input type="text"
                           class="block w-full pl-4  mt-1 border  border-gray-200 rounded-md focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                           v-model="login" minlength="3" maxlength="50" required />
                </label>
                <label class="block">
                    <span class="text-sm text-gray-700">Email</span>
                    <input type="email"
                           class="block w-full pl-4  mt-1 border border-gray-200 rounded-md focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                           v-model="email" minlength="3" maxlength="100" required />
                </label>
                <label class="block mt-3">
                    <span class="text-sm text-gray-700">Password</span>
                    <input type="password"
                           class="block w-full pl-4 mt-1 border  border-gray-200 rounded-md focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                           v-model="password" minlength="6" maxlength="100" required />
                </label>
                <label class="block mt-3">
                    <span class="text-sm text-gray-700">Password confirm</span>
                    <input type="password"
                           class="block w-full pl-4 mt-1 border border-gray-200 rounded-md focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                           v-model="passwordRepeat" minlength="6" maxlength="100" required />
                </label>
                <ErrorMessage :message="errorMessage" />
                <div class="mt-6">
                    <button type="submit"
                            class=" w-full px-4 py-2 text-sm text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
                        Register
                    </button>
                </div>
            </form>
        </div>
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
            }
        },
        computed: {
            isValid() {
                return this.login && this.email && this.password && this.passwordRepeat 
            }
        },
        methods: {
            async tryRegister() {
                if (!this.isValid) return false
                AccountService.register(this.login, this.email, this.password, this.passwordRepeat).then(response => {
                    if (response.status == 200) {
                        AccountService.getCurrentUserRole().then(response => {
                            localStorage.setItem('role', response.data[0]);
                        });

                        AccountService.getCurrentUserName().then(response => {
                            localStorage.setItem('userName', response.data)
                        });
                        localStorage.setItem('isAuth', 'true')
                        window.location.reload()
                        window.location.href = '/';
                    }
                })
                    .catch(e => {
                        if (e.response) {
                            this.errorMessage = e.response.data;
                        }
                    });
            },
        }
    }
</script>

<style lang="scss" scoped>
</style>  