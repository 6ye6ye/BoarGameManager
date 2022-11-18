import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GameRolesService {

    async GetGameRolesByGame(id) {
        return await axios.get(url + '/api/GameRoles/game', { params: { id: id } });
    }
    async AddGameRole(gameRole) {

        return await axios({
            method: 'post',
            url: url + '/api/GameRoles',

            data: {
                gameId: gameRole.gameId*1,
                name: gameRole.name
            }
        });
    }
    async DeleteGameRole(id) {
        return await axios.delete(url + '/api/GameRoles/' + id);
    }
  
    //upload(file) {
    //    let formData = new FormData();

    //    formData.append("file", file);

    //    return await axios({
    //        method: 'post',
    //        url: url + '/api/Games',
    //        data: {

    //            image: game.image,
    //            name: game.name,
    //            nameRu: game.nameRu,
    //            nameEng: game.nameEng,
    //            playersMinCount: game.playersMinCount,
    //            playersMaxCount: game.playersMaxCount,
    //            minAge: game.minAge,
    //            minPartyTime: game.minPartyTime,
    //            maxPartyTime: game.maxPartyTime,
    //            releaseYear: game.releaseYear
    //        }
    //    });
    //}
          

    
}
export default new GameRolesService();  