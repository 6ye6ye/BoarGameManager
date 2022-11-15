import axios from 'axios';
var url = "https://localhost:5001"
class FriendsService {

    getAll() {
        return axios.get(url + '/api/UserFriends/Current');
    }

}
export default new FriendsService();  