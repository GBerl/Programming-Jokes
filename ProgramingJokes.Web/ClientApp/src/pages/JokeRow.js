import React from 'react'
import { JokeContext } from '../JokeContextComponent'
import axios from 'axios';
import { produce } from 'immer'

class JokeRow extends React.Component {
    state = {
        userLiked: {
          
        },
          alreadyLiked: ''

    }


    getLike = async joke => {
        var id = joke.Id
        const { data } = await axios.get(`api/joke/getlike?id=${id}`)
        this.setState({ userLiked: data })
    }

    setTime = () => {
        setTimeout(()=>(this.setState({ alreadyLiked:true})) , 4000)

    }

  
    render() {
        const { setup, punchline, Id } = this.props.joke
        const { onLikeJoke, onDislikeJoke } = this.props
        return (
            <div>
                < JokeContext.Consumer >
                    {
                        value => {
                            { !!value.user && this.getLike(this.props.joke) }

                            return (

                                <div className="col-md-8 col-md-offset-2 well">
                                    <p>{setup}</p>
                                    <p>{punchline}</p>

                                    {!!value.user &&

                                        <div className='row'>
                                            <div>
                                                <button className='btn btn-primary'
                                                    disabled={this.state.userLiked.liked === true || this.state.alreadyLiked === true}
                                                    style={{ marginRight: 10, marginLeft: 10 }}
                                                onClick={() => { onLikeJoke(Id), this.setTime() }}
                                                  
                                                >Like</button>

                                            <button className='btn btn-danger'
                                                disabled={this.state.userLiked.liked === false || this.state.alreadyLiked === true}
                                                onClick={() => { onDislikeJoke(Id), this.setTime() }}
                                                >Dislike</button>
                                            </div>


                                        </div>
                                    }

                                </div>
                            )
                        }}
                </ JokeContext.Consumer>
            </div>
        )
    }
}

export default JokeRow