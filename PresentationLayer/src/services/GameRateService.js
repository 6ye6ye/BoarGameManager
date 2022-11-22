import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GameRateService {
  
    async getCurrentUserGameRate(id) {
        return await axios.get(url + '/api/GameRate/user-gameRate'+ id);
    }
    async PutGameRate(gameId, rate) {

        return await axios({
            method: 'put',
            url: url + '/api/GameRate',
            data: {
                gameId: gameId,
                rate: rate,
            }
        });
    }

}
export default new GameRateService();  