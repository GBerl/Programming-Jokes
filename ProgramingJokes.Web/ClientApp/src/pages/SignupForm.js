import React from 'react'


const SignupForm = (props) => {

    const { onFormSubmit, emailChange, passwordChange, nameChange}=props

    return (
        <div className="col-md-4 col-md-offset-4 well">
            <form onSubmit={onFormSubmit}>
                <h4>Create Account</h4>
                <div className="row">
                    <input type="text" placeholder="Name" name='name' className="form-control" onChange={nameChange} />
                </div>
                <div className="row" style={{ marginTop: 15 }}>
                    <input type="email" placeholder="Email" name='email' className="form-control" onChange={emailChange}/>
                </div>
                <div className="row" style={{ marginTop: 15 }}>
                    <input type="password" placeholder="Password" name='password' className="form-control" onChange={passwordChange} />
                </div>
                <div className="row" style={{ marginTop: 15 }}>
                    <button className="btn btn-primary">Create Account</button>
                </div>
            </form>
        </div>
    )
}

export default SignupForm