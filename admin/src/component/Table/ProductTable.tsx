import React from 'react'
import { Product } from '../../types/Product';
import Table, { ColumnsType } from 'antd/es/table';
import { Button, Image, Space, Typography } from 'antd';
import { compareNumber } from '../../helper/sorter';
import { formatNumberWithComma } from '../../helper/formater';
import { EditFilled } from '@ant-design/icons';

type ProductTableProps = {
    data: Product[],
}

const columns: ColumnsType<Product> = [
    {
      title: 'ID',
      dataIndex: 'id',
      key: 'id',
    },
    {
      title: 'Name',
      key: 'name_image',
      width: '50%',
      render: (text: string, record: Product) => <Space direction='horizontal'>
        <Image className='imgborder' width={100} height={130} alt="example" src={record?.images[0]} />
        <Typography.Text>{record.name}</Typography.Text>
      </Space>,
    },
    {
      title: 'Price',
      dataIndex: 'price',
      key: 'price',
      sorter: (a, b) => compareNumber(a.price, b.price),
      render: (text: number) => <p>{formatNumberWithComma(text)}</p>
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
      title: 'Action',
      key: 'action',
      width: '10%',
      render: () => <Space>
        <Button shape="circle" icon={<EditFilled />} />
      </Space>,
    },
  ];

const ProductTable = (props: ProductTableProps) => {
    console.log(props.data);
  return (
    <Table columns={columns} dataSource={props.data} 
    // onRow={(record, rowIndex) => {
    //     return {
    //       onClick: (event) => {
    //         if (isClickValidToOpenDetail(event)) {
    //           dispatch({ type: SET_ACTION, payload: ACTION_READ })
    //           setIsModalOpen((prev: boolean) => !prev);
    //           setSelectedItem(record)
    //         }
    //       },
    //     };
    //   }} 
      />
  )
}

export default ProductTable