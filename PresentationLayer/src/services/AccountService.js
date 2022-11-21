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

    static async register(login, email, password, passwordRepeat, name) {

        var rezult = await axios({
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

        switch (rezult.status) {
            case (200):
                {
                    window.location.href = '/'
                    this.$router.push({ name: 'GamesView' })
                    return { ok: true }
                }
            case (400):
                return { ok: false }
        }

    }

    static async logout() {

        var rezult = await axios({
            method: 'post',
            url: url + '/API/Account/Logout',
        });

        switch (rezult.status) {
            case (200):
                {
                    return { ok: true }
                }
            case (400):
                return { ok: false }
        }

    }
}