
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { ProductDiscountService } from './product-discount.service';
import { ProductWithDiscount } from '../models/productWithDiscount';
import { BasketItem } from '../models/basketItem';
import { BasketService } from './basket.service';
import { Basket } from '../models/basket';
import { nonEmptyArrayValidator } from '../shared/NonEmptyArrayValidator';
import { Receipt } from '../models/receipt';
import { Router} from '@angular/router';
import { ReceiptStateService } from './receipt-state.service';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss'
})
export class ProductListComponent implements OnInit {

  productsWithDiscounts: ProductWithDiscount[] = [];
  loading: boolean = true;
  error: string = '';
  basketForm: FormGroup;
  submissionStatus: string = '';
  receipt: Receipt | null = null;

  receiptState = inject(ReceiptStateService);
  productDiscountService = inject(ProductDiscountService);
  basketService = inject(BasketService);

  router = inject(Router);
  fb = inject(FormBuilder);

  constructor(
    //private fb: FormBuilder,

  ) {
    this.basketForm = this.fb.group({
      basketItems: this.fb.array([],nonEmptyArrayValidator())
    });
  }



  ngOnInit(): void {
    this.productDiscountService.getProductsWithDiscounts().subscribe({
      next: (data) => {
        this.productsWithDiscounts = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load products';
        alert('Failed to load products');
        this.loading = false;
      }
    });
  }



  trackByFn(index: any, item: any) {
    return index;
  }

  deleteItem(position: any) {
    const ctrl = this.basketForm.controls.basketItems as FormArray;
    ctrl.removeAt(position);
  }

  get basketItems(): FormArray {
    return this.basketForm.get('basketItems') as FormArray;
  }

  addToBasket(productWithDiscount: ProductWithDiscount) {
    const basketItemsArray = this.basketItems;
    const existingItemIndex = basketItemsArray.controls.findIndex(control => control.value.productId === productWithDiscount.product.id);

    if (existingItemIndex !== -1) {
      const existingItem = basketItemsArray.controls[existingItemIndex];
      const currentQuantity = existingItem.value.quantity;
      existingItem.patchValue({ quantity: currentQuantity + 1 });
    } else {
      const newBasketItem: BasketItem = {
        productId: productWithDiscount.product.id,
        productName: productWithDiscount.product.name,
        productPrice: productWithDiscount.product.price,
        discountId: productWithDiscount.discount?.id || null,
        quantity: 1
      };

      const basketItemFormGroup = this.fb.group({
        productId: [newBasketItem.productId, Validators.required],
        productName: [newBasketItem.productName, Validators.required],
        productPrice: [newBasketItem.productPrice, Validators.required],
        discountId: [newBasketItem.discountId],
        quantity: [newBasketItem.quantity, [Validators.required, Validators.min(1)]]
      });

      basketItemsArray.push(basketItemFormGroup);
    }
  }


  onSubmit() {
    const basket :Basket = new Basket(this.basketForm.value.basketItems as BasketItem[], undefined as 'userId');
    this.basketService.submitBasket(basket).subscribe({
      next: (response) => {
        this.receiptState.addReceipt(response);
        this.submissionStatus = 'Basket successfully submitted!';
        this.basketForm.reset();
        this.basketItems.clear();
        this.onNavigate();
      },
      error: () => {
        this.submissionStatus = 'Failed to submit basket. Please try again.';
        alert(this.submissionStatus);
      }
    });
  }

  onNavigate(): void {
    this.router.navigate(['/receipt']);
  }


  readonly imageUrlPrefix: string = 'assets/products/';
  getImageUrl(imagePath: string): string {
    return `${this.imageUrlPrefix}${imagePath}`;
  }

}
