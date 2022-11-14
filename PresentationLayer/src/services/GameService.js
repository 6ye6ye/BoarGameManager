import axios from 'axios';
var url = "https://localhost:5001"
class GameService {

    getAll() {
        return axios.get(url+'/API/Games');
    }

}
export default new GameService();  