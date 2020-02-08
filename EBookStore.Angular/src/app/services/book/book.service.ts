import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { URLS } from '../../configuration/url.config';
import { Book, BookDetails } from '../../models';
import { Identifiers } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  fetchAll(): Observable<Book[]> {
    return this.http.get<Book[]>(URLS.books);
  }

  fetchSpecificBook(id: number): Observable<BookDetails> {
    return this.http.get<BookDetails>(`${URLS.specificBook}${id}`);
  }

  purchaseBook(bookId: number): Observable<any> {
    const model= {
      bookId: bookId,
      paymentMode: 'card'
    }
    return this.http.post<any>(URLS.purchaseBook, model);
  }
}
