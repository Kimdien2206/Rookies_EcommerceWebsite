/* eslint-disable @typescript-eslint/no-unused-vars */
import { Modal, Spin, UploadFile, notification } from "antd";
import React, {
  Dispatch,
  FC,
  SetStateAction,
  useContext,
  useState,
} from "react";
import { useForm } from "antd/es/form/Form";
import {
  ProductFormType,
  ProductUpdateDto,
} from "../../types/Product";
import slugify from "slugify";
import {
  deleteImage,
  updateProduct,
} from "../../api/ProductAPI";
import { mutate } from "swr";
import ProductEditForm from "../Forms/ProductEditForm";
import { ProductContext } from "../../context/ProductContext";
import { uploadImageFunc } from "../../helper/utils";
import { PRODUCT_KEY } from "../../constant/apiKey";

type ProductEditModalProps = {
  isOpen: boolean;
  setIsModalOpen: Dispatch<SetStateAction<boolean>>;
};

const ProductEditModal: FC<ProductEditModalProps> = ({
  isOpen,
  setIsModalOpen,
}) => {
  const [imageList, setImageList] = useState<UploadFile[]>([]);
  const [form] = useForm<ProductFormType>();
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const { product } = useContext(ProductContext);

  const handleOKModal = () => {
    // setIsLoading(true);
    form.validateFields().then((data) => {
      console.log(product);
      const slugString = slugify(data.name);

      console.log(imageList)
      imageList &&
        uploadImageFunc(imageList, slugString).then((URLs) => {
          const newProduct: ProductUpdateDto = {
            name: data.name,
            slug: slugString,
            price: data.price,
            description: data.description,
            categoryId: data.category,
            images: URLs ? [...product.images, ...URLs] : [...product.images],
          };
          updateProduct(product.id, newProduct)
            .then(() => {
              mutate(PRODUCT_KEY);
              setIsModalOpen(false);
              setIsLoading(false);
              form.resetFields();
              notification.success({ message: "Update product succeeded" });
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
      title={"Edit new product"}
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
        <ProductEditForm setImageList={setImageList} form={form} />
      </Spin>
    </Modal>
  );
};

export default ProductEditModal;
