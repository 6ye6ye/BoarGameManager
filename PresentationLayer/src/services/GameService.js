import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GameService {

    async GetAll() {
        return await axios.get(url + '/api/Games');
    }
    async GetAllWithFilters(filter) {
        return await axios.get(url + '/api/Games/Filtered', {
            params: {
                name: filter.name,
                releaseYear: filter.releaseYear != '' ? filter.releaseYear:0,
                minRate: filter.minRate,
                maxRate: filter.maxRate,
                showAdded: filter.showAdded
            }
        })
    }
    async GetTopTenGames() {
        return await axios.get(url + '/api/Games/top');
    }
    

    async GetAllShort() {
        return await axios.get(url + '/api/Games/short');
    }
    async GetById(id) {
        return await axios.get(url + '/api/Games/'+id);
    }

    async Add(file, game) {
        if (file != null) {
            let formData = new FormData();
            formData.append("file", file);
            var patch = await axios.post(url + '/api/Games/image',
                formData)
                .then(response => response.data);
        }

        return await axios({
            method: 'post',
            url: url + '/api/Games',
            data: {
                id: game.id,
                image: patch,
                name: game.name,
                nameRu: game.nameRu,
                nameEng: game.nameEng,
                gameInfoShort: game.gameInfoShort,
                gameInfo: game.gameInfo,
                playersMinCount: game.playersMinCount,
                playersMaxCount: game.playersMaxCount,
                minAge: game.minAge,
                minPartyTime: game.minPartyTime,
                maxPartyTime: game.maxPartyTime,
                releaseYear: game.releaseYear
            }
        });
    }

    async Edit(game) {
        return await axios.put(url + '/api/Games', {
            id: game.id,
            image: game.image.replace('https://localhost:5001/images/', ''),
            name: game.name,
            nameRu: game.nameRu,
            nameEng: game.nameEng,
            gameInfoShort: game.gameInfoShort,
            gameInfo: game.gameInfo,
            playersMinCount: game.playersMinCount,
            playersMaxCount: game.playersMaxCount,
            minAge: game.minAge,
            minPartyTime: game.minPartyTime,
            maxPartyTime: game.maxPartyTime,
            releaseYear: game.releaseYear
        });
    }

    async Delete(id) {
        return await axios.delete(url + '/api/Games/' + id);
    }
    
}
export default new GameService();  