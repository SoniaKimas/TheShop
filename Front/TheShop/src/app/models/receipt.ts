import { ReceiptItem } from "./receipt-item";

export interface Receipt {
  totalPrice: number;
  id: number;
  registrationDate: Date;
  items: ReceiptItem[];
  customerName: string;
}
