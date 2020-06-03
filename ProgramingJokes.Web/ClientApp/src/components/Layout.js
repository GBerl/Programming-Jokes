import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import { JokeContext } from '../JokeContextComponent'

export class Layout extends Component {
    render() {
        return (
            <div>
                return (
                <div>
                    <JokeContext.Consumer>
                        {value => {
                            return (

                                <nav className="navbar navbar-inverse navbar-fixed-top">
                                    <div className="container">
                                        <div className="navbar-header">
                                            <button type="button" className="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                                                <span className="sr-only">Toggle navigation</span>
                                                <span className="icon-bar"></span>
                                                <span className="icon-bar"></span>
                                                <span className="icon-bar"></span>
                                            </button>

                                        </div>

                                        <div className="navbar-collapse collapse">
                                            <ul className="nav navbar-nav">
                                                < li ><Link to={`/`}>Random Jokes</Link></li>
                                                <li ><Link to={`/alljokes`}>All Jokes</Link></li>
                                                {!value.user && < li > <Link to={`/login`}>Login</Link></li>}
                                                {!value.user && < li > <Link to={`/createaccount`}>Create Account</Link></li>}
                                                {!!value.user && < li > <Link to={`/logout`}>Logout</Link></li>}

                                            </ul>
                                        </div>

                                    </div>
                                </nav>

                            )
                        }}
                    </JokeContext.Consumer> </div>

                <div className="container" style={{ marginTop: 55 }}>
                    {this.props.children}
                </div>

            </div>


        )
    }
}

