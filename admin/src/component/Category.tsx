import { Button, Form, Input, Space, Spin } from "antd";
import React, { useState } from "react";
import useSWR from "swr";
import CategoryTable from "./Table/CategoryTable";
import CategoryModal from "./Modals/CategoryModal";
import { useForm } from "antd/es/form/Form";

const Category = () => {
  const { data, isLoading } = useSWR("https://localhost:7144/api/Category");
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  const [form] = useForm();

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
        <Form form={form} component={false}>
          <CategoryTable
            data={data}
            form={form}
          />
        </Form>
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
