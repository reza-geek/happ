import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
// import { AppComponent } from '../app.component';
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
import { UserComponent } from '../models/user/user.component';
import { CatheterEventComponent } from '../models/catheter-event/catheter-event.component';
import { PatientDetailComponent } from '../models/patient/patient_detail/patient-detail.component';
import { PaginationComponent } from '../models/Pagination/pagination.component';
//import { MaterialPersianDateAdapter } from '../material.persian-date.adapter/material.persian-date.adapter.component';
//import { PartDetailComponent } from '../models/part/part-detail/part-detail.component';
import { NgPersianDatepickerModule } from 'ng-persian-datepicker';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
 const routes: Routes =
 [
    
    {
        path: "",component: HomeComponent,
     // canActivate: [RouteCheckerGuard],
    children: [
    //   {
    //     path: "index",
    //     component: DashboardWidgetsComponent,
    // //    canActivate: [RouteCheckerGuard],
    //   }
      { path: 'part-detail/:id', component: PartDetailComponent } ,
      { path: 'part-detail', component: PartDetailComponent } ,
      { path: 'part', component: PartComponent } ,
      { path: 'patient', component: PatientComponent }   ,
      { path: 'patient-detail', component: PatientDetailComponent }   ,
      { path: 'patient-detail/:id', component: PatientDetailComponent }   ,
      { path: 'GetPatientByID/:id', component: PatientComponent },
    ],
    },
    {
    path: "**",
    redirectTo: "",
  },
];

@NgModule({
    imports: [ RouterModule.forChild(routes)],
    exports: [RouterModule],
  })
  export class AdminPanelRoutingModule { }