import { Routes, Route } from 'react-router-dom';
import './App.css';
import {authRoutes, publicRoutes} from './routes'

function App() {
  const isAuth = true
  return (
    <div>
      <Routes>
            {isAuth && authRoutes.map(({path, Component}) =>
                <Route key = {path} path={path} element={<Component/>}/>
            )}
            {publicRoutes.map(({path, Component}) =>
                <Route key = {path} path={path} element={<Component/>}/>
            )}
      </Routes>
    </div>
  );
}

export default App;
