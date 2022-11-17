import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
export default class FriendsService {

    getAll() {
        return axios.get(url + '/api/UserFriends/Current');
    }

}
