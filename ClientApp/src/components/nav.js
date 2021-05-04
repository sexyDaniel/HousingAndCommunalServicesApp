import React from 'react';
import { Link, BrowserRouter, NavLink } from 'react-router-dom';
import Cookies from 'js-cookie';

export default class Nav extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isAuth: this.props.auth,
            personalNumber: Cookies.get('currentOwner')
        };
        
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
                </ul>
            </div>;
        }
       
    }
}