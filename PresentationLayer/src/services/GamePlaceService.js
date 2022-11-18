import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GamePlaceService {

    async GetGamePlaces() {
        return await axios.get(url + '/api/UserGamePlaces/short');
    }
    async AddGamePlace(name) {

        return await axios({
            method: 'post',
            url: url + '/api/UserGamePlaces',
            data: {
                name: name
            }
        });
    }
    async DeleteGamePlace(id) {
        return await axios.delete(url + '/api/UserGamePlaces/' + id);
    }
}
export default new GamePlaceService();  