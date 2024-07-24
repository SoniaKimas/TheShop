import { Component, inject, OnInit } from '@angular/core';
import { Receipt } from '../../models/receipt';
import { ReceiptStateService } from '../receipt-state.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-receipt',
  templateUrl: './receipt.component.html',
  styleUrls: ['./receipt.component.css']
})
export class ReceiptComponent implements OnInit {

  receipt: Receipt | null = null;

  receiptState =  inject(ReceiptStateService);

  router = inject(Router);

  constructor() { }

  ngOnInit(): void {
    this.receipt = this.receiptState.receipt;
  }

  closeModal(): void {
    this.router.navigate(['/productlist']);
  }

}

