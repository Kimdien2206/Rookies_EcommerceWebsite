/* eslint-disable @typescript-eslint/no-unused-vars */
import { Input, Space, Spin } from "antd";
import React from "react";
import useSWR from "swr";
import { INVOICE_KEY } from "../constant/apiKey";
import InvoiceTable from "./Table/InvoiceTable";

const PaidInvoice = () => {
  const { data, isLoading } = useSWR(`${INVOICE_KEY}/Paid`);

  return (
    <Spin spinning={isLoading}>
      <Space direction="vertical" style={{ width: "100%" }}>
        <Space direction="horizontal">
        
          <Input.Search
            size="middle"
            placeholder="Enter product name"
            enterButton
            style={{ width: "100%" }}
          />
        </Space>
        <InvoiceTable data={data} />
      </Space>
    </Spin>
  );
};

export default PaidInvoice;
