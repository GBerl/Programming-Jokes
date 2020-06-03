import React from 'react'
import axios from 'axios'
import JokeRowWithLikes from '../pages/JokeRowWithLikes'
import Loading from '../pages/Loading';


class AllJokes extends React.Component {
    state = {
        jokes: [], 
        loading:true

    }

    componentDidMount = async () => {
        const { data } = await axios.get('api/joke/getalljokes')
        this.setState({ jokes: data, loading:false})
    }

    render() {
        return (
            <div>
                {!!this.state.loading && <Loading/>}
                {!this.state.loading && this.state.jokes.map(joke => <JokeRowWithLikes key={joke.Id} joke={joke} />)}
            </div>
        );
    }
}
export default AllJokes