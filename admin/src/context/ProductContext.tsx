import { createContext, ReactNode, useState } from "react";
import { Product } from "../types/Product";

export const ProductContext = createContext<ProductContextProps | undefined>(undefined);

type ProductProviderProps = {
  children: ReactNode;
}

type ProductContextProps = {
  product: Product | undefined;
  setProduct: React.Dispatch<React.SetStateAction<Product | undefined>>;
}

export const ProductProvider = ({ children }: ProductProviderProps) => {
  const [product, setProduct] = useState<Product>();

  return (
    <ProductContext.Provider
      value={{
        product,
        setProduct,
      }}
    >
      {children}
    </ProductContext.Provider>
  );
};
