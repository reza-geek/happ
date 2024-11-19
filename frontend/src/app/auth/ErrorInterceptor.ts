import { Observable, throwError } from "rxjs";
import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from "@angular/common/http";

import { Injectable } from "@angular/core";
import { catchError } from "rxjs/operators";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((err: HttpErrorResponse) => {
        if (err.status === 401) {
          if (location.pathname.indexOf("admin") == -1) {
            localStorage.removeItem("sh-token");
            if (location.pathname != "/") location.href = "/";
          }
        }
        return throwError(err);
      })
    );
  }
}
