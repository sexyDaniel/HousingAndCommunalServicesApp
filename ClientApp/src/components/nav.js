import React from 'react';
import { Link, BrowserRouter, NavLink } from 'react-router-dom';

export default class Nav extends React.Component {
    render() {
        return <div>
            <Link to="/"><div className="nav-logo">ЖКУ</div></Link>
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
            </ul>
        </div>;
    }
}