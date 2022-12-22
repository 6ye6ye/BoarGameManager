<template>
    <form ref="form" class="col-sm" @submit.prevent="addPlayer" method="post">
        <label class="block">
            <span class=" text-gray-700">Name</span>
            <input type="text"
                   placeholder="Input name"
                   class="block pl-4 w-full  border-gray-200 rounded-md border
                   focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   v-model="name"
                   minlength="3" maxlength="50" required />
        </label>

        <ErrorMessage class="text-danger" :message="errorMessage"> </ErrorMessage>
        <button type="submit"
                class="mt-2 w-full px-4 py-2 text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
            Add
        </button>
    </form>
</template>

<script>
    import PlayersService from "../../services/PlayersService";
    export default {
        data() {
            return {
                name: '',
                errorMessage: ''
            }
        },
        computed: {
            isValid() {
                return this.name
            }
        },
        methods: {
            async addPlayer() {
                if (!this.isValid) return false
                PlayersService.AddPlayer(this.name)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-players');
                        }
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
