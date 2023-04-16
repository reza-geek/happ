import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {
  public errorMessage: string = '';

  constructor(private router: Router) { }

  public handleError = (error: HttpErrorResponse) =>
    {
      debugger
      if (error.status === 401) {
        this.handle401Error(error)
      }
      else if (error.status === 404) {
        this.handle404Error(error)
      }
      else if (error.status === 500) {
        this.handle500Error(error);
      }
      else {
        this.handleOtherError(error);
      }
    }
///////////////////////////////////////////////////////
  private handle500Error = (error: HttpErrorResponse) => {
    this.createErrorMessage(error);
    this.router.navigate(['/500']);
  }

  private handle404Error = (error: HttpErrorResponse) => {
    this.createErrorMessage(error);
    this.router.navigate(['/404']);
  }

  private handle401Error = (error: HttpErrorResponse) => {
    
    this.createErrorMessage(error);
  //  this.router.navigate(['/401']);
  }

  private handleOtherError = (error: HttpErrorResponse) => {
    this.createErrorMessage(error); //TODO: this will be fixed later; 
  }
  private createErrorMessage = (error: HttpErrorResponse) => {
    this.errorMessage = error.error ? error.error : error.statusText;
  }

}
