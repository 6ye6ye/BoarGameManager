import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class RolesService {

    async getAll() {
        return await axios.get(url + '/api/Roles');
    }
    
}
export default new RolesService()
