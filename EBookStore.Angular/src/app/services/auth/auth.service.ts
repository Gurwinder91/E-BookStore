import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

import { NotificationService } from '../notification/notification.service';
import { URLS } from '../../configuration/url.config';
import { User } from '../../models';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient
  ) { }

  /**
   * @description user login Request
   * @param user
   */
  login(user: User): Observable<any> {
    
    const authHeaders = new HttpHeaders({
      'NO_Auth': 'TRUE'
    });

    return this.http.post<any>(URLS.token, user, { headers: authHeaders }).pipe(
      tap((response) => {
        sessionStorage.setItem('userToken', response.token);
      })
      );
  }


  /**
   * @description logout user by removing token from local storage
   */
  logout() {
    sessionStorage.removeItem('userToken');
  }

  /**
   * @description whether user is logged in to system or not
   */
  isLoggedIn(): boolean {
    return !!sessionStorage.getItem('userToken');
  }

  /**
   * get user token from localstorage
   */
  get token(): string {
    return sessionStorage.getItem('userToken');
  }

  /**
  * get user token from localstorage with bearer appended infront of it
  */
  get tokenWithBearer(): string {
    return `Bearer ${this.token}`;
  }

}
