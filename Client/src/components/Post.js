import React from 'react';
import {Card, Col} from "react-bootstrap";
import Image from "react-bootstrap/Image";
import like from '../assets/like.png'
import post from '../assets/post.png'

function Post() {
    return (
        <Col md={3} className={"mt-3"}>
            <Card style={{width: 150, cursor: 'pointer'}} border={"light"}>
                <Image width={150} height={150} src={post.img}/>
                <div className="text-black-50 mt-1 d-flex justify-content-between align-items-center">
                    <div>user_name</div>
                    <div className="d-flex align-items-center">
                        <div>100</div>
                        <Image width={18} height={18} src={like}/>
                    </div>
                </div>
                <div>комментарий</div>
            </Card>
        </Col>
    )
}

export default Post;