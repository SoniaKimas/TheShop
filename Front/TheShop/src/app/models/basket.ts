import { BasketItem } from "./basketItem";

export class Basket {
  basketItems: BasketItem[];
  userId?: string;

  constructor(basketItems: BasketItem[], userId?: string) {
    this.basketItems = basketItems;
    this.userId = userId;
  }
}
