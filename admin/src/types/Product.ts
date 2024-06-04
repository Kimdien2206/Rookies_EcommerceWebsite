export type Product = {
    id: string,
    name: string
    description: string
    images: string[]
    slug: string
    price: number
    categoryId: string
    created_date: string
}

export type ProductCreateDto = {
    name: string
    description: string
    images?: string[]
    slug: string
    price: number
    categoryId: string
    variants: Variant[]
}

export type ProductUpdateDto = {
    name: string
    description: string
    images?: string[]
    slug: string
    price: number
    categoryId: string
}

export type ProductFormType = {
    name: string
    description: string
    images?: FileList
    slug: string
    price: number
    category: string
    variants: Variant[]
}

export type Variant = {
    name: string
    stock: number
}