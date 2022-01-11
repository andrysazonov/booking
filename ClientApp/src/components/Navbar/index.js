import React, { useContext } from "react";
import { Logo } from "../Logo";
import styles from "./navbar.module.css";
import { AuthContext } from "../../context/AuthContext";
import { Link } from "react-router-dom";

export const Navbar = () => {
  const auth = useContext(AuthContext);
  return (
    <div className={styles.navbar}>
      <div className={styles.flex}>
        <div className={styles.logo_container}>
          <Logo />
        </div>
        {auth.isAuthenticated && (
          <Link to="/booking">
            <button className={`${styles.logout} ${styles.link}`}>Забронировать</button>
          </Link>
        )}
        {auth.isAuthenticated && (
          <Link to="/reservations">
            <button className={`${styles.logout} ${styles.link}`}>Мои записи</button>
          </Link>
        )}
      </div>

      {auth.isAuthenticated && (
        <Link to="/">
          <button onClick={() => auth.logout()} className={styles.logout}>
            Выйти
          </button>
        </Link>
      )}
    </div>
  );
};
