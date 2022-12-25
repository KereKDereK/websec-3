import Card_Post from "../components/Card_Post"
import axios from "axios"
import {useState, useEffect} from "react"
import { observer } from "mobx-react-lite";

const Feed = observer(()=> {
    axios.defaults.baseURL = 'https://localhost:5001';
    const [state, setState] = useState();
    const [userId, setUserId] = useState(1)
    useEffect (() => {
        axios.get('/api/User/1',{ withCredentials: true })
        .then(response => setUserId(response.data));
        axios.get('/api/Post?id=' + userId,{ withCredentials: true })
        .then(response => setState(response.data))
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