import React from "react";
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import axios from "axios"

function User() {
    const id = window.location.href.toString().split("/")[4]
    console.log(id)
    axios.defaults.baseURL = 'https://localhost:5001';
    let name =axios.get('/api/User/'+id,{ withCredentials: true })
    console.log(name.then((data)=>data))
    return (
        <Form>
        <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
            <Form.Label column sm="2">
                {name}
            </Form.Label>
            <Col sm="10">
            <Form.Control plaintext readOnly defaultValue="ИВАН Иванов" />
            </Col>
        </Form.Group>
    </Form>
    )
}

export default User;