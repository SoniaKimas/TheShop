
export interface ReceiptItem {
  productName: string;
  productPrice: number;
  priceAfterDiscount: number;
  itemTotalPrice: number;
  quantity: number;
  discount?: number;
}
