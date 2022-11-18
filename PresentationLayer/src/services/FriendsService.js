import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class FriendsService {

    async getAllFriends() {
        return await axios.get(url + '/api/UserFriends/Friends');
    }
    async getAllIncomingRequests() {
        return await axios.get(url + '/api/UserFriends/InputRequests');
    }
    async getAllOutrequests() {
        return await axios.get(url + '/api/UserFriends/OutRequests');
    }
    async Delete(id) {
        return await axios.delete(url + '/api/UserFriends/' + id);
    }
}
export default new FriendsService()
