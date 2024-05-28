import { Input, Space, Spin } from "antd";
import React from "react";
import UserTable from "./Table/UserTable";
import useSWR from "swr";

const User = () => {
  const { data, isLoading } = useSWR("https://localhost:7144/api/User");

  return (
    <Spin spinning={isLoading}>
      <Space direction="vertical" style={{ width: "100%" }}>
        <Space direction="horizontal">
          <Input.Search
            // value={searchText}
            size="middle"
            placeholder="Nhập tên nhãn"
            enterButton
            style={{ width: "100%" }}
            // onChange={onChange}
          />
        </Space>
          <UserTable data={data} />
      </Space>
    </Spin>
  );
};

export default User;
