import axios from 'axios';
var url = "https://localhost:5001"
export default class AccountService {

    static async login(email, password, rememberMe) {
        return await axios({
            method: 'post',
            url: url + '/API/Account/Login',
            data: {
                login: email,
                password: password,
                rememberMe: rememberMe
            }
        });
    }
    static async ChangePassword( passwordNew, passwordNewRepeat) {
        return await axios({
            method: 'post',
            url: url + '/API/Account/ChangePassword',
            data: {
                passwordNew: passwordNew,
                passwordNewRepeat: passwordNewRepeat
            }
        });
    }
    static async getCurrentUserRole() {
        return await axios({
            method: 'get',
            url: url + '/API/Account/Role'
        });
    }
    static async getCurrentUserName() {
        return await axios({
            method: 'get',
            url: url + '/API/Account/userName'
        });
    }
    
    static async register(login, email, password, passwordRepeat, name) {
         return await axios({
            method: 'post',
            url: url + '/API/Account/Register',
            data: {
                login: login,
                email: email,
                password: password,
                passwordRepeat: passwordRepeat,
                name: name
            }
        });

    }

    static async logout() {

        return await axios({
            method: 'post',
            url: url + '/API/Account/Logout',
        });



    }
}