import React from "react";
import Spinner from 'react-bootstrap/Spinner';

function Wait() {
    return (
        <div class="d-flex justify-content-center">                
            <Spinner animation="border"/>
        </div>
    )
}

export default Wait;