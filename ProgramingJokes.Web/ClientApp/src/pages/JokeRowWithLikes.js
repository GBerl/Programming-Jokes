import React from 'react'


class JokeRow extends React.Component {
    render() {
        const { setup, punchline, userLikedJokes } = this.props.joke
        const likes = userLikedJokes.filter(u=>u.liked === true).length
        const dislikes = userLikedJokes.filter(u=>u.liked !== true).length

        return (
            <div>

                <div className="col-md-8 col-md-offset-2 well">
                    <p>{setup}</p>
                    <p>{punchline}</p>
                    <p>Likes {likes}</p>
                    <p>Dislikes {dislikes}</p>

                </div>

            </div>
        )
    }
}

export default JokeRow