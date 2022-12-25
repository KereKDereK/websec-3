import Card_Post from "../components/Card_Post"
import axios from "axios"
import {useState, useEffect} from "react"
import { observer } from "mobx-react-lite";
import {
    MDBBtn,
    MDBCard,
    MDBCardBody,
    MDBContainer,
    MDBIcon,
    MDBRipple,
    MDBTextArea,
  } from "mdb-react-ui-kit";
import { Col, Container, Row, Button } from "react-bootstrap";
import Cookies from "universal-cookie"

const Feed = observer(()=> {
    const id = window.location.href.toString().split("/")[4]
    axios.defaults.baseURL = 'https://localhost:5001';
    const [userId, setUserId] = useState(1);
    const [state, setState] = useState();
    const [statesub, setStateSub] = useState();
    useEffect (() => {
        axios.get('/api/User/'+id,{ withCredentials: true })
        .then(response => setUserId(response.data));
        axios.get('/api/Post/'+id,{ withCredentials: true })
        .then(response => setState(response.data));
        axios.get('/api/Subscribers/' + id,{ withCredentials: true })
        .then(response => setStateSub(response.data));
        console.log(userId)
    }, [])

const clickHandlerSub = () =>
{
    axios.post('/api/Subscribers', {
        userId: userId,
        secondUserId: id
    },{ withCredentials: true })
    setTimeout(function() {
        window.location.reload(false);
    }, 500);
}

const clickHandlerUnsub = () =>
{
    axios.delete('/api/Subscribers/' + id ,{ withCredentials: true })
    setTimeout(function() {
        window.location.reload(false);
    }, 500);
}

    
    return (
        
        <div>
        {id == userId ?
        <div className="d-grid">
        <div fontSize="1px">                                                    .</div>
            <Container fluid="md">
            <Row>
            <Col sm={10}>
            <a className="text-dark mx-auto">
                <span style={{fontSize:"35px"}}>{state === undefined || state[0] == undefined? "Создайте ваш первый пост=\>" : state[0].name}</span>
            </a>
            </Col>
            <Col sm={1}>
            <Button color="danger" className="mt-auto rounded-circle" style={{fontSize:"17px"}} href="/Post">
              <MDBIcon fas icon="thumbs-up" className="ml-2" /> +  
            </Button> 
            </Col>
            </Row>
            </Container>
        </div>
        :
        <div className="d-grid">
        <div fontSize="1px">                                                    .</div>
            <Container fluid="md">
            <Row>
            <Col sm={10}>
            <a className="text-dark mx-auto">
                <span style={{fontSize:"35px"}}>{state === undefined || state[0] == undefined ? " " : state[0].name}</span>
            </a>
            </Col>
            {statesub == undefined || statesub.userId == userId ? " " :
            <Col sm={1}>
            <Button color="danger" className="mt-auto" onClick={clickHandlerSub}>
              <MDBIcon fas icon="thumbs-up" className="ml-2"/> Subscribe   
            </Button> 
            </Col>
            }
            {statesub == undefined || statesub.userId != userId ? " " :
            <Col sm={1}>
            <Button color="danger" className="mt-auto" onClick={clickHandlerUnsub}>
              <MDBIcon fas icon="thumbs-up" className="ml-2"/> Unsubscribe  
            </Button> 
            </Col>
            }

            </Row>
            </Container>
        </div>
        }
            {state==undefined ? " " : state.map((x) => 
                <Card_Post key={x.id} resp={x}/>)
            }
        </div>
    )
})

export default Feed;