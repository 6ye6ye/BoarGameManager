<template>
    <form ref="form" @submit.prevent="tryChangePassword" method="post">
        <h2> Change password</h2>
        <div class="row">
            <div>
                <label class="form-label">New password</label>
                <input type="password" v-model="passwordNew" class="form-control" minlength="6" maxlength="100" required />
            </div>
            <div>
                <label class="form-label">New password repeat</label>
                <input type="password" v-model="passwordNewRepeat" class="form-control" minlength="6" maxlength="100" required />
            </div>
            <p class="text-danger">{{errorMessage}}</p>
        </div>
        <button type="submit" class="btn btn-primary"> Save </button>
    </form>
</template>

<script>
    import AccountService from "../../services/AccountService";
    export default {
        name: 'ChangePasswordView',
        emits: ['close'],
        data() {
            return {
                passwordNew: '',
                passwordNewRepeat: '',
                errorMessage:''
            }
        },
        computed: {
            isValid() {
                return  this.passwordNew && this.passwordNewRepeat
            }
        },
        methods: {
            async tryChangePassword() {
                if (!this.isValid) return false
                if (this.passwordNew == this.passwordNewRepeat) {
                    AccountService.ChangePassword( this.passwordNew, this.passwordNewRepeat).then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                        }
                    })
                        .catch(e => {
                            if (e.response) {
                                this.errorMessage = e.response.data;
                            }
                        });
                }
                else {
                    this.errorMessage = "Passwords did not match"
                }
            },
        }
    }
</script>

<style lang="scss" scoped>
</style>  