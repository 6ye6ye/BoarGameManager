import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GameService {

    async GetAll() {
        return await axios.get(url + '/api/Games');
    }
    async GetAllWithFilters(filter) {
        return await axios.get(url + '/api/Games/Filtered', {
            params: {
                name: filter.name,
                releaseYear: filter.releaseYear != '' ? filter.releaseYear:0,
                minRate: filter.minRate,
                maxRate: filter.maxRate,
                showAdded: filter.showAdded
            }
        }
        )
    }
    
    //async GetAllWithFilters(gameFilter) {
    //    return await axios({
    //        method: 'get',
    //        url: url + '/api/Games/Filtered',

    //        data: {
              
    //                Name: gameFilter.name,
    //                PlayersMinCount: gameFilter.minRate,
    //                PlayersMaxCount: gameFilter.maxRate,
    //                //minAge: game.minAge,
    //                // minPartyTime: game.minPartyTime,
    //                //  maxPartyTime: game.maxPartyTime,
    //                ReleaseYear: gameFilter.releaseYear
              
    //        }
    //    });
    //}
    
    async GetUserGames() {
        return await axios.get(url + '/api/Games');
    }
    async GetAllShort() {
        return await axios.get(url + '/api/Games/short');
    }
    async GetById(id) {
        return await axios.get(url + '/api/Games/'+id);
    }
    async Add(file,game) {
    //async AddGame(game) {
      
        let formData = new FormData();
        formData.append("file", file);
        var patch = await axios.post(url + '/api/Games/image',
            formData)
            .then(response => response.data);
   
        return  await axios({
            method: 'post',
            url: url + '/api/Games',
        
            data: {
                image: patch,
                name: game.name,
                nameRu: game.nameRu,
                nameEng: game.nameEng,
                playersMinCount: game.playersMinCount,
                playersMaxCount: game.playersMaxCount,
                minAge: game.minAge,
                minPartyTime: game.minPartyTime,
                maxPartyTime: game.maxPartyTime,
                releaseYear: game.releaseYear
            } 
        });
    }
    async Delete(id) {
        return await axios.delete(url + '/api/Games/' + id);
    }

        

    
}
export default new GameService();  