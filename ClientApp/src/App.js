import React from "react";
import { Navbar } from "./components/Navbar";
import { useRoutes } from "./routes";
import {useAuth} from "./hooks/auth.hook"
import { BrowserRouter as Router } from "react-router-dom";

export const App = () => {
  const { token, login, logout } = useAuth()
  console.log("TOKEN",token)
  const isAuthenticated = !!token
  const routes = useRoutes(isAuthenticated)

  return (
    <div>
      <Navbar />
      <Router>
        {routes}
      </Router>
    </div>
  );
};
