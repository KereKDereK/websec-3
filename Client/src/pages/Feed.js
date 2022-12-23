import React from "react";
import Post from '../components/Post';
import { useContext } from 'react'
import { Context } from '../index';
function Feed() {
    const {user} = useContext(Context)
    console.log(user)
    return (
        
        <div>
            Feed
            <Post/>
        </div>
    )
}

export default Feed;