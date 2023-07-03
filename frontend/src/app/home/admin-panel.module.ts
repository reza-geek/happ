import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common'
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router'; 
import { UserComponent } from '../models/user/user.component';
import { PartComponent } from '../models/part/part.component';
import { HomeComponent } from '../home/home.component';
import { TestComponent } from '../models/test/test.component';
import { SideBarComponent } from '../side-bar/side-bar.component';
import { MainContentComponent } from '../main-content/main-content.component';
import { NavbarComponent } from '../navbar/navbar.component';
import { FooterComponent } from '../footer/footer.component';
import { PartDetailComponent } from '../models/part/part-detail/part-detail.component';
import { PatientComponent } from '../models/patient/patient.component';
import { DoctorComponent } from '../models/doctor/doctor.component';
import { CatheterComponent } from '../models/catheter/catheter.component';
import { ClearanceComponent } from '../models/clearance/clearance.component';
import { EventComponent } from '../models/event/event.component';
import { ReceptionComponent } from '../models/reception/reception.component';
import { CatheterisationComponent } from '../models/catheterisation/catheterisation.component';
import { CatheterEjectComponent } from '../models/catheter-eject/catheter-eject.component';
import { CatheterEventComponent } from '../models/catheter-event/catheter-event.component';
import { PatientDetailComponent } from '../models/patient/patient_detail/patient-detail.component';
import { PaginationComponent } from '../models/Pagination/pagination.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgPersianDatepickerModule } from 'ng-persian-datepicker';
import { ReactiveFormsModule } from '@angular/forms';
import { AdminPanelRoutingModule } from './admin-panel-routing.module';
import { ConfirmationService } from "primeng/api";
import { ConfirmDialogModule } from "primeng/confirmdialog";
import { DialogModule } from "primeng/dialog";
import { ButtonModule } from 'primeng/button';
import { HeadersSender } from '../auth/headers-sender';
import { HTTP_INTERCEPTORS } from '@angular/common/http';


// import { HTTP_INTERCEPTORS } from '@angular/common/http';
// import { TokenInterceptor } from '../auth/token.interceptor'; 
// import { AuthService } from '../auth/auth.service'; 
 @NgModule({
  declarations: [ 
    
    PartComponent,
    HomeComponent,
    TestComponent,
    SideBarComponent,
    MainContentComponent,
    NavbarComponent,
    FooterComponent, 
    PartDetailComponent, 
    PatientComponent, 
    DoctorComponent, 
    CatheterComponent, 
    ClearanceComponent,
    EventComponent, 
    ReceptionComponent, 
    CatheterisationComponent, 
    CatheterEjectComponent,
    CatheterEventComponent,  
    PatientDetailComponent, 
    PaginationComponent
  ],
  imports: [
    //
    FormsModule, 
    NgPersianDatepickerModule,
    NgxPaginationModule, 
    ReactiveFormsModule,
    HttpClientModule,  
    AdminPanelRoutingModule,    
    CommonModule,    
    ConfirmDialogModule,
    DialogModule,
    ButtonModule,
  ],
  providers:[ 
    
    { provide: HTTP_INTERCEPTORS, useClass: HeadersSender, multi: true },
    // AuthService,{
    //   provide: HTTP_INTERCEPTORS,
    //   useClass: TokenInterceptor,
    //   multi: true
    // },
    { provide: ConfirmationService, useClass: ConfirmationService }]
  
})
export class AdminPanelModule {
  
}
