import React from "react";
import { Container, Button, Form, InputGroup } from "react-bootstrap";
import {useState, useEffect} from "react"
import axios from 'axios'
import { USER_ROUTE } from "../utils/consts";

function Subs() {
    const [state, setState] = useState();
    const [data, setData] = useState()
    const [clone, setClone] = useState()
    const [flag, setFlag] = useState(true)

    useEffect(() => {axios.defaults.baseURL = 'https://localhost:5001'
    axios.get("/api/User", {withCredentials: true}).then(response => setData(response.data))}, [])
    

    const changeHandler = event => {
        setState(event.target.value)
        console.log(state)
    }

    const clickHandler = () => {
        setClone(data.filter(x => x.userName.toLowerCase().includes(state.toLowerCase())))
        setFlag(false)
    }

    return (
        
        <Container>
            <InputGroup className="mb-3" value={state}
                onChange ={changeHandler}>
                <Form.Control
                placeholder="the user you are looking for"
                aria-label="the user you are looking for"
                aria-describedby="basic-addon2"
                
                />
                {data == undefined ? " " : console.log(data)}
                <Button variant="outline-secondary" id="button-addon2" onClick={clickHandler}>
                Search
                </Button>
            </InputGroup>
                {clone==undefined ||  flag == true ? " " : clone.map((x) => 
                    <div key={x.id}>
                        <a className="text-dark mx-auto" href={USER_ROUTE + "/" + x.id} >
                        <span style={{fontSize:"35px"}}>{x === undefined ? " " : x.userName}</span>
                        </a>
                    </div>
                    )
                }
        </Container>
    )
}

export default Subs;