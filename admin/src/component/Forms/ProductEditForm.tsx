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
  Modal,
} from "antd";
import { FormInstance } from "antd/es/form/Form";
import React, {
  Dispatch,
  FC,
  SetStateAction,
  useContext,
  useEffect,
  useState,
} from "react";
import { FORM_NO_BOTTOM_MARGIN } from "../../constant";
import { Product, ProductFormType } from "../../types/Product";
import { formatInputNumber } from "../../helper/formater";
import useSWR from "swr";
import { Category } from "../../types/Category";
import { ProductContext } from "../../context/ProductContext";
import { REQUIRED_RULE } from "../../constant/inputRules";
import { deleteImage } from "../../api/ProductAPI";

type ProductEditFormProps = {
  setImageList: Dispatch<SetStateAction<UploadFile[]>>;
  form: FormInstance<ProductFormType>;
};

const ProductEditForm: FC<ProductEditFormProps> = ({ setImageList, form }) => {
  const { product, setProduct } = useContext(ProductContext);
  const { data, isLoading } = useSWR("https://localhost:7144/api/Category");
  const [fileList, setFileList] = useState<UploadFile[]>(
    product &&
      product.images.map((item: string, index: number) => {
        return {
          uid: `${index}`,
          name: item.split("/")[8],
          status: "done",
          url: item,
        };
      })
  );

  useEffect(() => {
    setImageList(fileList);
  }, [fileList, setImageList]);

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

  const handleOnRemove = async (item: UploadFile) => {
    console.log(item);
    if (item.url) {
      let isDone = false;
      Modal.confirm({
        title: "Caution delete images",
        content: "Are you sure you want to delete this image",
        okText: "Yes",
        cancelText: "No",
        onOk: async () => {
          return await deleteImage(item.url?.split("/")[8].split(".")[0])
            .then(() => {
              setProduct((prev: Product) => {
                return {
                  ...prev,
                  images: product.images.filter(
                    (image: string) => image !== item.url
                  ),
                };
              });
              setFileList((prev: UploadFile[]) =>
                prev.filter((file) => file !== item)
              );
              form.setFieldValue(
                "upload",
                fileList.filter((file) => file !== item)
              );
            })
            .catch((error) => {
              console.log(error);
            });
        },
      });
      return false;
    } else if (item.originFileObj) {
      return true;
    }
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
              initialValue={product?.name}
            >
              <Input style={{ width: "100%" }} />
            </Form.Item>
          </Descriptions.Item>
          <Descriptions.Item label="Category" span={3}>
            <Form.Item
              name={"category"}
              rules={[REQUIRED_RULE]}
              style={FORM_NO_BOTTOM_MARGIN}
              initialValue={product?.categoryId}
            >
              <Select
                allowClear
                style={{ width: "100%" }}
                loading={isLoading}
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
              initialValue={fileList}
            >
              <Upload
                name="avatar"
                listType="picture-card"
                beforeUpload={() => {
                  return false;
                }}
                fileList={fileList}
                onChange={onChange}
                onRemove={handleOnRemove}
              >
                {fileList.length <= 4 && "+ Add image"}
              </Upload>
            </Form.Item>
          </Descriptions.Item>
          <Descriptions.Item label="Description" span={3}>
            <Form.Item
              name={"description"}
              rules={[REQUIRED_RULE]}
              style={FORM_NO_BOTTOM_MARGIN}
              initialValue={product?.description}
            >
              <Input.TextArea style={{ width: "100%", height: 150 }} />
            </Form.Item>
          </Descriptions.Item>
          <Descriptions.Item label="Price(đ)" span={3}>
            <Form.Item
              name={"price"}
              rules={[REQUIRED_RULE]}
              style={FORM_NO_BOTTOM_MARGIN}
              initialValue={product?.price}
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
        {/* <ProductInventoryCreateForm form={form} /> */}
      </Space>
    </Form>
  );
};

export default ProductEditForm;
