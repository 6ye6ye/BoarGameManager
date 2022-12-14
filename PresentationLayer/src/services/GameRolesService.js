import axios from 'axios';
axios.defaults.withCredentials = true;
var url = "https://localhost:5001"
class GameRolesService {

    async GetGameRolesByGame(id) {
        return await axios.get(url + '/api/GameRoles/game', { params: { id: id } });
    }

    async GetGameRoleById(id) {
        return await axios.get(url + '/api/GameRoles/' + id);
    }

    async AddGameRole(gameRole) {
        return await axios({
            method: 'post',
            url: url + '/api/GameRoles',

            data: {
                gameId: gameRole.gameId,
                name: gameRole.name
            }
        });
    }

    async Edit(gameRole) {
        return await axios.put(url + '/api/GameRoles', {
            id: gameRole.id,
            name: gameRole.name,
            gameId: gameRole.gameId
        });
    }

    async DeleteGameRole(id) {
        return await axios.delete(url + '/api/GameRoles/' + id);
    }
}
export default new GameRolesService();  