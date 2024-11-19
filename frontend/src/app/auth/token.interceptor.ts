import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
  HttpInterceptor
} from '@angular/common/http';
import { AuthService } from './auth.service';
import { Observable, catchError, throwError } from 'rxjs';
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(public authService: AuthService) {} 
 intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {  
  debugger
    const token = this.authService.getToken();

   if (token) {
     // If we have a token, we set it to the header
     request = request.clone({  setHeaders: {Authorization: 'Bearer ${token}'}      });

  }
  debugger
  return next.handle(request).pipe(

  	catchError((err) => {
   	 if (err instanceof HttpErrorResponse) 
     {
        alert(err.status);
       	 if (err.status === 401) 
         {
       	 // redirect user to the logout page
         alert('error 401');
     	}
 	 }
  	return throwError(err);
	})
   )
  }
}