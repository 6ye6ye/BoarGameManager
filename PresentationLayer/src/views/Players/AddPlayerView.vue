<template>
    <form ref="form" class="col-sm" @submit.prevent="addPlayer" method="post">
        <div class="row ">
            <h2>Player</h2>
            <input placeholder="Input name" type="text" v-model="name" minlength="3" maxlength="50" class="form-control" required />
        </div>
        <p class="text-danger"> {{errorMessage}}</p>
        <button type="submit" class="button-submit btn button-primary ">Add</button>
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
