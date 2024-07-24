import { Injectable } from '@angular/core';
import { Receipt } from '../models/receipt';

@Injectable({
  providedIn: 'root'
})
export class ReceiptStateService {

  hasReceipt: boolean = false;
  receipt: Receipt | null = null;

  constructor() { }

  addReceipt(receipt: Receipt) {
    this.receipt = receipt;
    this.hasReceipt = true;
  }

}
