import { AppService } from './services/app.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private appService: AppService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    if (this.appService.isLogIn()) {
      let authRequest = request.clone({
        setHeaders: {
          authorization: 'Bearer ' + this.appService.getToken(),
        },
      });

      return next.handle(authRequest);
    }
    return next.handle(request);
  }
}
