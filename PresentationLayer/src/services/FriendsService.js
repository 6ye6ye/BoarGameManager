import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class FriendsService {

    async getAllFriends() {
        return await axios.get(url + '/api/UserFriends/Friends');
    }
    async getAllIncomingRequests() {
        return await axios.get(url + '/api/UserFriends/IncomingRequests');
    }
    async getAllOutrequests() {
        return await axios.get(url + '/api/UserFriends/OutRequests');
    }
 
    async Delete(id) {
        return await axios.delete(url + '/api/UserFriends/' + id);
    }

    async AddFriend(id) {

        return await axios({
            method: 'post',
            url: url + '/api/UserFriends',
            data: {
                outRequestUser: id
            }
        });
    }
    async Ignore(id) {
        return await axios.put(url + '/api/UserFriends/Ignore/' + id);
    }
    async AcceptRequest(id) {
        return await axios.put(url + '/api/UserFriends/Accept/' + id);

    }
}
export default new FriendsService()
