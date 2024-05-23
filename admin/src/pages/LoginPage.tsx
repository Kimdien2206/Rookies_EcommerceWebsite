import React, { useContext, useEffect } from "react";
import LoginForm from "../component/Forms/LoginForm";
import { AppContext } from "../context/AppContext";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
  const {user} = useContext(AppContext);
  const nav = useNavigate();

  useEffect(() => {
    if(user) 
      nav("/admin/dashboard");
  }, [user])

  return (
    <div className="container-fluid bg-light min-vh-100 d-grid align-items-center background-image">
      <div className="row d-flex flex-row-reverse login-form">
        <LoginForm />
      </div>
    </div>
  );
};

export default LoginPage;
