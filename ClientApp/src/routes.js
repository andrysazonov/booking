import React, { useEffect } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { BookingPage } from "./pages/BookingPage";
import { AuthPage } from "./pages/AuthPage";
import { ReservationsPage } from "./pages/ReservationsPage";
import { NotFoundPage } from "./pages/404";

export const useRoutes = (isAuthenticated) => {

  if (isAuthenticated) {
    return (
      <Switch>
        <Route path="/booking" exact>
          <BookingPage />
        </Route>
        <Route path="/reservations" exact>
          <ReservationsPage />
        </Route>
        {/* <Redirect to="/booking" /> */}
        <Route path='*' exact={true} >
          <NotFoundPage path="/booking"/>
        </Route>
        
      </Switch>
    );
  }
  return (
    <Switch>
      <Route path="/" exact>
        <AuthPage />
      </Route>
      <Route path='*' exact={true} >
      <NotFoundPage path="/"/></Route>
      {/* <Redirect to="/" /> */}
    </Switch>
  );
};
