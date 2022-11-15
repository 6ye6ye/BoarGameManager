<template>
    <p>Список друзей</p>
    <div class="post">
        <div class="row" style="margin-bottom: 10px;">
        </div>
        <div>
            <table class="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>FriendId</th>
                        <th>Name</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    
                    <tr v-for="item in friends" :key="item.Id">
                        <td>{{item.id}}</td>
                        <td>{{item.friend.id }}</td>
                        <td>{{item.friend.userName }}</td>
                        <td>{{item.status}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
        </div>
</template>  
  
<script>  

    import FriendsService from "../../services/FriendsService";  
    export default {  
        name: 'FriendsView',  
             data() {  
                return {  
                    friends: [],  
                    };  
             },  
            created()  
            {  
                this.retrieveGames();  
            },  
        methods: {  
            retrieveGames() {  
                FriendsService.getAll().then(response => {  
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
