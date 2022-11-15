<template>
    <p>Список игр</p>
    <div class="post">


        <div>
            <label class="form-label">Name</label>
            <input type="text" v-model="name" class="form-control" />
        </div>
        <div>
            <label class="form-label">NameRu</label>
            <input type="text" v-model="nameRu" class="form-control" />
        </div>
        <div>
            <label class="form-label">NameEng</label>
            <input type="text" v-model="nameEng" class="form-control" />
        </div>
        <div>
            <label class="form-label">Image</label>
            <input type="image" v-model="image" class="form-control" />
        </div>
        <div>
            <label class="form-label">PlayersMinCount</label>
            <input type="number" v-model="playersMinCount" class="form-control" />
        </div>
        <div>
            <label class="form-label">PlayersMaxCount</label>
            <input type="number" v-model="playersMaxCount" class="form-control" />
        </div>
        <div>
            <label class="form-label">MinAge</label>
            <input type="number" v-model="minAge" class="form-control" />
        </div>
        <div>
            <label class="form-label">MinPartyTime</label>
            <input type="number" v-model="minPartyTime" class="form-control" />
        </div>
        <div>
            <label class="form-label">MaxPartyTime</label>
            <input type="number" v-model="maxPartyTime" class="form-control" />
        </div>
        <div>
            <label class="form-label">ReleaseYear</label>
            <input type="number" v-model="releaseYear" class="form-control" />
        </div>
       <!-- <button v-on:click="addGame()" type="button" class="btn">Add</button>-->

    </div>

</template>  
  
<script>  

    //import GamesService from "../../services/GameService";  


    //export default {
    //    name: 'GameAddView',
    //    data() {
    //        return {
    //            image: '',
    //            name: '',
    //            nameRu: '',
    //            nameEng: '',
    //            playersMinCount: 0,
    //            playersMaxCount: 0,
    //            minAge: 0,
    //            minPartyTime: 0,
    //            maxPartyTime: 0,
    //            releaseYear: 2022
    //        }
    //    },
    //    methods: {
    //        trylogin: function () {
    //            GamesService.AddGame(
    //                this.image,
    //                this.name,
    //                this.nameRu,
    //                this.nameEng,
    //                this.playersMinCount,
    //                this.playersMaxCount,
    //                this.minAge,
    //                this.minPartyTime,
    //                this.maxPartyTime,
    //                this.releaseYear

    //            ).then(response => {

    //                console.log(response.data);
    //            })
    //                .catch(e => {
    //                    console.log(e);
    //                });
    //        },

    //    }
    //}

</script>  
  
<style lang="scss" scoped>  
  
</style>  
