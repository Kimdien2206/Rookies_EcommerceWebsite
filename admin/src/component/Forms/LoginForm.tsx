/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { useContext } from "react";
import { Button, Form, FormProps, Input } from "antd";
import {
  PASSWORD_REQUIRED,
  USERNAME_REQUIRED,
} from "../../constant/inputRules";
import { LoginRequest } from "../../types/Auth";
import { getToken, login } from "../../api/AuthAPI";
import { redirect, useNavigate } from "react-router-dom";
import { useCookies } from "react-cookie";
import AppContext from "antd/es/app/context";
import LocalStorage from "../../helper/localStorage";

type FieldType = {
  username?: string;
  password?: string;
};


const onFinishFailed: FormProps<FieldType>["onFinishFailed"] = (errorInfo) => {
    console.log("Failed:", errorInfo);
};

const LoginForm = () => {
    const [cookies, setCookie] = useCookies();
    const {setUser} = useContext(AppContext);
    const nav = useNavigate();

    const onFinish: FormProps<FieldType>["onFinish"] = (values) => {
      if (values.password && values.username) {
        const loginInfo: LoginRequest = {
          userName: values.username,
          password: values.password,
        };
        login(loginInfo).then(({ data }) => {
          if(data.succeeded){
            getToken(loginInfo).then(({data: tokenData}) => {
                const tokenExpires = new Date(tokenData.expiredTime);
                setCookie('access_token', tokenData.token, { path: '/',  expires: tokenExpires})
                const user = {
                  username: tokenData.userName,
                  email: tokenData.email,
                  role: tokenData.role
                }
                LocalStorage.setItem("user", user);
                setUser && setUser(user);
                nav("/admin/dashboard")
            })
          }
        });
      }
    
    };
  return (
    <div className="col-7 me-5 ">
      <Form
        name="basic"
        labelCol={{ span: 8 }}
        wrapperCol={{ span: 16 }}
        initialValues={{ remember: true }}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
        autoComplete="on"
      >
        <Form.Item<FieldType>
          label="Username"
          name="username"
          rules={[USERNAME_REQUIRED]}
        >
          <Input />
        </Form.Item>

        <Form.Item<FieldType>
          label="Password"
          name="password"
          rules={[PASSWORD_REQUIRED]}
        >
          <Input.Password />
        </Form.Item>
        <div className="d-flex flex-row-reverse me-5">
          <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
            <Button type="primary" htmlType="submit">
              Login
            </Button>
          </Form.Item>
        </div>
      </Form>
    </div>
  );
};

export default LoginForm;
