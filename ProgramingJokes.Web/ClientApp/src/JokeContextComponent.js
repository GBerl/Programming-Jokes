import React from 'react'
import axios from 'axios'

const JokeContext = React.createContext()

class JokeContextComponent extends React.Component {
    state = {
        user: ''

    }

    componentDidMount = async () => {
        const { data } = await axios.get('/api/account/getuser');
        this.setUser(data);
    }

    setUser = async e => {
        this.setState({ user: e })
    }


    render() {
        const value = {
            user: this.state.user,
            setUser: this.setUser,
        }
        return (
            <JokeContext.Provider value={value}>
                {this.props.children}
            </JokeContext.Provider>
        )
    }

}

export {JokeContext, JokeContextComponent }
