<template>
    <form ref="form" class="col-sm" @submit.prevent="editGamePlace" method="post">
      
        <label class="block">
            <span class=" text-gray-700">Name: </span>
            <input type="text"
                   class="block pl-4 w-full  border-gray-200 rounded-md border
                   focus:border-indigo-600 focus:ring focus:ring-opacity-40 focus:ring-indigo-500"
                   minlength="3" maxlength="50"
                   v-model="gamePlace.name" required />
        </label>
        <ErrorMessage :message="errorMessage"></ErrorMessage>
        <button type="submit"
                class="mt-2 w-full px-4 py-2 text-center text-white bg-green-500 rounded-md focus:outline-none hover:bg-green-400">
            Save
        </button>
    </form>
</template>

<script>
    import GamePlaceService from "../../services/GamePlaceService";

    export default {
        name: 'EditGamePlace',
        emits: ['close', 'get-game-places'],
        props: ['gamePlaceId'],
        data() {
            return {
                gamePlace: {
                    id: this.gamePlaceId,
                    name: ''
                },
                errorMessage: ''
            }
        },
        computed: {
            isValid() {
                return this.gamePlace.name
            }
        },
        created() {
            this.getGamePlace();
        },
        methods: {
            async getGamePlace() {
                GamePlaceService.GetGamePlaceShortById(this.gamePlaceId).then(response => {
                    if (response.status==200)
                     this.gamePlace = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            async editGamePlace() {
                if (!this.isValid) return false
                GamePlaceService.Edit(this.gamePlace)
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
