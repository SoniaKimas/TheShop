import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Basket } from '../models/basket';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  private baseURL = environment.apiURL + 'basket';

  constructor(private http: HttpClient) { }

  submitBasket(basketItems: Basket): Observable<any> {
    return this.http
      .post<any>(
        this.baseURL,
        basketItems
      );
  }
}
