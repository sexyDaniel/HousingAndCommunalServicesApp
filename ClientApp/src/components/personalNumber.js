import React from "react"

export default class PersonalNumber extends React.Component {
    render() {
        return <div>
            <div className="form shadow">
                <h2>Введите лицевой счет</h2>
                <form>
                    <input maxLength="9" className="form-control" placeholder="Лицевой счет" />
                    <div id="passwordHelpBlock" className="form-text">
                        Ваш лицевой счет это девятизначный номер
                            </div>
                    <button className="btn btn-primary">Посмотреть</button>
                </form>
            </div>
        </div>
    }
}