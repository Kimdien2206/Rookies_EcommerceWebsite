import { Button, Result } from "antd";
import React from "react";
import { useNavigate } from "react-router-dom";

const NotFound = () => {
  const nav = useNavigate();

  return (
    <div className="container">
      <Result
        status="404"
        title="404"
        subTitle="Page not found, please go back to home page"
        extra={
          <Button onClick={() => nav("")} type="primary">
            Back to Homepage
          </Button>
        }
      />
    </div>
  );
};

export default NotFound;
