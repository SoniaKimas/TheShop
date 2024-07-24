export class BasketItem {
  productId: string;
  productName: string;
  productPrice: number;
  discountId?: number;
  quantity: number = 1;

  constructor(
      productId: string,
      productName: string,
      productPrice: number,
      discountId?: number,
      quantity?: number
  ) {
      this.productId = productId;
      this.productName = productName;
      this.productPrice = productPrice;
      if (discountId !== undefined) {
          this.discountId = discountId;
      }
      if (quantity !== undefined) {
          this.quantity = quantity;
      }
  }
}
