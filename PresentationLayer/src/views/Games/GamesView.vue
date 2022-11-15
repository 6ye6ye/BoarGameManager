<template>
    <p>Список игр</p>
    <div class="post">
        <div class="row" style="margin-bottom: 10px;">
        </div>
        <div>
            <table class="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Изображение</th>
                        <th>Наименование</th>
                        <th>Ru/Eng</th>
                        <th>Рейтинг</th>
                        <th>Мин. кол-во</th>
                        <th>Макс. кол-во</th>
                        <th>Мин. возраст</th>
                        <th>Мин. время игры</th>
                        <th>Макс. время игры</th>
                        <th>Год релиза</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    
                    <tr v-for="item in games" :key="item.Id">
                        <td>{{item.id}}</td>
                        <td>{{item.image }}</td>
                        <td>{{item.name }}</td>
                        <td>{{item.nameRu}}|{{item.nameEng}}</td>
                        <td>{{item.rating }}</td>
                        <td>{{item.playersMinCount }}</td>
                        <td>{{item.playersMaxCount }}</td>
                        <td>{{item.minAge }}</td>
                        <td>{{item.minPartyTime }}</td>
                        <td>{{item.maxPartyTime }}</td>
                        <td>{{item.releaseYear }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
        </div>
</template>  
  
<script>  

    import GamesService from "../../services/GameService";  
    export default {  
        name: 'GamesView',  
            data() {  
                return {  
                    games: [],  
                };  
            },  
            created()  
                {  
                this.getGames();  
            },  
      
        methods: {  
        getGames() {  
            GamesService.GetAll().then(response => {  
                this.games = response.data;  
          console.log(response.data);  
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
