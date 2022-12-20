import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GameService {

    async GetUserGames() {
        return await axios.get(url + '/api/UserGames');
    }
  
    async Add(gameId) {
        return await axios.post(url + '/api/UserGames/' + gameId);

    }
    async Delete(id) {
        return await axios.delete(url + '/api/UserGames/' + id);
    }
}
export default new GameService();  