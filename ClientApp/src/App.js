import React from "react";
import { Navbar } from "./components/Navbar";
import { useRoutes } from "./routes";
import { BrowserRouter as Router } from "react-router-dom";
import './styles.css';

export const App = () => {
  const routes = useRoutes(true);

  return (
    <div className="root">
      <Navbar />
      <Router>
        {routes}
      </Router>
    </div>
  );
};
