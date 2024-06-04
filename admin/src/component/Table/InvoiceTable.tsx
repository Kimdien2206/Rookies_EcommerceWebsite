import Table, { ColumnsType } from 'antd/es/table';
import React, { FC } from 'react'
import { Invoice } from '../../types/Invoice';
import { compareNumber } from '../../helper/sorter';
import { formatNumberWithComma } from '../../helper/formater';
import dayjs from 'dayjs';
import { Tag } from 'antd';

type InvoiceTableProps = {
    data: Invoice[]
}

const InvoiceTable: FC<InvoiceTableProps> = ({ data }) => {
    const columns: ColumnsType<Invoice> = [
        {
          title: "ID",
          dataIndex: "id",
          key: "id",
        },
        {
          title: "Customer",
          key: "name",
          dataIndex: "name",
        },
        {
          title: "Address",
          key: "address",
          dataIndex: "address",
        },
        {
          title: "Status",
          key: "status",
          dataIndex: "status",
          render: (text: string) => text == '0' ? <Tag color={'red'} title={'Status'}>Unpaid</Tag> : <Tag color={'green'} title={'Status'}>Paid</Tag>
        },
        {
          title: "Created date",
          key: "createdDate",
          dataIndex: "createdDate",
          render: (text: Date) => <p>{dayjs(text).format("HH:mm DD/MM/YYYY")}</p>
        },
        {
          title: "Total Cost",
          dataIndex: "totalCost",
          key: "totalCost",
          sorter: (a, b) => compareNumber(a.totalCost, b.totalCost),
          render: (text: number) => <p>{formatNumberWithComma(text)}đ</p>,
        }
      ];
    
      console.log(data);
      return <Table columns={columns} dataSource={data} />;
}

export default InvoiceTable