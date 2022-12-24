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
import { Context } from "..";
import { useContext } from "react";
import Card_Comment from "./Card_Comment_comp";


export default function Card_Post(resp) {
  console.log(resp.resp.image)
  return (
    <MDBContainer className="py-5">
      <MDBCard style={{ maxWidth: "42rem" }}>
        <MDBCardBody className="mx-auto">
          <div className="d-flex mb-3">
            <div>
              <a href="#!" className="text-dark mb-0">
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
                <span>{resp.resp.likes_Count}</span>
              </a>
            </div>
            <div>
              <a className="text-muted">
              {resp.resp.comments.length}
              </a>
            </div>
          </div>
          <div className="d-flex justify-content-between text-center border-top border-bottom mb-4">
            <MDBBtn size="lg" rippleColor="dark" color="link">
              <MDBIcon fas icon="thumbs-up" className="me-2" /> Like
            </MDBBtn>
            <MDBBtn size="lg" rippleColor="dark" color="link">
              <MDBIcon fas icon="comment-alt" className="me-2" /> Comments
            </MDBBtn>
          </div>
          <div className="d-flex mb-3">
            <MDBTextArea
              label="Message"
              id="textAreaExample"
              rows={2}
              wrapperClass="w-100"
            />
          </div>

          {resp.resp.comments.map((x) => <Card_Comment key={x.id} props={x}/>)}



        </MDBCardBody>
      </MDBCard>
    </MDBContainer>
  );
}
