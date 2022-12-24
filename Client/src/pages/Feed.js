import React, { useContext } from "react";
import Card_Post from "../components/Card_Post"
import axios from "axios"
import {useState, useEffect} from "react"
import { Context } from "..";
import { observer } from "mobx-react-lite";

const Feed = observer(()=> {
    axios.defaults.baseURL = 'https://localhost:5001';
    const [state, setState] = useState();
    const {posts} = useContext(Context)
    useEffect (() => {
        axios.get('/api/Post',{ withCredentials: true })
        .then(response => setState(response.data))

        // async function retrieveData() 
        // {
        //     const response = await axios.get('/api/Post',{ withCredentials: true })
        //     .then(
        //         (response) => 
        //         {
        //             setState(response)
        //             posts.setPost(response.data)
        //             console.log(state)
        //         }
        //     )
        //     return response
        // }
        // //posts.setPost(retrieveData())
        // retrieveData()
    }, [])

    
    return (
        <div>
            {state==undefined ? " " : state.map((x) => 
                <Card_Post key={x.id} resp={x}/>)
            }
        </div>
    )
})

export default Feed;