import React from 'react'


const LoginForm = (props) => {

    const { onFormSubmit, emailChange, passwordChange } = props
        return (
            <div className="col-md-4 col-md-offset-4 well">
                <form onSubmit={onFormSubmit}>
                    <h4>Login to your account</h4>
                    <div className="row" style={{ marginTop: 15 }}>
                        <input type="email" placeholder="Email" name='email' className="form-control" onChange={emailChange} />
                    </div>
                    <div className="row" style={{ marginTop: 15 }}>
                        <input type="password" placeholder="Password" name='password' className="form-control" onChange={passwordChange} />
                    </div>
                    <div className="row" style={{ marginTop: 15 }}>
                        <button className="btn btn-primary">Login</button>
                    </div>
                </form>
            </div>
  
    )
}

export default LoginForm