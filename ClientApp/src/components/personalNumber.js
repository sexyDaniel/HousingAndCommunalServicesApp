import React from "react"

export default class PersonalNumber extends React.Component {
    constructor(props) {
        super(props);
        this.state = { personalNumber:""}
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
            if (data.owner!==null) {
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
                <h2>Введите лицевой счет</h2>
                <form onSubmit={this.post}>
                    <input onChange={this.onPersinalNumberChange} maxLength="9" className="form-control" placeholder="Лицевой счет" />
                    <div id="passwordHelpBlock" className="form-text">
                        Ваш лицевой счет это девятизначный номер
                            </div>
                    <button className="btn btn-primary">Посмотреть</button>
                </form>
            </div>
        </div>
    }
}