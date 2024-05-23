import { Descriptions, Form, FormInstance, Input, Space } from "antd";
import React from "react";
import { Category } from "../../types/Category";
import { FORM_NO_BOTTOM_MARGIN } from "../../constant";

type CategoryCreateFormProps = {
    form: FormInstance<Category>;
  };

const CategoryCreateForm = (props : CategoryCreateFormProps) => {
  return (
    <Form form={props.form}>
      <Space direction="vertical" style={{ width: "100%" }}>
        <Descriptions title="Product information" bordered>
          <Descriptions.Item label="ID" span={3}>
            Auto
          </Descriptions.Item>
          <Descriptions.Item label="Name" span={3}>
            <Form.Item
              name={"name"}
              //   rules={[REQUIRED_RULE]}
              style={FORM_NO_BOTTOM_MARGIN}
            >
              <Input style={{ width: "100%" }} />
            </Form.Item>
          </Descriptions.Item>
          <Descriptions.Item label="Description" span={3}>
            <Form.Item
              name={"description"}
              //   rules={[REQUIRED_RULE]}
              style={FORM_NO_BOTTOM_MARGIN}
            >
              <Input.TextArea style={{ width: "100%", height: 150 }} />
            </Form.Item>
          </Descriptions.Item>
        </Descriptions>
      </Space>
    </Form>
  );
};

export default CategoryCreateForm;
