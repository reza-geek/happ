import { NgModule } from '@angular/core';
//import { MaterialModule } from  'src/app/shared/material.module';
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
 
//import { MaterialPersianDateAdapter } from '../material.persian-date.adapter/material.persian-date.adapter.component';
import { NgPersianDatepickerModule } from 'ng-persian-datepicker';
import { ReactiveFormsModule } from '@angular/forms';
import { AdminPanelRoutingModule } from './admin-panel-routing.module';


 @NgModule({
  declarations: [ 
    
    PartComponent,
    HomeComponent,
    TestComponent,
    SideBarComponent,
    MainContentComponent,
    NavbarComponent,
    FooterComponent, 
    PartDetailComponent, PatientComponent, DoctorComponent, CatheterComponent, ClearanceComponent,
    EventComponent, ReceptionComponent, CatheterisationComponent, CatheterEjectComponent,
    CatheterEventComponent,  PatientDetailComponent, PaginationComponent
    
  ],
  imports: [
    //
    FormsModule, 
    NgPersianDatepickerModule,
    ReactiveFormsModule,
    HttpClientModule,  
    AdminPanelRoutingModule,    
     CommonModule
  ],
  providers: [],
  
})
export class AdminPanelModule {
  
}
