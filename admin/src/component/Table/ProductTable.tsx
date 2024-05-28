import React, { FC } from "react";
import { Product } from "../../types/Product";
import Table, { ColumnsType } from "antd/es/table";
import { Button, Image, Modal, Space, Typography } from "antd";
import { compareNumber } from "../../helper/sorter";
import { formatNumberWithComma } from "../../helper/formater";
import { DeleteFilled, EditFilled } from "@ant-design/icons";
import { mutate } from "swr";
import { deleteProduct } from "../../api/ProductAPI";

type ProductTableProps = {
  data: Product[];
};

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
  // {
  //   title: 'Lượt xem',
  //   dataIndex: 'view',
  //   key: 'view',
  //   sorter: (a, b) => compareNumber(a.view, b.view),
  //   render: (text: number, record: Product) => <p>{formatNumberWithComma(text)}</p>
  // },
  // {
  //   title: 'Bán',
  //   dataIndex: 'sold',
  //   key: 'sold',
  //   sorter: (a, b) => compareNumber(a.sold, b.sold),
  //   render: (text: number, record: Product) => <p>{formatNumberWithComma(text)}</p>
  // },
  {
    title: "Action",
    key: "action",
    width: "10%",
    render: (_: undefined, record: Product) => (
      <Space>
        <Button shape="circle" icon={<EditFilled />} />
        <Button
          shape="circle"
          icon={<DeleteFilled />}
          onClick={() => onDeleteButtonClick(record)}
        />
      </Space>
    ),
  },
];

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

const ProductTable: FC<ProductTableProps> = ({data}) => {
  console.log(data);
  return (
    <Table
      columns={columns}
      dataSource={data}
    />
  );
};

export default ProductTable;
