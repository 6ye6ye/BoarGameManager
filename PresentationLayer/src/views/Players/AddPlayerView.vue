<template>
    <form ref="form" class="col-sm" @submit.prevent="addPlayer" method="post">
        <div class="row ">
            <div class=" mx-auto">
                <h2>Player</h2>
                <input placeholder="Input name" type="text" v-model="name" minlength="3" maxlength="50" class="form-control" required />
                <button type="submit" class="button-submit btn btn-success ">Add</button>
            </div>
            <p class="text-danger"> {{errorMessage}}</p>
        </div>
    </form>
</template>

<script>
    import PlayersService from "../../services/PlayersService";
    export default {
        data() {
            return {
                name:''      
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
