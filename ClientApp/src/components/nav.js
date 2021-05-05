import React from 'react';
import { Link, BrowserRouter, NavLink } from 'react-router-dom';

export default class Nav extends React.Component {
    render() {
        return <div>
            <Link to="/"><div className="nav-logo">���</div></Link>
            <ul className="nav flex-column">
                <li className="nav-item">
                    <NavLink exact to="/personalNumber" className="link" activeClassName="active">������ ������� ����</NavLink>
                </li>
                <li className="nav-item">
                    <NavLink className="link" to="/charges" activeClassName="active">����������</NavLink>
                </li>
                <li className="nav-item">
                    <NavLink className="link" to="/calc" activeClassName="active">�����������</NavLink>
                </li>
                <li className="nav-item">
                    <NavLink className="link" to="/companys" activeClassName="active">������������� �����������</NavLink>
                </li>
            </ul>
        </div>;
    }
}