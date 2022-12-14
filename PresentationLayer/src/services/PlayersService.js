import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class PlayersService {

    async GetPlayersForUser() {
        return await axios.get(url + '/api/Players/current');
    }
    async GetCreatedPlayers() {
        return await axios.get(url + '/api/Players/created');
    }
    async GetByIdShort(id) {
        return await axios.get(url + '/api/Players/short/'+id);
    }
    async AddPlayer(name) {

        return await axios({
            method: 'post',
            url: url + '/api/Players',
            data: {
                name: name
            }
        });
    }

    async Edit(player) {
        return await axios.put(url + '/api/Players', {
            id: player.id,
            name: player.name,
        });
    }

    async DeletePlayer(id) {
        return await axios.delete(url + '/api/Players/' + id);
    }
}
export default new PlayersService