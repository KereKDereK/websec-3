import React, { createContext } from "react";
import ReactDOM from "react-dom/client";

import { BrowserRouter } from "react-router-dom";

import "./index.css";
import App from "./App";
import UserAcc from "./Stogramm/UserAcc";
import NavBar from './components/NavBar'

const root = ReactDOM.createRoot(document.getElementById("root"));
export const Context = createContext(null)


root.render(
  <Context.Provider value = {{
    user: new UserAcc()
  }}>
    <BrowserRouter>
    <NavBar/>
    <App />
    </BrowserRouter>
  </Context.Provider>
  
);