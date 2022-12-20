import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GameParserService {
    async GetTopByRate(count) {
        return await axios.get(url + '/api/GameParser/top-by-rate', {
            params: {
                count: count,
            }
        })
    }

    async GetLastAddedGamesFromApi(count) {
        return await axios.get(url + '/api/GameParser/last-added', {
            params: {
                count: count,
            }
        })
    }

    async GetByGameAlias (name) {
        return await axios.get(url + '/api/GameParser/by-alias', {
            params: {
                name: name,
            }
        })
    }

    async GetByUserCollection(name,count) {
        return await axios.get(url + '/api/GameParser/by-user', {
            params: {
                userName: name,
                count: count,
            }
        })
    }

}
export default new GameParserService()
