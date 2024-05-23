/* eslint-disable @typescript-eslint/no-unused-vars */
import { Modal, Spin, UploadFile, notification } from "antd";
import React, { Dispatch, SetStateAction, useState } from "react";
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

type ProductModalProps = {
  isOpen: boolean;
  setIsModalOpen: Dispatch<SetStateAction<boolean>>;
};

const ProductModal = (props: ProductModalProps) => {
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
              props.setIsModalOpen(false);
              setIsLoading(false);
              form.resetFields();
              notification.success({message: "Create product succeeded"});
            })
            .catch((error) => {
              notification.error({message: "Something went wrong"});
              throw new Error(error);
            });
        });
    });
  };

  const uploadImageFunc = (imageList: UploadFile[], slugString: string) =>
    new Promise<string[]>((resolve, reject) => {
      const formData = new FormData();
      imageList.forEach((item: UploadFile, index: number) => {
        formData.append(
          "file",
          item?.originFileObj,
          `${slugString}-${index + 1}.${item?.originFileObj.type.split("/")[1]}`
        );
      });
      let URLs: string[] = [];
      uploadImage(formData)
        .then(({ data }) => {
          URLs = data.map((item: UploadResponse) => item.url);
          return resolve(URLs);
        })
        .catch((error) => {
          console.log(error);
          return reject(error);
        });
    });

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
      <Spin spinning={isLoading}>
        <ProductCreateForm setImageList={setImageList} form={form} />
      </Spin>
    </Modal>
  );
};

export default ProductModal;
