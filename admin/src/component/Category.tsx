import { Button, Input, Space, Spin } from "antd";
import React, { useState } from "react";
import useSWR from "swr";
import CategoryTable from "./Table/CategoryTable";
import CategoryModal from "./Modals/CategoryModal";

const Category = () => {
  const { data, isLoading } = useSWR("https://localhost:7144/api/Category");
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);

  return (
    <Spin spinning={isLoading}>
      <Space direction="vertical" style={{ width: "100%" }}>
        <Space direction="horizontal">
          <Button type="primary" onClick={() => setIsModalOpen(true)}>
            Thêm mới
          </Button>
          <Input.Search
            // value={searchText}
            size="middle"
            placeholder="Nhập tên nhãn"
            enterButton
            style={{ width: "100%" }}
            // onChange={onChange}
          />
        </Space>
        <CategoryTable
          data={data}
          // setData={setSearchData}
          // discounts={discounts}
        />
      </Space>
      <CategoryModal
        // setDataState={setSearchData}
        isOpen={isModalOpen}
        setIsModalOpen={setIsModalOpen}
        // discounts={discounts}
      />
    </Spin>
  );
};

export default Category;
