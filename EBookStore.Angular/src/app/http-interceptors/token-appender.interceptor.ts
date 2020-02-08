import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent
} from '@angular/common/http';
import { Observable } from 'rxjs';

import { AuthService } from '../services/auth/auth.service';


@Injectable()
export class TokenAppenderInterceptor implements HttpInterceptor {
  constructor(
    private authService: AuthService
  ) { }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {

    const token = this.authService.tokenWithBearer;
    if (req.headers.has('NO_Auth')) {
      const noAuthReq = req.clone({
        headers: req.headers.delete('NO_Auth')
      });

      return next.handle(noAuthReq);
    }

    const authReq = req.clone({
      headers: req.headers.set('Authorization', token)
    });

    return next.handle(authReq);
  }
}
