import { Routes, Route } from 'react-router-dom';
import './App.css';
import {authRoutes, publicRoutes} from './routes'
import { useContext } from 'react'
import { Context } from './index';
import { observer } from 'mobx-react-lite';
import NavBar from './components/NavBar'

function App () {
  const {user} = useContext(Context)
  return (
    
    <div>
    <NavBar/>
      <Routes>
            {user.isAuth && authRoutes.map(({path, Component}) =>
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
