import axios from 'axios';
var url = "https://localhost:5001"
export default  class AccountService {

    static async login(email, password, rememberMe) {

        var rezult = await axios({
            method: 'post',
            url: url + '/API/Account/Login',
            data: {
                login: email,
                password: password,
                rememberMe: rememberMe
            }
        });

        switch (rezult.status) {
            case (200):
                {
                    window.location.href = '/'

                    return { ok: true }
                }
            case (400):
                return { ok: false }
        }

    }

    static async register(login,email, password, passwordRepeat,name) {

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
                    window.location.href = ''
                    return { ok: true }
                }
            case (400):
                return { ok: false }
        }

    }

    static async logout() {

        var rezult = await axios({
            method: 'get',
            url: url + '/API/Account/Logout',
        });

        switch (rezult.status) {
            case (200):
                {
                    window.location.href = ''

                    return { ok: true }
                }
            case (400):
                return { ok: false }
        }

    }
}

