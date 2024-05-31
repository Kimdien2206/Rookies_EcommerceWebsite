/* eslint-disable @typescript-eslint/no-unused-vars */
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons'
import { Button, Form, FormInstance, Input, InputNumber, Row, Space } from 'antd'
import React, { FC } from 'react'

type ProductVariantCreateFormProps = {
    form: FormInstance
}

const ProductVariantCreateForm: FC<ProductVariantCreateFormProps> = ({ form }) => {
  return (
    <Form
      form={form}
    //   onFinish={onFinish}
      autoComplete="off"
      style={{ width: '100%' }}
    //   initialValues={initialValues}
    //   disabled={isReadOnly}
    >
      <Space direction='vertical' style={{ width: '100%' }}>
        <Row>
          <Form.List name="variants">
            {(fields, { add, remove }) => (
              <Space direction='vertical' style={{ marginBottom: 5, width: '100%' }}>
                  <Form.Item>
                    <Button type="dashed" onClick={() => add()} block icon={<PlusOutlined />}>
                      Add Variant
                    </Button>
                  </Form.Item>
                <Space direction='vertical' align='center' style={{ justifyContent: 'space-evenly', rowGap: 20, width: '100%' }}>
                  {fields.map((field) => (
                    <Space direction='vertical'>
                      <Space direction='horizontal' align='center'>
                        <Form.Item name={[field.name, `name`]} label="Name" style={{ marginBottom: 0 }}>
                          <Input />
                        </Form.Item>
                        <Form.Item name={[field.name, `stock`]} label="Stock" style={{ marginBottom: 0 }}>
                          <InputNumber min={1} />
                        </Form.Item>
                          <MinusCircleOutlined onClick={() => remove(field.name)} />
                      </Space>
                    </Space>
                  ))}
                </Space>
              </Space>
            )}
          </Form.List>
        </Row>
      </Space>
    </Form>
  )
}

export default ProductVariantCreateForm