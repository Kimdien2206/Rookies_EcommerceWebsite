import React from "react";
import LoginForm from "../component/Forms/LoginForm";

const LoginPage = () => {
  return (
    <div className="container-fluid bg-light min-vh-100 d-grid align-items-center background-image">
      <div className="row d-flex flex-row-reverse login-form">
        <LoginForm />
      </div>
    </div>
  );
};

export default LoginPage;
