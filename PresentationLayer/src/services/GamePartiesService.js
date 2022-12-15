import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GamePartiesService {

    async GetAll() {
        return await axios.get(url + '/api/GameParties');
    }

    async GetById(id) {
        return await axios.get(url + '/api/GameParties/'+id);
    }

    async GetAllWithFilters(filter) {
        return await axios.get(url + '/api/GameParties/filtered', {
            params: {
                gameName: filter.gameName,
                startDate: filter.startDate,
                endDate: filter.endDate,
                gamePlaceId: filter.gamePlaceId,
                playerId: filter.playerId,
                created: filter.created
            }
        })
    }

    async Add(gameParty) {
        return  await axios({
            method: 'post',
            url: url + '/api/GameParties',
        
            data: {
                date: gameParty.date,
                gameId: gameParty.gameId,
                userGamePlaceId: gameParty.userGamePlaceId

            } 
        });
    }

    async Edit(gameParty) {
        return await axios.put(url + '/api/GameParties', {
            id: gameParty.id,
            date: gameParty.date,
            userGamePlaceId: gameParty.userGamePlace.id,
            gameId: gameParty.game.id,
        });
    }

    async Delete(id) {
        return await axios.delete(url + '/api/GameParties/' + id);
    }
    
}
export default new GamePartiesService();  