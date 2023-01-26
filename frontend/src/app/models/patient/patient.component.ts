import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Patient } from './Patient';
@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {
  o_patient : Patient[]=[];
  
  constructor(private http: HttpClient,private router:RouterModule){
   debugger;  
   this.http.get<any>('/api/Patient/GetPatient').subscribe(p => {this.o_patient = p;},
      error =>{ console.error(error)});
     
     
    //  this.http.get<any>('/api/Patient/GetPatientByID/42006').subscribe(    
    //   x => {  this.o_patient = x ; } ,error => console.error(error)  );
     
  }
  // constructor(private http: HttpClient,private router: RouterModule) {

  //   this.http.get<Patient[]>("/api/Part/GetPart").
  //   subscribe(x => { this.part = x; }, error => console.error(error) );
    //returns list by ID
    // this.http.get<any>('/api/Part/GetPartById/4').subscribe(    x => {  this.part = x ; } ,error => console.error(error)  );

  ngOnInit(): void {
  }

}
