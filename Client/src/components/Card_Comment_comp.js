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

export default function Card_Comment(props){
    //console.log(props)
    return(
      <div className="d-flex mt-3">
        <div>
          <div className="bg-light rounded-3 px-3 py-1">
            <a href={"/User/" + props.props.userId} className="text-dark mb-0">
              <strong>{props.props.name}</strong>
            </a>
            <a className="text-muted d-block">
              <small>
                {props.props.text}
              </small>
            </a>
          </div>
        </div>
      </div>
    );
}