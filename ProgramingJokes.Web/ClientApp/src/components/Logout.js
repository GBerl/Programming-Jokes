import React from 'react'
import axios from 'axios'
import { JokeContext } from '../JokeContextComponent'

class Logout extends React.Component {

    componentDidMount = async () => {
        axios.post('api/account/logout')

    }
    render() {
        return (
            <JokeContext.Consumer>
                {value => {
                    value.setUser('')
                    this.props.history.push('/login')
                }}
            </JokeContext.Consumer>
        )
    }
}
export default Logout