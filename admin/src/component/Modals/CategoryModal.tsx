import { Modal } from "antd";
import { useForm } from "antd/es/form/Form";
import React, { Dispatch, SetStateAction } from "react";
import { Category, CategoryCreateDto } from "../../types/Category";
import CategoryCreateForm from "../Forms/CategoryCreateForm";
import { createCategory } from "../../api/CategoryAPI";
import { mutate } from "swr";

type CategoryModalProps = {
  isOpen: boolean;
  setIsModalOpen: Dispatch<SetStateAction<boolean>>;
};

const CategoryModal = (props: CategoryModalProps) => {
  const [form] = useForm<Category>();

  const handleOKModal = () => {
    form.validateFields().then((data) => {
      console.log(data);
      const newCategory: CategoryCreateDto = {
        name: data.name,
        description: data.description,
      };

      createCategory(newCategory)
        .then(() => {
          mutate("https://localhost:7144/api/Category");
          form.resetFields();
          props.setIsModalOpen(prev => !prev);
        })
        .catch((error) => {
            throw new Error(error);
        });
    });
  };

  return (
    <Modal
      title={"Create new product"}
      open={props.isOpen}
      width={"70vw"}
      //   footer={setModalFooter(action)}
      onCancel={() => {
        Modal.confirm({
          title: "Lost data caution",
          content: "Unsaved data will be lost, are you sure?",
          okText: "Yes",
          cancelText: "No",
          onOk: () => {
            props.setIsModalOpen((prev: boolean) => !prev);
          },
          onCancel: () => {
            props.setIsModalOpen((prev: boolean) => !prev);
          },
        });
      }}
      onOk={() => {
        handleOKModal();
      }}
    >
      <CategoryCreateForm form={form} />
    </Modal>
  );
};

export default CategoryModal;
