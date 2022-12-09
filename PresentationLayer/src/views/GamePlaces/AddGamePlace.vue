<template>
    <form ref="form" class="col-sm" @submit.prevent="addGamePlace" method="post">

 
            <h2>Game place</h2>

            <div class="row">
                <label class="control-label">Name:</label>
                <input type="text" v-model="name" minlength="3" maxlength="50" class="form-control" required />
            </div>
     
            <button  type="submit" class="button-submit btn btn-primary">Add</button>
            <p class="text-danger"> {{errorMessage}}</p>
      
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
