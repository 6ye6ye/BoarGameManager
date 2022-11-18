<template>

    <div class="row ">
        <div class="col-md-4 mx-auto">

            <div class="form-group ">
                <label class="control-label">Name</label>
                <input type="text" v-model="name" class="form-control" />
            </div>

            <div class="form-group">
                <label class="control-label"></label>
                <button v-on:click="addPlayer()" type="button" class="btn btn-success ">Add</button>
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
                        console.log(response.data);
                        this.$emit('close');
                        this.$emit('get-players');
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
