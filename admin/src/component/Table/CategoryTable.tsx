/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { FC } from "react";
import { Category } from "../../types/Category";
import Table, { ColumnsType } from "antd/es/table";
import { Button, Modal, Space } from "antd";
import { DeleteFilled, EditFilled } from "@ant-design/icons";
import { deleteCategory } from "../../api/CategoryAPI";
import { mutate } from "swr";

const columns: ColumnsType<Category> = [
  {
    title: "ID",
    dataIndex: "id",
    key: "id",
  },
  {
    title: "Name",
    key: "name",
    dataIndex: "name",
    width: "50%",
    render: (text: string) => <p>{text}</p>,
  },
  {
    title: "Description",
    dataIndex: "description",
    key: "description",
    render: (text: string) => <p>{text}</p>,
  },
  {
    title: "Action",
    key: "action",
    width: "10%",
    render: (_: undefined, record: Category) => (
      <Space>
        <Button shape="circle" icon={<EditFilled />} />
        <Button shape="circle" icon={<DeleteFilled />} onClick={() => onDeleteButtonClick(record)}/>
      </Space>
    ),
  },
];

const onDeleteButtonClick = (record: Category) => {
  Modal.confirm({
    title: "Delete confirmation",
    content: "Selected data will no longer display on website, are you sure?",
    okText: "Yes",
    cancelText: "No",
    onOk: () => {
      deleteCategory(record.id).then(() => {
        mutate("https://localhost:7144/api/Category");
      }).catch((error) => {
        throw new Error(error)
      });
    },
  });
}

type CategoryTableProps = {
  data: Category[];
};

const CategoryTable: FC<CategoryTableProps> = ({ data }) => {
  return <Table columns={columns} dataSource={data} />;
};

export default CategoryTable;
