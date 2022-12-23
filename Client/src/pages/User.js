import React from "react";
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import axios from "axios"
import {useState, useEffect} from "react"

function User() {
    const id = window.location.href.toString().split("/")[4]
    axios.defaults.baseURL = 'https://localhost:5001';
    const [state, setState] = useState();
    useEffect (() => {
        async function retrieveData() 
        {
            const response = await axios.get('/api/User/'+id,{ withCredentials: true })
            .then((response) => setState(response))
            return response
        }
        retrieveData()
    }, [])

    console.log(state)
    return (
        <Form>
        <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
            <Form.Label column sm="2">
            Пышки и мышьки
            </Form.Label>
            <Col sm="10">
            {state==undefined ? " " : state.data.userName}
            <Form.Control plaintext readOnly />
            </Col>
        </Form.Group>
    </Form>
    )
}

export default User;