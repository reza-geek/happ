import { NgModule } from '@angular/core';
//import { MaterialModule } from  'src/app/shared/material.module';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { UserComponent } from './models/user/user.component';
import { HomeComponent } from './home/home.component';
import { NgPersianDatepickerModule } from 'ng-persian-datepicker';
import { NgxPaginationModule } from 'ngx-pagination';
import { ReactiveFormsModule } from '@angular/forms';
import { UnauthorizedPageComponent } from './ErrorPages/unauthorized-page/unauthorized-page.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './auth/token.interceptor'; 
import { AuthService } from './auth/auth.service'; 
import { HeadersSender } from './auth/headers-sender';
//import { AuthInterceptor } from '../auth/auth.interceptor';

 @NgModule({
  declarations: [ 
    AppComponent,  
   // HomeComponent,
    UserComponent, 
    UnauthorizedPageComponent ,      
  ],
  imports: [
    FormsModule, 
    BrowserModule,
    NgPersianDatepickerModule,
    NgxPaginationModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: "toast-center-center",
      preventDuplicates: true,
      enableHtml: true,
    }),
    ReactiveFormsModule,
    HttpClientModule,  
    RouterModule.forRoot(
      [ { path: '', component: UserComponent,  }     ,
        { path: '401', component: UnauthorizedPageComponent  },
      //  { path: 'admin', component: HomeComponent } ,
        {  path: 'admin',
        loadChildren: () =>
          import("./home/admin-panel.module").then(
            (m) => m.AdminPanelModule
          ),
       data: { controller: "home" },
       } ,       
                      
     ])   
     ,
     
     
  ],
  providers: [
    
    { provide: HTTP_INTERCEPTORS, useClass: HeadersSender, multi: true },
  // AuthService,{
  //   provide: HTTP_INTERCEPTORS,
  //   useClass: TokenInterceptor,
  //   multi: true
  // }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  
}
