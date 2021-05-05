import React from "react"

export default class AdminAuth extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Login: "",
            Password:""
        }
        this.logIn = this.logIn.bind(this)
        this.onPersinalNumberChange = this.onPersinalNumberChange.bind(this)
        this.onLoginChange = this.onLoginChange.bind(this)
        this.onPasswordChange = this.onPasswordChange.bind(this)
    }
    onLoginChange(e) {
        this.setState({ Login: e.target.value })
    }
    onPasswordChange(e) {
        this.setState({ Password: e.target.value })
    }
    async logIn(e) {
        e.preventDefault();
        if (this.state.Login.length ===0) {
            alert("Вы не ввели логин")
        } else if (this.state.Password.length === 0) {
            alert("Вы не ввели Пароль")
        } else  {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    Login: this.state.Login,
                    Password: this.state.Password
                })
            };
            const response = await fetch('/Authorization/AdminAuthorization', requestOptions);
            const data = await response.json();
            console.log(data)
            if (data.isSuccessfull) {
                document.location.href = "/admin/addCharges"
            } else {
                alert(data.errors)
            }
        }
    }
    onPersinalNumberChange(e) {
        this.setState({ personalNumber: e.target.value })
    }
    render() {
        return <div>
            <div className="form shadow">
                <form onSubmit={this.logIn }>
                    <input onChange={this.onLoginChange} className="form-control" placeholder="Логин" />
                    <input onChange={this.onPasswordChange} type="password" className="form-control" placeholder="Пароль" />
                    <button className="btn btn-primary">Войти</button>
                </form>
            </div>
        </div>
    }
}