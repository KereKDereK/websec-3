import React from "react";
import Nav  from "react-bootstrap/Nav";
import Navbar  from "react-bootstrap/Navbar";
import Container from "react-bootstrap/Container";
import { HOME_ROUTE,AUTH_ROUTE, REG_ROUTE, USER_ROUTE, FEED_ROUTE, SUB_ROUTE } from "../utils/consts";
import  {Button, Dropdown, DropdownButton}  from "react-bootstrap";
import {observer} from "mobx-react-lite";
import { useState, useEffect } from 'react'
import { Context } from '../index';
import Cookies from "universal-cookie"
import axios from 'axios'

const cookies = new Cookies();

function NavBar () {

  const [auth, setAuth] = useState(false)
  const [userId, setUserId] = useState(1)

  useEffect(() => {
    axios.defaults.baseURL = 'https://localhost:5001';
    if (cookies.get("auth_token"))
      setAuth(true)
    axios.get('/api/User/1',{ withCredentials: true })
    .then(response => setUserId(response.data));
  }, [])
  
  const removeCookies = () => {
    cookies.remove('auth_token', {path: '/', domain: "localhost"})
    cookies.remove('id', {path: '/', domain: "localhost"})
  }

    return (
      <Navbar bg="dark" variant="dark">
        <Container>          
          <Navbar.Brand>StoGramm</Navbar.Brand>
            {auth?
              <Nav className="ml-auto" style={{color : 'white'}}>
              <DropdownButton id="dropdown-basic-button" title="Menu">
                <Dropdown.Item  variant={"outline-light"} className="mw-100" href={USER_ROUTE + "/" + userId}>Профиль</Dropdown.Item>
                <Dropdown.Item variant={"outline-light"} className="mw-100" href={FEED_ROUTE}>Лента</Dropdown.Item>
                <Dropdown.Item variant={"outline-light"} className="mw-100" href={SUB_ROUTE}>Поиск</Dropdown.Item>
                <Dropdown.Item variant={"outline-light"} className="mw-100" onClick={removeCookies} href={HOME_ROUTE}>Выход</Dropdown.Item>
              </DropdownButton>
              </Nav>
              :
              <Nav className="ml-auto">
                <a href="https://oauth.yandex.ru/authorize?response_type=code&client_id=9ad6adf4562c48399e6da3cc61272b92">
                  <Button variant={"outline-light"}style={{color : 'white'}}>
                    Войти с помощью Яндекс
                  </Button>
                </a> 
              </Nav>
            }</Container>
      </Navbar>
    )
}

export default observer(NavBar);