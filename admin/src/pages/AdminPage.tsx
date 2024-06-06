import { Button, Layout, Space } from "antd";
import {
  MenuFoldOutlined,
  MenuUnfoldOutlined,
} from "@ant-design/icons/lib/icons";

import Sider from "antd/es/layout/Sider";
import React, { useContext, useEffect, useState } from "react";
import NavBar from "../component/NavBar";
import { Content, Header } from "antd/es/layout/layout";
import { Navigate, Outlet, useNavigate } from "react-router-dom";
import Scrollbars from "react-custom-scrollbars";
import Cookies from "js-cookie";
import LocalStorage from "../helper/localStorage";
import { AppContext } from "../context/AppContext";

const AdminPage = () => {
  const [collapsed, setCollapsed] = useState<boolean>(false);
  const { setUser } = useContext(AppContext);
  const nav = useNavigate();
  const storedUser = LocalStorage.getItem("user");

  console.log(storedUser)

  if (storedUser == null) {
    // user is not authenticated
    return <Navigate to="/" />;
  }
  
  const handleLogout = () => {
    Cookies.remove("access_token");
    LocalStorage.deleteItem("user");
    setUser && setUser(null);
    nav('/')
  }
  
  
  return (
    <Layout style={{ width: "100%", height: "100vh" }}>
      <Sider trigger={null}  collapsible collapsed={collapsed}>
        <Space direction="vertical" style={{justifyContent: "space-between"}}>
          <NavBar />
          <Button onClick={handleLogout}>Log out</Button>

        </Space>
      </Sider>
      <Layout className="site-layout">
        <Header style={{ padding: 0, background: "white" }}>
          <span style={{ margin: "0 20px" }}>
            {collapsed ? (
              <MenuUnfoldOutlined
                style={{ fontSize: 20 }}
                onClick={() => setCollapsed((prev) => !prev)}
              />
            ) : (
              <MenuFoldOutlined
                onClick={() => setCollapsed((prev) => !prev)}
                style={{ fontSize: 20 }}
              />
            )}
          </span>
        </Header>
        <Scrollbars>
          <Content
            style={{
              padding: 20,
            }}
          >
            <Outlet />
          </Content>
        </Scrollbars>
      </Layout>
    </Layout>
  );
};

export default AdminPage;
