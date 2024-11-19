import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';


@Injectable()
export class HeadersSender implements HttpInterceptor {
  intercept(httpRequest: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    debugger
    const token = localStorage.getItem('User');
     var reqCopy = httpRequest.clone()
     
     const headers = httpRequest.headers.set('Authorization','Bearer '+token);
    
    // return next.handle(reqCopy.clone({ headers }));
     //can set new header
      // reqCopy.headers.set('Authorization', 'Bearer ${token}');
      // reqCopy.headers.append('Content-Type', 'application/json');
    
     return next.handle(
        httpRequest.clone(
          { 
            headers
          }
          )
        ).pipe(
                catchError((err) => {
                  if (err instanceof HttpErrorResponse) 
                {                    
                      if (err.status === 401) 
                    {
                      // redirect user to the logout page
                    alert(err.message +'\n' + err.headers.get('Authorization'));
                  }
                }
                return throwError(err);
              })
     );
    // 
    // const token = localStorage.getItem('User');
    // if (token) {
    //   request = request.clone({
    //     setHeaders: {
    //       Authorization: 'Bearer ${token}'
    //     }
    //   });
     
    
  //   return next.handle(reqCopy).pipe(

  // 	catchError((err) => {
  //  	 if (err instanceof HttpErrorResponse) 
  //    {
  //       alert(err.status);
  //      	 if (err.status === 401) 
  //        {
  //      	 // redirect user to the logout page
  //        alert('error 401');
  //    	}
 	//  }
  // 	return throwError(err);
	// })
  //  )
  }
}
