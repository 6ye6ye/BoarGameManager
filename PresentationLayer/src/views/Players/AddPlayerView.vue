<template>
    <div class="row ">
        <div class=" mx-auto">
          
            <div class="form-group ">
                <label class="control-label">Name</label>
                <input type="text" v-model="name" minlength="3" maxlength="50" class="form-control" required />
            </div>
            <div class="form-group">
                <label class="control-label"></label>
                <button v-on:click="addPlayer()" type="button" class="button-submit btn btn-success ">Add</button>
            </div>
        </div>
    </div>
</template>

<script>
    import PlayersService from "../../services/PlayersService";
    export default {
        data() {
            return {
                name:''      
            }
        },
        methods: {
            addPlayer: function () {
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
