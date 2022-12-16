import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class ParserService {
    async DownloadGamesFromApi() {
        return await axios.get(url + '/api/Parser/games');
    }
}
export default new ParserService