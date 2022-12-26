import { Routes, Route } from 'react-router-dom';
import './App.css';
import {authRoutes, publicRoutes} from './routes'
import { useContext, useState, useEffect } from 'react'
import { Context } from './index';
import { observer } from 'mobx-react-lite';
import NavBar from './components/NavBar'
import axios from 'axios';

function App () {
  axios.defaults.baseURL = 'https://localhost:5001';
  const [userId, setUserId] = useState(false);
  useEffect(() => 
  {
    {
    axios.get('/api/User/1', {withCredentials: true}).then(response =>
      {
        setUserId(true); console.log(userId)
      }
    ).catch(function (error) 
      {
        console.log(error.response.status);
      })
    }
  }
    , [])
  return (
    <div>
    <NavBar/>
      <Routes>
            
            {userId && authRoutes.map(({path, Component}) =>
                <Route key = {path} path={path} element={<Component/>}/>
            )}
            {publicRoutes.map(({path, Component}) =>
                <Route key = {path} path={path} element={<Component/>}/>
            )}
      </Routes>
    </div>
  );
}

export default observer(App);
