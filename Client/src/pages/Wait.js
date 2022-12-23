import React from "react";
import { useSearchParams } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import axios from "axios"

function Wait() {
    axios.defaults.baseURL = 'https://localhost:5001';
    let [searchParams, setSearchParams] = useSearchParams()
    searchParams.get("code")
    axios.post('/api/User', {
        "code": Number(searchParams.get('code'))
      })
      .then(function (response) {
        console.log(response);
      })
    return (
        <div className="d-flex justify-content-center">                
            <Spinner animation="border"/>
        </div>
    )
}

export default Wait;