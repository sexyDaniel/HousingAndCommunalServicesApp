<<<<<<< HEAD
import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
=======
import ReactDOM from 'react-dom';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Nav from './components/nav.js';
import Home from './components/Home.js';
import Charges from './components/charges.js';
import Calc from './components/calc.js';
import PersonalNumber from './components/personalNumber.js';
import Companys from './components/companys.js';
>>>>>>> 79b540f... GetChargesByDate and ChargeId-Migration

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}
