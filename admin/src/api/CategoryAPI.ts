import { http } from ".";
import { CategoryCreateDto, CategoryUpdateDto } from "../types/Category";


export const createCategory = (newCategory: CategoryCreateDto) => { 
    return http.post("/category", newCategory);
}

export const deleteCategory = (categoryId: string) => { 
    return http.delete(`/category/${categoryId}`);
}

export const updateCategory = (categoryId: string, newCategoryInfo: CategoryUpdateDto) => { 
    return http.patch(`/category/${categoryId}`, newCategoryInfo);
}