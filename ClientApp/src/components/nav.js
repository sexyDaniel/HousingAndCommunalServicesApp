import React from 'react';
import { Link, BrowserRouter, NavLink } from 'react-router-dom';
import Cookies from 'js-cookie';

export default class Nav extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isAuth: this.props.auth,
            personalNumber: Cookies.get('currentOwner'),
            admin: this.props.admin
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
        if (!this.state.isAuth) {
            return <div>
                <Link to="/"><div className="nav-logo">ЖКУ</div></Link>
                <ul className="nav flex-column">
                    <li className="nav-item">
                        <NavLink exact to="/personalNumber" className="link" activeClassName="active">Ввести лицевой счет</NavLink>
                    </li>
                </ul>
            </div>;
        }else if (this.state.admin === "Admin12345") {
            return <div>
                <Link to="/"><div className="nav-logo">Admin</div></Link>
                <ul className="nav flex-column">
                    <li className="nav-item">
                        <NavLink exact to="/admin/addCharges" className="link" activeClassName="active">Загрузить начисления</NavLink>
                    </li>
                </ul>
            </div>;
        } else {
            return <div>
                <Link to="/"><div className="nav-logo">
                    ЖКУ
                    <h5>ЛС:{this.state.personalNumber}</h5>
                    </div>
                </Link>
 
                <ul className="nav flex-column">
                    <li className="nav-item">
                        <NavLink exact to="/personalNumber" className="link" activeClassName="active">Ввести лицевой счет</NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink className="link" to="/charges" activeClassName="active">Начисления</NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink className="link" to="/calc" activeClassName="active">Калькулятор</NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink className="link" to="/companys" activeClassName="active">Обслуживающие организации</NavLink>
                    </li>
                    <li className="nav-item m-3">
                        <form onSubmit={this.Exit} className="exit">
                            <button className="btn btn-danger">Выход</button>
                        </form>
                    </li>
                </ul>
            </div>;
        }
       
    }
}