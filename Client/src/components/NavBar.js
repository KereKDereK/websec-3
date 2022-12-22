import React from "react";
import Nav  from "react-bootstrap/Nav";
import Navbar  from "react-bootstrap/Navbar";
import Container from "react-bootstrap/Container";
import { useContext } from 'react'
import { Context } from '../index';
import { HOME_ROUTE,AUTH_ROUTE, REG_ROUTE } from "../utils/consts";
import User from "../pages/User";
import  Button  from "react-bootstrap/Button";

export function NavBar() {
    const {user} = useContext(Context)
    return (
      <Navbar bg="dark" variant="dark">
          <Navbar.Brand href={HOME_ROUTE}>Navbar</Navbar.Brand>
          {user.isAuth ?
            <Nav className="ml-auto">
              <Button variant={"outline-light"}>XYY</Button>
            </Nav>
            :
            <Nav className="ml-auto">
              <Button variant={"outline-light"}>Log in</Button>
              <Button variant={"outline-light"}>Register</Button>
            </Nav>
          }
      </Navbar>
    )
}

export default NavBar;