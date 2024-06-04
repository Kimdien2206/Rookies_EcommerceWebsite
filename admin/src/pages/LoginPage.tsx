import React, { useContext, useEffect } from "react";
import LoginForm from "../component/Forms/LoginForm";
import { AppContext } from "../context/AppContext";
import { useNavigate } from "react-router-dom";
import LocalStorage from "../helper/localStorage";

const LoginPage = () => {
  const {user} = useContext(AppContext);
  const nav = useNavigate();

  useEffect(() => {
    const storedUser = LocalStorage.getItem("user");
    if(user || storedUser) 
      nav("/admin/dashboard");
  }, [user, nav])

  return (
    <div className="container-fluid bg-light min-vh-100 d-grid align-items-center background-image">
      <div className="row d-flex flex-row-reverse login-form">
        <LoginForm />
      </div>
    </div>
  );
};

export default LoginPage;
