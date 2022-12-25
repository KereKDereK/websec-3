import React from "react";
import {
  MDBBtn,
  MDBCard,
  MDBCardBody,
  MDBContainer,
  MDBIcon,
  MDBRipple,
  MDBTextArea,
} from "mdb-react-ui-kit";
import Card_Comment from "./Card_Comment_comp";
import {useState, useEffect} from 'react'
import axios from 'axios'
import {Button} from "react-bootstrap"

export default function Card_Post(resp) {

  const [message, setMessage] = useState('');
  const [likes, setLikes] = useState(resp.resp.likes_Count);
  const [state, setState] = useState(false);

  const handleChange = event => {
    setMessage(event.target.value);
  };

  const handleLike = event => {
    
    if (state == false)
    {
      setLikes(likes + 1)
      axios.defaults.baseURL = 'https://localhost:5001';
      axios.post("/api/Like", {
      postId: resp.resp.id
      }, { withCredentials: true })
      setState(true)
    }
    else
    {
      setLikes(likes - 1)
      axios.defaults.baseURL = 'https://localhost:5001';
      axios.delete("/api/Like/" + resp.resp.id, { withCredentials: true })
      setState(false)
    }
  };

  const handleClick = () => {
    if (message.length >= 1)
    {
      axios.defaults.baseURL = 'https://localhost:5001';
      axios.post("/api/Comment", {
        text: message,
        userId: 1,
        postId: resp.resp.id
      }, { withCredentials: true })
    }
    window.location.reload(false);
  }

  return (
    <MDBContainer className="py-5">
      <MDBCard style={{ maxWidth: "42rem" }}>
        <MDBCardBody className="mb-auto">
          <div className="d-flex ml-2">
            <div>
              <a href={"/User/" + resp.resp.userId} className="text-dark mb-0">
                <strong>{resp.resp.name}</strong>
              </a>
              <a
                href="#!"
                className="text-muted d-block"
                style={{ marginTop: "-6px" }}
              >
              </a>
            </div>
          </div>
          <div>
            <p>
              {resp.resp.text}
            </p>
          </div>
        </MDBCardBody>
        <MDBRipple
          className="bg-image hover-overlay ripple rounded-0"
          rippleTag="div"
          rippleColor="light"
        >
          <img
            src={resp.resp.image === null || "" ? process.env.PUBLIC_URL + "/images/bad.jpg" : process.env.PUBLIC_URL + "/images/" + resp.resp.image.imageUrl}
            className="w-100"
          />
          <a >
            <div
              className="mask"
              style={{ backgroundColor: "rgba(251, 251, 251, 0.2)" }}
            ></div>
          </a>
        </MDBRipple>
        <MDBCardBody>
          <div className="d-flex justify-content-between mb-3">
            <div>
              <a>
                <MDBIcon
                  fas
                  icon="thumbs-up"
                  color="primary"
                  className="me-1"
                />
                <MDBIcon fas icon="heart" color="danger" className="me-1" />
                <span>{likes}</span>
              </a>
            </div>
            <div>
              <a className="text-muted">
              {resp.resp.comments.length}
              </a>
            </div>
          </div>
          <div className="d-flex justify-content-between text-center border-top border-bottom mb-4">
            <Button size="lg"  variant="danger" className="mr-auto" onClick={handleLike}>
              Like
            </Button> 
          </div>
          <div className="d-flex mb-3">
            <MDBTextArea
              id="textAreaExample"
              rows={2}
              wrapperClass="w-100"
              value = {message}
              onChange = {handleChange}
              type="text"
            />
            
          </div>
          <Button  className="mb-auto" onClick={handleClick}>
              Send
            </Button> 

          {resp.resp.comments.map((x) => <Card_Comment key={x.id} props={x}/>)}



        </MDBCardBody>
      </MDBCard>
    </MDBContainer>
  );
}
