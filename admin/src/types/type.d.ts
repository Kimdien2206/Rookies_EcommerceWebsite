type ProductState = {
  selectedProduct: Product;
};

type ProductAction = {
  type: string;
  product: Product;
};

type DispatchType = (args: ProductAction) => ProductAction;
