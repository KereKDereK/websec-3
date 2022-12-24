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


export default function Card_Post() {
  return (
    <MDBContainer className="py-5">
      <MDBCard style={{ maxWidth: "42rem" }}>
        <MDBCardBody className="mx-auto">
          <div className="d-flex mb-3">
            <div>
              <a href="#!" className="text-dark mb-0">
                <strong>Имя запостившего</strong>
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
              Текст поста
            </p>
          </div>
        </MDBCardBody>
        <MDBRipple
          className="bg-image hover-overlay ripple rounded-0"
          rippleTag="div"
          rippleColor="light"
        >
          <img
            src="https://mdbcdn.b-cdn.net/img/new/standard/people/077.webp"
            className="w-100"
          />
          <a href="#!">
            <div
              className="mask"
              style={{ backgroundColor: "rgba(251, 251, 251, 0.2)" }}
            ></div>
          </a>
        </MDBRipple>
        <MDBCardBody>
          <div className="d-flex justify-content-between mb-3">
            <div>
              <a href="#!">
                <MDBIcon
                  fas
                  icon="thumbs-up"
                  color="primary"
                  className="me-1"
                />
                <MDBIcon fas icon="heart" color="danger" className="me-1" />
                <span>Кол-во лайков</span>
              </a>
            </div>
            <div>
              <a href="#!" className="text-muted">
                Кол-во комментов
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
          <div className="d-flex mb-3">
            <div>
              <div className="bg-light rounded-3 px-3 py-1">
                <a href="#!" className="text-dark mb-0">
                  <strong>Имя коментатора</strong>
                </a>
                <a href="#!" className="text-muted d-block">
                  <small>
                    комент
                  </small>
                </a>
              </div>
            </div>
          </div>
        </MDBCardBody>
      </MDBCard>
    </MDBContainer>
  );
}
