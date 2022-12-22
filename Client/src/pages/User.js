import React from "react";
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';

function User() {
    return (
        <Form>
        <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
            <Form.Label column sm="2">
                Имя пользователя
            </Form.Label>
            <Col sm="10">
            <Form.Control plaintext readOnly defaultValue="ИВАН Иванов" />
            </Col>
        </Form.Group>
    </Form>
    )
}

export default User;