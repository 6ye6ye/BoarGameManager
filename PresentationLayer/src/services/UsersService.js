import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class UsersService {

    async GetAll() {
        return await axios.get(url + '/api/Users');
    }
    async GetById(id) {
        return await axios.get(url + '/api/Users/'+id);
    }
    async GetCurrent() {
        return await axios.get(url + '/api/Users/Current');
    }
    async GetfirstTenUsers(name) {
        return await axios.get(url + '/api/Users/search/' + name);
    }

    async GetAllWithFilters(filter) {
        return await axios.get(url + '/api/Users/Filtered', {
            params: {
                name: filter.name,
                email: filter.email,
                roleId: filter.roleId
            }
        }
        )
    }
    async Delete(id) {
        return await axios.delete(url + '/api/Users/' + id);
    }
}
export default new UsersService()
