import React from "react";
import Nav  from "react-bootstrap/Nav";
import Navbar  from "react-bootstrap/Navbar";
import Container from "react-bootstrap/Container";
import { useContext } from 'react'
import { Context } from '../index';
import { HOME_ROUTE,AUTH_ROUTE, REG_ROUTE } from "../utils/consts";
import  Button  from "react-bootstrap/Button";
import {observer} from "mobx-react-lite";

const NavBar = observer( () => {
    const {user} = useContext(Context)
    return (
      <Navbar bg="dark" variant="dark">
        <Container>          
          <Navbar.Brand href={HOME_ROUTE}>StoGramm</Navbar.Brand>
            {user.isAuth?
              <Nav className="ml-auto" style={{color : 'white'}}>
                <Button variant={"outline-light"}>XYY</Button>
              </Nav>
              :
              <Nav className="ml-auto">
                <a href="https://oauth.yandex.ru/authorize?response_type=code&client_id=9ad6adf4562c48399e6da3cc61272b92">
                  <Button variant={"outline-light"}style={{color : 'white'}} onClick={() => user.setIsAuth(true)}>
                    Войти с помощью яндекса
                  </Button>
                </a> 
              </Nav>
            }</Container>
      </Navbar>
    )
})

export default NavBar;