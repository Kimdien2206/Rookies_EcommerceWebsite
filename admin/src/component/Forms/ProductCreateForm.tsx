/* eslint-disable @typescript-eslint/no-explicit-any */
import {
  Descriptions,
  Divider,
  Input,
  InputNumber,
  Select,
  Space,
  Upload,
  Form,
  UploadFile,
  UploadProps,
} from "antd";
import { FormInstance } from "antd/es/form/Form";
import React, { Dispatch, FC, SetStateAction, useState } from "react";
import { FORM_NO_BOTTOM_MARGIN } from "../../constant";
import { ProductFormType } from "../../types/Product";
import { formatInputNumber } from "../../helper/formater";
import useSWR from "swr";
import { Category } from "../../types/Category";
import { REQUIRED_RULE } from "../../constant/inputRules";
import ProductVariantCreateForm from "./ProductVariantCreateForm";

type ProductCreateFormProps = {
  setImageList: Dispatch<SetStateAction<UploadFile[]>>;
  form: FormInstance<ProductFormType>;
};

const ProductCreateForm : FC<ProductCreateFormProps> = ({ setImageList, form}) => {
  const [fileList, setFileList] = useState<UploadFile[]>([
    {
      uid: "-1",
      name: "image.png",
      status: "done",
      url: "https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png",
    },
  ]);
  const { data } = useSWR("https://localhost:7144/api/Category");

  const onChange: UploadProps["onChange"] = ({ fileList: newFileList }) => {
    console.log(newFileList);
    setImageList([...newFileList]);
    setFileList(newFileList);
  };
  const normFile = (e: any) => {
    console.log("Upload event:", e);
    if (Array.isArray(e)) {
      console.log(e);
      return e;
    }
    return e?.fileList;
  };
  return (
    <Form form={form}>
      <Space direction="vertical" style={{ width: "100%" }}>
        <Descriptions title="Product information" bordered>
          <Descriptions.Item label="ID" span={3}>
            Auto
          </Descriptions.Item>
          <Descriptions.Item label="Name" span={3}>
            <Form.Item
              name={"name"}
              rules={[REQUIRED_RULE]}
              style={FORM_NO_BOTTOM_MARGIN}
            >
              <Input style={{ width: "100%" }} />
            </Form.Item>
          </Descriptions.Item>
          <Descriptions.Item label="Category" span={3}>
            <Form.Item
              name={"category"}
              rules={[REQUIRED_RULE]}
              style={FORM_NO_BOTTOM_MARGIN}
            >
              <Select
                allowClear
                style={{ width: "100%" }}
                placeholder="Choose one category for product"
                options={data?.map((item: Category) => {
                  return { value: item.id, label: item.name };
                })}
              />
            </Form.Item>
          </Descriptions.Item>
          <Descriptions.Item label="Images" span={3}>
            <Form.Item
              name="upload"
              valuePropName="fileList"
              getValueFromEvent={normFile}
              style={FORM_NO_BOTTOM_MARGIN}
            >
              <Upload
                name="avatar"
                listType="picture-card"
                beforeUpload={() => {
                  return false;
                }}
                onChange={onChange}
              >
                {fileList.length < 4 && "+ Add image"}
              </Upload>
            </Form.Item>
          </Descriptions.Item>
          <Descriptions.Item label="Description" span={3}>
            <Form.Item
              name={"description"}
              rules={[REQUIRED_RULE]}
              style={FORM_NO_BOTTOM_MARGIN}
            >
              <Input.TextArea style={{ width: "100%", height: 150 }} />
            </Form.Item>
          </Descriptions.Item>
          <Descriptions.Item label="Price(đ)" span={3}>
            <Form.Item
              name={"price"}
              rules={[REQUIRED_RULE]}
              style={FORM_NO_BOTTOM_MARGIN}
            >
              <InputNumber
                min={1000}
                controls={false}
                style={{ width: "100%" }}
                formatter={(value) => formatInputNumber(value?.toString())}
                addonAfter="đ"
              />
            </Form.Item>
          </Descriptions.Item>
        </Descriptions>
        <Divider />
        <ProductVariantCreateForm form={form} />
      </Space>
    </Form>
  );
};

export default ProductCreateForm;
