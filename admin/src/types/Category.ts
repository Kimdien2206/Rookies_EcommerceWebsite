import { Product } from "./Product"

export type Category = {
    id: string,
    name: string, 
    description: string,
    products: Product[]
}

export type CategoryCreateDto = {
    name: string, 
    description: string,
}

export type CategoryUpdateDto = {
    name: string, 
    description: string,
}