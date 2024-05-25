import React, { FC } from "react";
import { Category } from "../../types/Category";
import Table, { ColumnsType } from "antd/es/table";
import { Button, Space } from "antd";
import { EditFilled } from "@ant-design/icons";

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
    render: () => (
      <Space>
        <Button shape="circle" icon={<EditFilled />} />
      </Space>
    ),
  },
];

type CategoryTableProps = {
  data: Category[];
};

const CategoryTable: FC<CategoryTableProps> = ({ data }) => {
  return <Table columns={columns} dataSource={data} />;
};

export default CategoryTable;
