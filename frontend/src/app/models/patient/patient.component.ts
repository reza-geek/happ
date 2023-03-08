import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Patient } from './Patient';
import { Pagination } from './../Pagination/Pagination';
import { PaginationComponent } from './../Pagination/pagination.component';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent   {
  
  private paginationObj =new Pagination();
  constructor(private http: HttpClient,private router:RouterModule){
    
   this.GetPatientList();
     
     
    //  this.http.get<any>('/api/Patient/GetPatientByID/42006').subscribe(    
    //   x => {  this.o_patient = x ; } ,error => console.error(error)  );
     
  }
  // constructor(private http: HttpClient,private router: RouterModule) {

  //   this.http.get<Patient[]>("/api/Part/GetPart").
  //   subscribe(x => { this.part = x; }, error => console.error(error) );
    //returns list by ID
    // this.http.get<any>('/api/Part/GetPartById/4').subscribe(    x => {  this.part = x ; } ,error => console.error(error)  );
    GetPatientList(): void {
    
    this.http.get<Patient[]>('/api/Patient/GetPatient').subscribe(
      p => {
        this.o_patients = p;
        this.paginationObj.CurrentPage =1;      
        this.SetPaging( this.paginationObj.CurrentPage); 
      },
      error =>{ console.error(error)}
      );  
        
  }
  SetPaging( page_num :number): void { 
    if(this.o_patients.length >1 && this.o_patients != null)
    {   debugger        
      let pageIndex = (page_num-1) * 10;
      this.o_patient =this.o_patients.slice(pageIndex , pageIndex + 10); 
    }
  }
  GetPatientByName(I_Name : string): void {
    debugger
    this.http.get<Patient[]>('/api/Patient/GetPatientByName?I_Name='+I_Name ).
    subscribe(p => {this.o_patient = p;},
      error =>{ console.error(error)});
  }
    
  o_patients : Patient[]=[];
  o_patient : Patient[]=[];
  
  get pagination() :Pagination {
    return this.paginationObj;
  }

  get patients() :Patient[] {
    return this.o_patients;
  }

  get patient() :Patient[] {
    return this.o_patient;
  }
}
