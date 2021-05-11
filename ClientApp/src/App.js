import ReactDOM from 'react-dom';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Cookies from 'js-cookie';
import Nav from './components/nav.js';
import AdminNav from './components/adminNav.js'
import Home from './components/Home.js';
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
            owner: "",
            startChargeDate: "",
            finishChargeDate:""
        };
        this.isAuth = Cookies.get('currentOwner')
        this.isAdmin = Cookies.get('Login')
    }
    async componentDidMount() {
        var toDay = new Date()
        var daysCount = 32 - new Date(toDay.getFullYear(), toDay.getMonth(), 32).getDate();
        var month = toDay.getMonth() + 1
        var start = toDay.getFullYear() + '-' + 0 + month + '-' + '01'
        var finish = toDay.getFullYear() + '-' + 0 + month + '-' + daysCount
        this.setState({ startChargeDate: start })
        this.setState({ finishChargeDate: finish })
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
                    <Route path="/charges" component={() => <Charges values={this.state} />} />
                    <Route path="/calc" component={() => <Calc values={this.state} />} />
                    <Route path="/companys" component={Companys} />
                    <Route path="/admin/auth" component={AdminAutn} />
                    <Route path="/admin/addCharges" component={DownloadCharges} />
                </div>
            </Router>
        }
    }
}