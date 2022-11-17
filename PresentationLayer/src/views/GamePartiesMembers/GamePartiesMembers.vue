<template>
    <h3>Game party members list</h3> 

       
</template>  
  



<script>  



    import GamePartyMemberService from "../../services/GamePartyMemberService";  
    export default {
        name: 'GamePartiesView',
      
        data() {
            return {
                gamePartyMembers: [],
            };
        },
        created() {
            this.getGamePartyMembers();
        },
         methods: {
             getGamePartyMembers() {
                 GamePartyMemberService.GetAll().then(response => {
                     this.gameParties = response.data;
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            goToAdd() {
                this.$router.push({ name: 'AddGamePartyMemberView' })
            },
            goToDelete(id) {
                GamePartyMemberService.Delete(id).then(response => {
                    console.log(response.data);
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
        },
    }
</script>  
  
<style lang="scss" scoped>  
  
</style>  
