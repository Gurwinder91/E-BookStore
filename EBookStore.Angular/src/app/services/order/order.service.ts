import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Order } from '../../models';
import { URLS } from '../../configuration/url.config';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  fetchAll(): Observable<Order[]> {
    return this.http.get<Order[]>(URLS.orders);
  }
}
