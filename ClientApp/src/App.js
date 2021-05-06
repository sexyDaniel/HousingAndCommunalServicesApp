import ReactDOM from 'react-dom';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Cookies from 'js-cookie';
import Nav from './components/nav.js';
import Home from './components/Home.js';
import Charges from './components/charges.js';
import Calc from './components/calc.js';
import PersonalNumber from './components/personalNumber.js';
import Companys from './components/companys.js';
import AdminAutn from './components/adminAuth.js';

export default class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            tariff: "",
            volume: "",
            res: "",
            monthCalc: "",
            resCalcMonth: "",
            yearCalc: "",
            resCalcYear: "",
            startDate: "",
            finishDate: "",
            resPeriod: "",
            owner:""
        };
        this.isAuth = Cookies.get('currentOwner')
    }

    render() {
        console.log(this.isAuth)
        return <Router>
            <div className="sidebar">
                <Nav auth={this.isAuth}/>
            </div>
            <div className="main">
                <Route exact path="/" component={Home} />
                <Route path="/personalNumber" component={PersonalNumber} />
                <Route path="/charges" component={Charges} />
                <Route path="/calc" component={() => <Calc values={this.state} />} />
                <Route path="/companys" component={Companys} />
                <Route path="/admin/auth" component={AdminAutn} />
            </div>
        </Router>
    }
}