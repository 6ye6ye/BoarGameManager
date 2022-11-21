import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class UsersService {
  
       async getFirstTenUsers(name) {

           return await axios.get(url + '/api/Users/search/'+ name);

    }

    //async getFirstTenUsers(name) {

    //    return await axios.get(url + '/api/Users/search', name);

    //}

    //async getFirstTenUsers(userName) {

    //    return await axios({
    //        method: 'get',
    //        url: url + '/api/Users/search',
    //        data: {
    //            userName: 'userName'
    //        }
    //    });
    //}

    async Delete(id) {
        return await axios.delete(url + '/api/UserFriends/' + id);
    }
}
export default new UsersService()
