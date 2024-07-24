import { Discount } from "./discount";
import { Product } from "./product";

export class ProductWithDiscount {
  product: Product;
  discount?: Discount;

  constructor(product: Product, discount?: Discount) {
    this.product = product;
    this.discount = discount;
  }

}
