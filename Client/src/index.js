import React, { createContext } from "react";
import ReactDOM from "react-dom/client";

import { BrowserRouter } from "react-router-dom";

import "./index.css";
import App from "./App";
import UserAcc from "./Stogramm/UserAcc";

const root = ReactDOM.createRoot(document.getElementById("root"));
export const Context = createContext(null)


root.render(
  <Context.Provider value = {{
    user: new UserAcc()
  }}>
    <BrowserRouter>
    <App />
    </BrowserRouter>
  </Context.Provider>
  
);