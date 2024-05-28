/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { FC } from "react";
import Table, { ColumnsType } from "antd/es/table";
import { User } from "../../types/User";
import dayjs from "dayjs";

type UserTableProps = {
  data: User[];
};

const UserTable: FC<UserTableProps> = ({ data }) => {
  const columns: ColumnsType<User> = [
    {
      title: "ID",
      dataIndex: "id",
      key: "id",
    },
    {
      title: "Name",
      key: "fullname",
      width: "50%",
      render: (_: string, record: User) => (
        <p>{record.lastName} {record.firstName}</p>
      ),
    },
    {
      title: "Address",
      dataIndex: "address",
      key: "address",
    },
    {
      title: "Date of birth",
      dataIndex: "dateOfBirth",
      key: "dateOfBirth",
      render: (_: any, record: User) => <p>{dayjs(record.dateOfBirth).format("DD/MM/YYYY")}</p>,
    },
    {
      title: "Phone number",
      dataIndex: "phoneNumber",
      key: "phoneNumber",
    }
  ];

  return <Table columns={columns} dataSource={data} />;
};

export default UserTable;
