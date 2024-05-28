import { http } from ".";
import { CategoryCreateDto } from "../types/Category";


export const createCategory = (newCategory: CategoryCreateDto) => { 
    return http.post("/category", newCategory);
}

export const deleteCategory = (categoryId: string) => { 
    return http.delete(`/category/${categoryId}`);
}