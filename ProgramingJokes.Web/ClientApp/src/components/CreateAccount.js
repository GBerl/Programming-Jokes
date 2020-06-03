import React from 'react'
import SignupForm from '../pages/SignupForm'
import axios from 'axios'
import { produce } from 'immer'

class CreateAccount extends React.Component {
    state = {
        email: '',
        name: '',
        password: ''

    }

    textChange = e => {
        const nextState = produce(this.state, draft => {
            draft[e.target.name] = e.target.value
        })

        this.setState(nextState)
    }

    onFormSubmit = async e => {
        e.preventDefault()
        await axios.post('api/account/adduser', this.state)
        this.props.history.push('/login')
    }

    render() {
        return (
            <div>
                <SignupForm
                    user={this.state.user}
                    onFormSubmit={this.onFormSubmit}
                    emailChange={this.textChange}
                    passwordChange={this.textChange}
                    nameChange={this.textChange}
                />
            </div>
        )
    }
}

export default CreateAccount