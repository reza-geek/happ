import { HttpRequest } from '@angular/common/http';
// ...
// export class AuthService {
// cachedRequests: Array<HttpRequest<any>> = [];
// public collectFailedRequest(request: HttpRequest<any>): void {
//     this.cachedRequests.push(request);
//   }
// public retryFailedRequests(): void {
//     // retry the requests. this method can
//     // be called after the token is refreshed
//   }
// }

import { Injectable } from '@angular/core';
//import decode from 'jwt-decode';
@Injectable()
export class AuthService {

  public getToken(): string {
    let auth_token = localStorage.getItem('User');
     if (auth_token != null) {
      alert(auth_token);
        return auth_token;
    }
    else
    return '';
  }

  public isAuthenticated(): boolean {
    // get the token
    const token = this.getToken();
    // return a boolean reflecting 
    // whether or not the token is expired
    return true
    //tokenNotExpired(null, token);
  }
}