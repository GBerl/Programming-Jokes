import React from 'react'
import axios from 'axios'
import JokeRow from '../pages/JokeRow'
import Loading from '../pages/Loading'

class Home extends React.Component {
    state = {
        jokes: [],
        loading: true, 
        liked:''
    }

    componentDidMount = async () => {
        const { data } = await axios.get('api/joke/getjokes')
        this.setState({ jokes: data, loading: false })
    }

    onLikeJoke = async id => {
        this.setState({ liked: true })
        await axios.post(`api/joke/updatelike`, { id, liked: true })
       
    }
    onDislikeJoke = async id => {
        this.setState({ liked: true })
        await axios.post(`api/joke/updatelike`, { id, liked: false })
        
    }

    render() {
        return (
            <div>
                {!!this.state.loading && <Loading />}
                {!this.state.loading &&
                    this.state.jokes.map(joke =>
                        <JokeRow key={joke.Id} joke={joke}
                            onLikeJoke={this.onLikeJoke}
                            onDislikeJoke={this.onDislikeJoke}
                        />)}
            </div>
        );
    }
}
export default Home