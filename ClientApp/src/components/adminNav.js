import React from 'react';
import { Link, BrowserRouter, NavLink } from 'react-router-dom';
import Cookies from 'js-cookie';

export default class AdminNav extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isAuth: this.props.auth,
            personalNumber: Cookies.get('currentOwner')
        };
        this.Exit = this.Exit.bind(this)

    }
    async Exit(e) {
        e.preventDefault();
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ id: this.state.personalNumber })
        };
        const response = await fetch('/Authorization/Exit', requestOptions);
        document.location.href = "/"
    }
    render() {
            return <div>
                <Link to="/"><div className="nav-logo">Admin</div></Link>
                <ul className="nav flex-column">
                    <li className="nav-item">
                        <NavLink exact to="/admin/addCharges" className="link" activeClassName="active">Загрузить начисления</NavLink>
                        <NavLink exact to="/admin/owners" className="link" activeClassName="active">Пользователи</NavLink>
                    </li>
                    <li className="nav-item m-3">
                        <form onSubmit={this.Exit} className="exit">
                            <button className="btn btn-danger">Выход</button>
                        </form>
                    </li>
                </ul>
            </div>
    }
}