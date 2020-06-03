import React from 'react'
import LoginForm from '../pages/LoginForm'
import axios from 'axios'
import { JokeContext } from '../JokeContextComponent'
import { produce } from 'immer'

class Login extends React.Component {
    state = {
        email: '',
        password: ''
    }

    textChange = e => {
        const nextState = produce(this.state, draft => {
            draft[e.target.name] = e.target.value
        })

        this.setState(nextState)
    }

    onFormSubmit = async (e, value) => {
        e.preventDefault()
        const { data } = await axios.post('api/account/login', this.state)
        value.setUser(data)
        this.props.history.push('/')
    }

    render() {
        return (
            <div>
                <JokeContext.Consumer>
                    {value => {
                        return (
                            <LoginForm
                                user={this.state.user}
                                onFormSubmit={e => this.onFormSubmit(e, value)}
                                emailChange={this.textChange}
                                passwordChange={this.textChange}
                            />)
                    }}
                </JokeContext.Consumer>
            </div>

        )
    }
}

export default Login