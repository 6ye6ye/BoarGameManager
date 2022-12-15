import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GamePlaceService {

    async GetCurrentUserGamePlaces() {
        return await axios.get(url + '/api/UserGamePlaces/current/short');
    }
    async GetGamePlaceById(id) {
        return await axios.get(url + '/api/UserGamePlaces/' + id);
    }
    async GetGamePlaceShortById(id) {
        return await axios.get(url + '/api/UserGamePlaces/short/'+id);
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
    async Edit(gamePlace) {
        return await axios.put(url + '/api/UserGamePlaces', {
            id: gamePlace.id,
            name: gamePlace.name,
        });
    }
    async DeleteGamePlace(id) {
        return await axios.delete(url + '/api/UserGamePlaces/' + id);
    }
}
export default new GamePlaceService();  