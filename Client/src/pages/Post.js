import React from "react";
import {Form} from "react-bootstrap"
import {useState, useEffect} from 'react'
import axios from 'axios'
import { Button } from "react-bootstrap";
import { MDBTextArea } from "mdb-react-ui-kit";
import Cookies from "universal-cookie"
import { USER_ROUTE } from "../utils/consts";

function Post() {
    const [file, setFile] = useState();
    const [text, setText] = useState('');
    const [userId, setUserId] = useState(1);

    useEffect(() => {
        axios.defaults.baseURL = 'https://localhost:5001';
        axios.get('/api/User/1',{ withCredentials: true })
        .then(response => setUserId(response.data));
    }, [])

    const handleChange = event => {
        setText(event.target.value);
        console.log(text)
        console.log(file)
      };
    const handleClick = () => {


        async function receiveData()
        {
            
        }

        if (file.type != "image/jpeg")
            console.log("Invalid data")

        axios.post("/api/Post", {
            userId: userId,
            text: text,
            datetime: file.lastModifiedDate,
            likes_Count: 1
        }, { withCredentials: true }).then(() => {
            const formData = new FormData();
            formData.append("image", file);
            axios.post("/api/Image?post_id=" + userId, formData, 
            {headers: {'Content-Type': "multipart/form-data"}, withCredentials: true }).then(() => 
            window.location.href = USER_ROUTE + "/" + userId)
        })

        receiveData()
        setTimeout(function() {
            setText("Успешно")
        }, 2);

        
    };
    
    return (
        <Form>
            <MDBTextArea
              id="textAreaExample"
              rows={2}
              wrapperClass="w-100"
              value = {text}
              onChange = {handleChange}
              type="text"
            />
            <Form.Group controlId="formFileLg" className="mb-3" value={file} onChange= {(e) => setFile(e.target.files[0])}>
                <Form.Label>Please, select one picture (.jpeg)</Form.Label>
                <Form.Control type="file" size="lg"/>
            </Form.Group>
            <Button color="danger" className="mt-auto" onClick={handleClick}>
               Upload
            </Button> 
        </Form>
    )
}

export default Post;