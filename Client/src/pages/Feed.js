import React from "react";
import Card_Post from "../components/Card_Post"
import axios from "axios"
import {useState, useEffect} from "react"

function Feed() {
    const id = window.location.href.toString().split("/")[4]
    axios.defaults.baseURL = 'https://localhost:5001';
    const [state, setState] = useState();
    useEffect (() => {
        async function retrieveData() 
        {
            const response = await axios.get('/api/Post',{ withCredentials: true })
            .then((response) => setState(response))
            return response
        }
        retrieveData()
    }, [])
    console.log(state==undefined ? " " : state.data[0].text)
    return (
        <div>
            <Card_Post/>
        </div>
    )
}

export default Feed;