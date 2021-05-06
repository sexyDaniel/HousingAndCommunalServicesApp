import ReactDOM from 'react-dom';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Cookies from 'js-cookie';
import Nav from './components/nav.js';
import AdminNav from './components/adminNav.js'
import Home from './components/home.js';
import Charges from './components/charges.js';
import Calc from './components/calc.js';
import PersonalNumber from './components/personalNumber.js';
import Companys from './components/companys.js';
import AdminAutn from './components/adminAuth.js';
import DownloadCharges from './components/downloadCharges.js'

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
            owner: ""
        };
        this.isAuth = Cookies.get('currentOwner')
        this.isAdmin = Cookies.get('Login')
    }

    render() {
        console.log(this.isAuth)
        let isA = false
        if (this.isAdmin) {
            isA = (this.isAdmin.localeCompare("Admin12345") === 0)
        }
        if (isA) {
            return <Router>
                <div className="sidebar">
                    <AdminNav />
                </div>
                <div className="main">
                    <Route exact path="/" component={Home} />
                    <Route path="/admin/auth" component={AdminAutn} />
                    <Route path="/admin/addCharges" component={DownloadCharges} />
                </div>
            </Router>
        } else {
            return <Router>
                <div className="sidebar">
                    <Nav auth={this.isAuth} />
                </div>
                <div className="main">
                    <Route exact path="/" component={Home} />
                    <Route path="/personalNumber" component={PersonalNumber} />
                    <Route path="/charges" component={Charges} />
                    <Route path="/calc" component={() => <Calc values={this.state} />} />
                    <Route path="/companys" component={Companys} />
                    <Route path="/admin/auth" component={AdminAutn} />
                    <Route path="/admin/addCharges" component={DownloadCharges} />
                </div>
            </Router>
        }
    }
}