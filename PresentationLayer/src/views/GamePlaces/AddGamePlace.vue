<template>
    <form ref="form" class="col-sm" @submit.prevent="addGamePlace" method="post">
        <label class="block">
            <span class=" text-gray-700">Name</span>
            <input type="text"
                   class="block pl-4 w-full  border-gray-200 rounded-md border
                   focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   v-model="name"
                   minlength="3" maxlength="50" required />
        </label>

        <ErrorMessage :message="errorMessage"></ErrorMessage>
        <button type="submit"
                class="mt-2 w-full px-4 py-2 text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
            Add
        </button>
    </form>
</template>

<script>
    import GamePlaceService from "../../services/GamePlaceService";

    export default {
        name: 'AddGamePlace',
        emits: ['close', 'get-game-places'],
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
            async addGamePlace() {
                if (!this.isValid) return false
                GamePlaceService.AddGamePlace(this.name)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-game-places');
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
