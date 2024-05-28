import React, { Dispatch, FC, SetStateAction, useContext } from "react";
import { Product } from "../../types/Product";
import Table, { ColumnsType } from "antd/es/table";
import { Button, Image, Modal, Space, Typography } from "antd";
import { compareNumber } from "../../helper/sorter";
import { formatNumberWithComma } from "../../helper/formater";
import { DeleteFilled, EditFilled } from "@ant-design/icons";
import { mutate } from "swr";
import { deleteProduct } from "../../api/ProductAPI";
import { ProductContext } from "../../context/ProductContext";
// import { useDispatch } from "react-redux";
// import * as actionTypes from "../../redux/actionTypes"


type ProductTableProps = {
  data: Product[];
  setIsModalOpen: Dispatch<SetStateAction<boolean>>;
};

const onDeleteButtonClick = (record: Product) => {
  Modal.confirm({
    title: "Delete confirmation",
    content:
      "Selected data will no longer display on website but still remains in the database, are you sure?",
    okText: "Yes",
    cancelText: "No",
    onOk: () => {
      deleteProduct(record.id)
        .then(() => {
          mutate("https://localhost:7144/api/Product");
        })
        .catch((error) => {
          throw new Error(error);
        });
    },
  });
};

const ProductTable: FC<ProductTableProps> = ({ data, setIsModalOpen }) => {
  const { setProduct } = useContext(ProductContext);

  const columns: ColumnsType<Product> = [
    {
      title: "ID",
      dataIndex: "id",
      key: "id",
    },
    {
      title: "Name",
      key: "name_image",
      width: "50%",
      render: (text: string, record: Product) => (
        <Space direction="horizontal">
          <Image
            className="imgborder"
            width={100}
            height={130}
            alt="example"
            src={record?.images[0]}
          />
          <Typography.Text>{record.name}</Typography.Text>
        </Space>
      ),
    },
    {
      title: "Price",
      dataIndex: "price",
      key: "price",
      sorter: (a, b) => compareNumber(a.price, b.price),
      render: (text: number) => <p>{formatNumberWithComma(text)}đ</p>,
    },
    {
      title: "Action",
      key: "action",
      width: "10%",
      render: (_: undefined, record: Product) => (
        <Space>
          <Button shape="circle" icon={<EditFilled />} onClick={() => {
            setIsModalOpen(prev => !prev)
            console.log(record);
            setProduct(record);
          }}/>
          <Button
            shape="circle"
            icon={<DeleteFilled />}
            onClick={() => onDeleteButtonClick(record)}
          />
        </Space>
      ),
    },
  ];

  console.log(data);
  return <Table columns={columns} dataSource={data} />;
};

export default ProductTable;
