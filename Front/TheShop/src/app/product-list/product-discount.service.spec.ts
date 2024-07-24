/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProductDiscountService } from './product-discount.service';

describe('Service: ProductDiscount', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProductDiscountService]
    });
  });

  it('should ...', inject([ProductDiscountService], (service: ProductDiscountService) => {
    expect(service).toBeTruthy();
  }));
});
