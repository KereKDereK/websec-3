import React from "react";
import { redirect, useSearchParams } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import axios from "axios"
import { useContext } from 'react'
import { Context } from '../index';
import {FEED_ROUTE } from "../utils/consts";
import { observer } from 'mobx-react-lite';
import Cookies from "universal-cookie"

const cookies = new Cookies();


function Wait () {
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
      }, { withCredentials: true })
      .then(function (response) {
        console.log(response);
        if (response.data == 1)
        {
          user.setIsAuth(true)
        }
        user.isAuth?
        <div>                
        
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

export default observer(Wait);