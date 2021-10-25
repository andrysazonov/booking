import React, { useContext, useState } from "react";
import { AuthContext } from "../../context/AuthContext";
import { useHttp } from "../../hooks/http.hook";

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
      AuthPage
      <input
        placeholder="Введите Логин"
        name="login"
        type="email"
        autoComplete="off"
        onChange={changeHandler}
      />
      <label htmlFor="email">Логин</label>
      <input
        placeholder="Введите пароль"
        name="password"
        type="password"
        onChange={changeHandler}
      />
      <label htmlFor="password">Пароль</label>
      <button disabled={loading} onClick={loginHandler}>
        Войти
      </button>
    </div>
  );
};
