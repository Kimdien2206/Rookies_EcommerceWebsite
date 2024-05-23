import { Button, Input, Space, Spin } from "antd";
import React, { Dispatch, SetStateAction, useState } from "react";
import useSWR from "swr";
import ProductTable from "./Table/ProductTable";
import ProductModal from "./Modals/ProductModal";

const Product = () => {
  const { data, isLoading } = useSWR("https://localhost:7144/api/Product");
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);

  return (
    <Spin spinning={isLoading}>
      <Space direction="vertical" style={{ width: "100%" }}>
        <Space direction="horizontal">
          <Button
            type="primary"
            onClick={() => {
              setIsModalOpen(true);
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
        {renderModal(isModalOpen, setIsModalOpen)}
        <ProductTable data={data} />
      </Space>
    </Spin>
  );
};

function renderModal(isOpen: boolean, setIsModalOpen: Dispatch<SetStateAction<boolean>>) {
    if (isOpen === false)
      return null;
        return <ProductModal isOpen={isOpen} setIsModalOpen={setIsModalOpen} />
    }
  

export default Product;
