import ReactDOM from 'react-dom';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Nav from './components/nav.js';
import Home from './components/Home.js';
import Charges from './components/charges.js';
import Calc from './components/calc.js';
import PersonalNumber from './components/personalNumber.js';
import Companys from './components/companys.js';

export default class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            tariff: "",
            volume: "",
            res: ""
        };
        this.press = this.press.bind(this);
        this.count = 67
        this.onTariffChange = this.onTariffChange.bind(this)
        this.onVolumeChange = this.onVolumeChange.bind(this)
    }
    onTariffChange(e) {
        this.setState({ tariff: e.target.value });
    }
    onVolumeChange(e) {
        this.setState({ volume: e.target.value });
    }
    press() {
        var res = this.state.tariff * this.state.volume
        this.setState({ res: res });
    }
    render() {
        console.log(this.count)
        return <Router>
            <div className="sidebar">
                <Nav />
            </div>
            <div className="main">
                <Route exact path="/" component={Home} />
                <Route path="/personalNumber" component={PersonalNumber} />
                <Route path="/charges" component={Charges} />
                <Route path="/calc" component={() => <Calc values={this.state} />} />
                <Route path="/companys" component={Companys} />
            </div>
        </Router>
    }
}