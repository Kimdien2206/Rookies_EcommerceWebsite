/* eslint-disable @typescript-eslint/no-unused-vars */
import { Modal, Spin, UploadFile, notification } from "antd";
import React, { Dispatch, FC, SetStateAction, useState } from "react";
import ProductCreateForm from "../Forms/ProductCreateForm";
import { useForm } from "antd/es/form/Form";
import {
  Product,
  ProductCreateDto,
  ProductFormType,
} from "../../types/Product";
import slugify from "slugify";
import { createProduct, uploadImage } from "../../api/ProductAPI";
import { mutate } from "swr";
import { UploadResponse } from "../../types/UploadImageResponse";
import { uploadImageFunc } from "../../helper/utils";

type ProductCreateModalProps = {
  isOpen: boolean;
  setIsModalOpen: Dispatch<SetStateAction<boolean>>;
};

const ProductCreateModal: FC<ProductCreateModalProps> = ({
  isOpen,
  setIsModalOpen,
}) => {
  const [imageList, setImageList] = useState<UploadFile[]>([]);
  const [form] = useForm<ProductFormType>();
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const handleOKModal = () => {
    setIsLoading(true);
    form.validateFields().then((data) => {
      console.log(data);
      const slugString = slugify(data.name);

      imageList &&
        uploadImageFunc(imageList, slugString).then((URLs) => {
          const newProduct: ProductCreateDto = {
            name: data.name,
            slug: slugString,
            price: data.price,
            description: data.description,
            categoryId: data.category,
            images: URLs ? URLs : undefined,
          };
          createProduct(newProduct)
            .then(() => {
              mutate("https://localhost:7144/api/Product");
              setIsModalOpen(false);
              setIsLoading(false);
              form.resetFields();
              notification.success({ message: "Create product succeeded" });
            })
            .catch((error) => {
              notification.error({ message: "Something went wrong" });
              throw new Error(error);
            });
        });
    });
  };
  return (
    <Modal
      title={"Create new product"}
      open={isOpen}
      width={"70vw"}
      //   footer={setModalFooter(action)}
      onCancel={() => {
        Modal.confirm({
          title: "Lost data caution",
          content: "Unsaved data will be lost, are you sure?",
          okText: "Yes",
          cancelText: "No",
          onOk: () => {
            setIsModalOpen(false);
          },
          onCancel: () => {
            setIsModalOpen(false);
          },
        });
      }}
      onOk={() => {
        handleOKModal();
      }}
    >
      <Spin spinning={isLoading}>
        <ProductCreateForm setImageList={setImageList} form={form} />
      </Spin>
    </Modal>
  );
};

export default ProductCreateModal;
