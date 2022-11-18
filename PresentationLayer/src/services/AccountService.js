import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class UsersService {

    async getFirstTenUsers(name) {
        return await axios.get(url + '/api/Users/search', name);
    }
 
    async Delete(id) {
        return await axios.delete(url + '/api/UserFriends/' + id);
    }
}
export default new UsersService()
