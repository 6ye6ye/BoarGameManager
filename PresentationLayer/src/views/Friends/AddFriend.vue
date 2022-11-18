<template>
    <div class="form-control border bg-light">
        <h2>Add friend</h2>
        <div class="row">
            <label class="control-label">User name:</label>
            <input type="text" v-model="name" class="form-control" />
            <button v-on:click="addGamePlace()" type="button" class="btn btn-primary">Add</button>
        </div>

        <table  class="table">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>

                <tr v-for="item in games" :key="item.Id">
                    <td>{{item.id}}</td>
                    <td>{{item.userName }}</td>
                    <td><button v-on:click="goToAdd(item.id)" type="button" class="btn btn-info">Add</button></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import GamePlaceService from "../../services/GamePlaceService";
    export default {
        name: 'AddGamePlace',
        data() {
            return {
                name: ""
            }
        },
        methods: {
            addGamePlace: function () {
                GamePlaceService.AddGamePlace(this.name)
                    .then(response => {
                        console.log(response.data)
                        this.$emit('close');
                        this.$emit('get-user-game-places');
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
