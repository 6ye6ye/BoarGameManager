import axios from 'axios';
var url = "https://localhost:5001"
export default class AccountService {

    static async getCurrentUserId() {

       return await axios.get(url + '/API/Account/getId');

    }
}
