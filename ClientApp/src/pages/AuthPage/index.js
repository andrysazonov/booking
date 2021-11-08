import React, { useContext, useState } from "react";
import { AuthContext } from "../../context/AuthContext";
import { useHttp } from "../../hooks/http.hook";
import './authPage.css';

export const AuthPage = () => {
  const auth = useContext(AuthContext);

  const { loading, error, clearError, request } = useHttp();
  const [form, setForm] = useState({
    login: "",
    password: "",
  });

  const changeHandler = (event) => {
    setForm({ ...form, [event.target.name]: event.target.value });
  };

  const loginHandler = async () => {
    try {
      console.log("sdfds",form)
      const data = await request("/api/auth/login", "POST", { ...form });
      console.log("Data Auth", data);
      //   auth.login(data.token, data.userId, form.login);
    } catch (error) {}
  };

  return (
    <div>
      <form>
        <h1 className="authPageTitle">Войдите в свой аккаунт</h1>
        <input
          placeholder="Логин"
          className="loginInput"
          name="login"
          type="email"
          autoComplete="off"
          onChange={changeHandler}
        />
        <input
          placeholder="Пароль"
          className="passwordInput"
          name="password"
          type="password"
          onChange={changeHandler}
        />
        <button disabled={loading} onClick={loginHandler} className="sendButton">
          Войти
        </button>
        <a className="forgetPassword" href="/">Забыли пароль?</a>
      </form>
    </div>
  );
};
