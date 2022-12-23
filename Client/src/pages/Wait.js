import React from "react";
import { redirect, useSearchParams } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import axios from "axios"
import { useContext } from 'react'
import { Context } from '../index';
import {FEED_ROUTE } from "../utils/consts";
import  Button  from "react-bootstrap/Button";

function Wait() {
    const {user} = useContext(Context)
    axios.defaults.baseURL = 'https://localhost:5001';
    let [searchParams, setSearchParams] = useSearchParams()
    searchParams.get("code")
      console.log(user)
    return (
      <div>
        {     
        axios.post('/api/User', {
        "code": Number(searchParams.get('code'))
      })
      .then(function (response) {
        console.log(response);
        if (response.data == 1)
        {
          user.setIsAuth(true)
        }
        user.isAuth?
        <div>                
        ${window.location.href = FEED_ROUTE}
      </div>
          :
          <div className="d-flex justify-content-center">
          <Spinner animation="border"/>
        </div>
      })
      }
      </div>
    )
}

export default Wait;