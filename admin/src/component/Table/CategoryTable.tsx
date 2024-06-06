/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { FC, useState } from "react";
import { Category } from "../../types/Category";
import Table, { ColumnGroupType, ColumnsType } from "antd/es/table";
import {
  Button,
  FormInstance,
  Modal,
  Popconfirm,
  Space,
  Typography,
  message,
  notification,
} from "antd";
import { DeleteFilled, EditFilled } from "@ant-design/icons";
import { deleteCategory, updateCategory } from "../../api/CategoryAPI";
import { mutate } from "swr";
import EditableCell from "../EditableCell";
import { REQUIRED_RULE } from "../../constant/inputRules";

const onDeleteButtonClick = (record: Category) => {
  Modal.confirm({
    title: "Delete confirmation",
    content: "Selected data will no longer display on website, are you sure?",
    okText: "Yes",
    cancelText: "No",
    onOk: () => {
      deleteCategory(record.id)
        .then(() => {
          mutate("https://localhost:7144/api/Category");
        })
        .catch((error) => {
          throw new Error(error);
        });
    },
  });
};

type CategoryTableProps = {
  data: Category[];
  form: FormInstance;
};

const CategoryTable: FC<CategoryTableProps> = ({ data, form }) => {
  const [editingKey, setEditingKey] = useState<string | undefined>("");
  const isEditing = (record: Category) => record.id.toString() === editingKey;

  const columns = [
    {
      title: "ID",
      dataIndex: "id",
      key: "id",
      width: "30%",
    },
    {
      title: "Name",
      key: "name",
      dataIndex: "name",
      editable: true,
    },
    {
      title: "Description",
      dataIndex: "description",
      key: "description",
      editable: true,
      // render: (text: string) => <p>{text}</p>,
    },
    {
      title: "Action",
      key: "action",
      width: "10%",
      render: (_: undefined, record: Category) => {
        const editable = isEditing(record);
        return (
          <Space>
            {editable ? (
              <>
                <Typography.Link
                  onClick={() => save(record.id)}
                  style={{ marginRight: 8 }}
                >
                  Lưu
                </Typography.Link>
                <Popconfirm
                  title="Thông tin sẽ không được lưu bạn có chắc chắn muốn hủy?"
                  onConfirm={cancel}
                >
                  <a>Hủy</a>
                </Popconfirm>
              </>
            ) : (
              <>
                <Button
                  shape="circle"
                  icon={<EditFilled />}
                  onClick={() => edit(record)}
                />
                <Button
                  shape="circle"
                  icon={<DeleteFilled />}
                  onClick={() => onDeleteButtonClick(record)}
                />
              </>
            )}
          </Space>
        );
      },
    },
  ];

  const edit = (record: Partial<Category>) => {
    form.setFieldsValue(record);
    setEditingKey(record.id?.toString());
  };

  const save = (id: string) => {
    form.validateFields().then((data) => {
      const newCategoryInfo = {
        name: data.name, 
        description: data.description 
      };
      updateCategory(id, newCategoryInfo)
        .then(() => {
          mutate("https://localhost:7144/api/Category");
          notification.success({ message: "Update successfully" });
          setEditingKey('')
        })
        .catch((error) => {
          notification.error({ message: `Something went wrong: ${error}` });
        });
    });
  };
  const cancel = () => {
    setEditingKey("");
  };

  const mergedColumns = columns.map((col) => {
    if (!col.editable) {
      return col;
    }
    return {
      ...col,
      onCell: (record: Category) => ({
        record,
        inputType: "INPUT",
        dataIndex: col.dataIndex,
        title: col.title,
        rules: [REQUIRED_RULE],
        editing: isEditing(record),
      }),
    };
  });

  return (
    <Table
      rowKey={(record) => record.id}
      components={{
        body: {
          cell: EditableCell,
        },
      }}
      rowClassName="editable-row"
      columns={mergedColumns}
      dataSource={data}
    />
  );
};

export default CategoryTable;
