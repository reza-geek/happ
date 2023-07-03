import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router  } from '@angular/router';
import { RouterModule } from '@angular/router';
import { User } from './User';
import { Exception } from 'sass';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlerService } from '../../shared/Services/error-handler.service'

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  
  o_user !: User;
  authResponseDto !:  AuthResponseDto;
  errorMessage: string = '';
  error = "";
  constructor(private http : HttpClient,private actRoute: ActivatedRoute,private router:Router
   //, private errorHandler: ErrorHandlerService
    ) { this.o_user =new User(); }

  
  ngOnInit(): void {
    debugger
      this.o_user =new User();
  }

  Login(o_user : User) {  
    
    this.http.post<AuthResponseDto>('/api/User/Login', o_user).subscribe(     
      p => {
            this.authResponseDto = p;             
       
            if ( this.authResponseDto != undefined &&
              this.authResponseDto.Token != undefined &&
              this.authResponseDto.UserFullName != undefined &&
              this.authResponseDto.IsAuthSuccessful == true)
            {
              localStorage.setItem('User', this.authResponseDto.Token );          
              localStorage.setItem('UserFullName' ,this.authResponseDto.UserFullName );
              this.router.navigate(["/admin"]);
            }
            else
            {  
              alert(this.authResponseDto.ErrorMessage); 
            }
       },
      //  (error: HttpErrorResponse)=>{
      //   this.errorHandler.handleError(error);
      //   this.errorMessage = this.errorHandler.errorMessage;
      // }
      (error) => {
        // if (error.statusText == "Please enter captcha") {
        //   this.error = "عبارت امنیتی اشتباه است";
          
        // }
        // else 
        if (error.status === 401) {
          this.error = "نام کاربری و رمز عبور اشتباه است";
          
        } else {
          this.error = "ارتباط با سرور برقرار نشد";
        }
      }
      );
                    
  }  
}

class AuthResponseDto
    {
      IsAuthSuccessful ?: boolean ;
      ErrorMessage ?:  string  ;
      Token  ?: string ;
      UserFullName ? : string ;
    }
