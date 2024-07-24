import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { forkJoin, map, Observable } from 'rxjs';
import { Product } from '../models/product';
import { Discount } from '../models/discount';
import { ProductWithDiscount } from '../models/productWithDiscount';

@Injectable({
  providedIn: 'root'
})
export class ProductDiscountService {

  private baseURL = environment.apiURL;

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseURL+'products');
  }

  getDiscounts(): Observable<Discount[]> {
    return this.http.get<Discount[]>(this.baseURL+'discounts');
  }

  getProductsWithDiscounts(): Observable<ProductWithDiscount[]> {
    return forkJoin([this.getProducts(), this.getDiscounts()]).pipe(
      map(([products, discounts]) => {
        return products.map(product => {
          const discount = discounts.find(d => d.productId === product.id);
          return new ProductWithDiscount(product, discount);
        });
      })
    );
  }

}
