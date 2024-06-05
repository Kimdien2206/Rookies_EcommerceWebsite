import { UploadFile } from "antd";
import { uploadImage } from "../api/ProductAPI";
import { UploadResponse } from "../types/UploadImageResponse";

export const uploadImageFunc = (imageList: UploadFile[], slugString: string) =>
  new Promise<string[]>((resolve, reject) => {
    const formData = new FormData();
    let hasFile = false;
    imageList.forEach((item: UploadFile, index: number) => {
      if(item.originFileObj){
        hasFile = true;
        formData.append(
          "file",
          item?.originFileObj,
          `${slugString}-${index + 1}.${item?.originFileObj.type.split("/")[1]}`
        );
      }
    });
    let URLs: string[] = [];
    if(hasFile){
      uploadImage(formData)
        .then(({ data }) => {
          URLs = data.map((item: UploadResponse) => item.url);
          return resolve(URLs);
        })
        .catch((error) => {
          console.log(error);
          return reject(error);
        });
    }
  });
