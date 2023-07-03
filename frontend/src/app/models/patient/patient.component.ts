import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Patient } from './Patient';
import { ToastrService } from 'ngx-toastr';
import { Pagination } from './../Pagination/Pagination';
import { PaginationComponent } from './../Pagination/pagination.component';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent   {
  //tutorials: Tutorial[] = [];
  //currentTutorial: Tutorial = {};
  currentIndex = 1;
  title = '';
  p = 1; 
  count = -1;
  pageSize = 10;
  pageSizes = [10,20,30];

  myText ?:string ;
///////////////////////////
getRequestParams(searchTitle: string, page: number, pageSize: number): any {
  let params: any = {};

  if (searchTitle) {
    params['title'] = searchTitle;
  }

  if (page) {
    params['page'] = page - 1;
  }

  if (pageSize) {
    params['size'] = pageSize;
  }

  return params;
}
//-------------------------

retrieveTutorials(): void {
  debugger
  const params = this.getRequestParams(this.title, this.p, this.pageSize);
  
 // this.tutorialService.getAll(params)
 this.http.get<Patient[]>('/api/Patient/GetPatient')
    .subscribe({
      next: (data) => { 
        this.o_patients = data;
        this.count = this.o_patients.length;
        console.log(data);
      },
      error: (err) => {
        console.log(err);
      }
    });
}
//------------------------
handlePageChange(event: number): void {
  debugger
  this.p = event;
  //this.GetPatientList();
}

handlePageSizeChange(event: any): void {
  this.pageSize = event.target.value;
  this.p = 1;
  //this.GetPatientList();
}
///////////////////////////// 
  constructor(private http: HttpClient,private router:RouterModule
    ,private toaster: ToastrService){
    
   this.GetPatientList();
   }
    GetPatientList(): void {
    
    this.http.get<Patient[]>('/api/Patient2').subscribe(
      p => {
        debugger        
        this.o_patients = p;
        this.count = this.o_patients.length;
      },
      error =>{ console.error(error)}
      );  
        
  }
  
  GetPatientByName(  ): void {
    debugger 
    this.http.get<Patient[]>('/api/Patient2/GetByName/'+ this.myText ).
    subscribe(
      p => {this.o_patients = p;
      this.count = this.o_patients.length;},
      error =>{ console.error(error)});
  }
  
  ShowMsg():void  { 
     
    // this.toaster.success("Hello world!", "Toastr fun!");
      this.toaster.error("خطایی رخ داد. لطفا مجدد امتحان کنید");
     // this.toaster.success('Hello world!', 'Toastr fun!')
      
     ;
      //this.location.back();
     // alert("alert خطایی رخ داد. لطفا مجدد امتحان کنید");
     }  
  o_patients : Patient[]=[];
  o_patient : Patient[]=[];
  
   
  get patients() :Patient[] {
    return this.o_patients;
  }

  get patient() :Patient[] {
    return this.o_patient;
  }
}
