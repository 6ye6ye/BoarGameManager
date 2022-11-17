import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GamePartyMembersService {

    async GetAll(id) {
        return await axios.get(url + '/api/GamePartyMembers/gameParty', id);
    }

    async GetById(id) {
        return await axios.get(url + '/api/GamePartyMembers/' + id);
    }
    async Add(gameParty) {

        return await axios({
            method: 'post',
            url: url + '/api/GameParties',

            data: {
                date: gameParty.date,
                gameId: gameParty.gameId,
                userGamePlaceId: gameParty.userGamePlaceId

            }
        });
    }
    async Delete(id) {
        return await axios.delete(url + '/api/GameParties/' + id);
    }


}
export default new GamePartyMembersService();  