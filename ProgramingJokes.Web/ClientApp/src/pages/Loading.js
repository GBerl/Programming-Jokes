import React from "react";
import ReactLoading from "react-loading";
import "bootstrap/dist/css/bootstrap.css";

const Loading = () => {
    return (
        <div className="d-flex justify-content-center" const style={{ position: "fixed", top: "50%", left: "50%", transform: "translate(-50%, -50%)" }}>
            <ReactLoading type={"bars"} color={"black"} />
        </div>
    )
}

export default Loading