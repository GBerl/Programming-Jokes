import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home'
import Login from './components/Login'
import { JokeContextComponent} from './JokeContextComponent'
import CreateAccount from './components/CreateAccount';
import Logout from './components/Logout'
import AllJokes from './components/AllJokes'

export default class App extends Component {
    displayName = App.name

    render() {
        return (
            <JokeContextComponent>
                <Layout>
                    <Route exact path='/' component={Home} />
                    <Route exact path='/login' component={Login} />
                    <Route exact path='/createaccount' component={CreateAccount} />
                    <Route exact path='/logout' component={Logout} />
                    <Route exact path='/alljokes' component={AllJokes} />
                </Layout>
            </JokeContextComponent>
        );
    }
}
