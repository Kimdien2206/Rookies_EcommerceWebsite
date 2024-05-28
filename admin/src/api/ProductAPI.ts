import { http } from "."
import { ProductCreateDto, ProductUpdateDto } from "../types/Product";


export const uploadImage = (formFile: FormData) => {
    return http.post("/image", formFile);
}

export const createProduct = (data: ProductCreateDto) => {
    return http.post("/Product", data);
}

export const deleteProduct = (productId: string) => { 
    return http.delete(`/product/${productId}`);
}

export const updateProduct = (productId: string, newProductInfo: ProductUpdateDto) => { 
    return http.patch(`/product/${productId}`, newProductInfo);
} 