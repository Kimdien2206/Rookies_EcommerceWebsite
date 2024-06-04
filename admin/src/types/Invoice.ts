import { Variant } from "./Product"


export type Invoice = {
    id: string, 
    name: string,
    email: string,
    phoneNumber: string, 
    address: string,
    totalCost: number
    createdDate: Date,
    status: string,
    invoiceVariants: InvoiceVariant[]
}

export type InvoiceVariant = {
    invoiceId: string,
    variantId: string,
    Variant: Variant,
    price: number,
    amount: number,
    totalCost: number
}