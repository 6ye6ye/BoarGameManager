import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GamePartyMembersService {

    async GetAll(id) {
        return await axios.get(url + '/api/GamePartyMembers/gameParty/' + id);

    }

    async GetById(id) {
        return await axios.get(url + '/api/GamePartyMembers/' + id);
    }
    async Add(gameParty) {

        return await axios({
            method: 'post',
            url: url + '/api/GamePartyMembers',

            data: {
                gamePartyId: gameParty.gamePartyId,
                playerId: gameParty.playerId,
                gameRoleId: gameParty.gameRoleId,
                points: gameParty.points,
                isWinner: gameParty.isWinner

            }
        });
    }
    async Delete(id) {
        return await axios.delete(url + '/api/GamePartyMembers/' + id);
    }


}
export default new GamePartyMembersService();  