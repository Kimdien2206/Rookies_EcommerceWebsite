/* eslint-disable @typescript-eslint/no-explicit-any */
import { Button, Input, Space, Spin } from "antd";
import React, { useState } from "react";
import useSWR from "swr";
import ProductTable from "./Table/ProductTable";
import ProductCreateModal from "./Modals/ProductCreateModal";
import ProductEditModal from "./Modals/ProductEditModal";
import { ProductProvider } from "../context/ProductContext";
import { PRODUCT_KEY } from "../constant/apiKey";

const Products = () => {
  const { data, isLoading } = useSWR(PRODUCT_KEY);
  const [isCreateModalOpen, setIsCreateModalOpen] = useState<boolean>(false);
  const [isEditModalOpen, setIsEditModalOpen] = useState<boolean>(false);

  return (
    <Spin spinning={isLoading}>
      <Space direction="vertical" style={{ width: "100%" }}>
        <Space direction="horizontal">
          <Button
            type="primary"
            onClick={() => {
              setIsCreateModalOpen(true);
              // dispatch({ type: SET_ACTION, payload: ACTION_CREATE })
            }}
          >
            Create new
          </Button>
          <Input.Search
            size="middle"
            placeholder="Enter product name"
            enterButton
            style={{ width: "100%" }}
          />
        </Space>
        <ProductProvider>
          {isCreateModalOpen && (
            <ProductCreateModal
              isOpen={isCreateModalOpen}
              setIsModalOpen={setIsCreateModalOpen}
            />
          )}
          {isEditModalOpen && (
            <ProductEditModal
              isOpen={isEditModalOpen}
              setIsModalOpen={setIsEditModalOpen}
            />
          )}
          <ProductTable
            data={data}
            setIsModalOpen={setIsEditModalOpen}
          />
        </ProductProvider>
      </Space>
    </Spin>
  );
};

export default Products;
