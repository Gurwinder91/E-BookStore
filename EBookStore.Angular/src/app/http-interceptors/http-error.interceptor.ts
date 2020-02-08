import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { NotificationService } from '../services/notification/notification.service';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor(public notificationService: NotificationService, public router: Router) { }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {

    return next.handle(req)
      .pipe(catchError((error: HttpErrorResponse) => {
        // intercept the response error and displace it to the console
        if (error instanceof HttpErrorResponse) {
          this.handleHttpError(error);
        }
        return throwError(error);
      }));
  }

  /**
   * @description Handing Http Errors
   * @param err
   */
  private handleHttpError(err: HttpErrorResponse): void {
    switch (err.status) {
      case 400:
        this.notificationService.notify(err.error);
        break;
      case 401:
        localStorage.removeItem('userToken')
        this.router.navigate(['/login']);
        break;
      default:
        const message = err.error.message ? err.error.message : 'Something went wrong';
        this.notificationService.notify(message);
        break;
    }
  }
}

