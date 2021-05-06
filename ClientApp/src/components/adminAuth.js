import React from "react"

export default class AdminAuth extends React.Component {
    constructor(props) {
        super(props);
        this.state = { personalNumber: "" }
        this.post = this.post.bind(this)
        this.onPersinalNumberChange = this.onPersinalNumberChange.bind(this)
    }
    async post(e) {
        e.preventDefault();
        if (this.state.personalNumber.length < 9) {
            alert("Лицевой счет должен состоять из 9 цифр")
        } else {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ id: this.state.personalNumber })
            };
            const response = await fetch('/Authorization/GetOwner', requestOptions);
            const data = await response.json();
            console.log(data)
            if (data.owner !== null) {
                alert("Добро пожаловать, " + data.owner.firstName + ' ' + data.owner.patronymic)
                localStorage.setItem('owner', JSON.stringify(data))
                document.location.href = "/charges"
            } else {
                alert("Такого ЛС нет")
            }
        }
    }
    onPersinalNumberChange(e) {
        this.setState({ personalNumber: e.target.value })
    }
    render() {
        return <div>
            <div className="form shadow">
                <form>
                    <input className="form-control" placeholder="Логин" />
                    <input type="password" className="form-control" placeholder="Пароль" />
                    <button className="btn btn-primary">Войти</button>
                </form>
            </div>
        </div>
    }
}