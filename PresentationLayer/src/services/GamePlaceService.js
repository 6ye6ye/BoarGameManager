import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GameEolesService {

    async GetGamePlaces() {
        return await axios.get(url + '/api/UserGamePlaces/short');
    }
    async AddGamePlace(name) {

        return await axios({
            method: 'post',
            url: url + '/api/UserGamePlaces',
            data: {
                 name:name
            }
        });
    }
    async DeleteGamePlace(id) {
        return await axios.delete(url + '/api/UserGamePlaces/' + id);
    }

    //upload(file) {
    //    let formData = new FormData();

    //    formData.append("file", file);

    //    return await axios({
    //        method: 'post',
    //        url: url + '/api/Games',
    //        data: {

    //            image: game.image,
    //            name: game.name,
    //            nameRu: game.nameRu,
    //            nameEng: game.nameEng,
    //            playersMinCount: game.playersMinCount,
    //            playersMaxCount: game.playersMaxCount,
    //            minAge: game.minAge,
    //            minPartyTime: game.minPartyTime,
    //            maxPartyTime: game.maxPartyTime,
    //            releaseYear: game.releaseYear
    //        }
    //    });
    //}



}
export default new GameEolesService();  