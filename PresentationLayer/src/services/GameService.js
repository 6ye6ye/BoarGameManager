import axios from 'axios';
var url = "https://localhost:5001"
class GameService {

       GetAll() {
        return  axios.get(url + '/api/Games');
    }
    //static async AddGame(game) {

    //    var rezult = await axios({
    //        method: 'post',
    //        url: url + '/API/Games/PostGame',
    //        data: {
    //            game:game
    //        }
    //    });
    //}
}
export default new GameService();  