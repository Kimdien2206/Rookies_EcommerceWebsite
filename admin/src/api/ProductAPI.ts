import { http } from "."
import { ProductCreateDto } from "../types/Product";


export const uploadImage = (formFile: FormData) => {
    return http.post("/image", formFile);
}
export const createProduct = (data: ProductCreateDto) => {
    return http.post("/Product", data);
}

