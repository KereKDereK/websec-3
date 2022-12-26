import React from "react";
import { redirect, useSearchParams } from "react-router-dom";
import Button from 'react-bootstrap/Button';
import axios from "axios"
import { useContext, useEffect , useState} from 'react'
import { Context } from '../index';
import {FEED_ROUTE, USER_ROUTE } from "../utils/consts";
import { observer } from 'mobx-react-lite';
import Cookies from "universal-cookie"
import { Container } from "react-bootstrap";

const cookies = new Cookies();

function Wait () {
    axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
    let [searchParams, setSearchParams] = useSearchParams()
    const [userId, setUserId] = useState();
    useEffect(()=>{
      axios.defaults.baseURL = 'https://localhost:5001';
      axios.post('/api/User', {
        code: Number(searchParams.get("code"))
      }, {withCredentials: true})
      .then( response => 
        {
          window.location.href = FEED_ROUTE
        })
    }, [])
    return (
      <Container className="mx-auto">
            <div style={{display: 'flex', justifyContent: 'center'}}>
            Подождите, идет авторизация
            </div>
      </Container>
    )
}

export default observer(Wait);