import React from "react";
import Post from '../components/Post';
import { useContext } from 'react'
import { Context } from '../index';
import {observer} from "mobx-react-lite";


function Feed () {
    const {user} = useContext(Context)
    console.log(user)
    return (
        <div>
            Feed
            <Post/>
        </div>
    )
}

export default observer(Feed);