import { Component, OnInit } from '@angular/core';
import { PatientComponent } from '../patient/patient.component';
@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent  {

  constructor(private patient: PatientComponent) {  
    }

  // get current(): number {    
  //   return this.patient.pagination.CurrentPage;
  // }

  get pages(): number[] {
    if (this.patient.patients != null) 
    {     
      // this.a = Array(
      //   Math.ceil(this.patient.patients.length / this.patient.pagination.ItemPerPage)
      // ).fill(0)
      //   .map((x, i) => i + 1);
      this.a = Array(
        Math.ceil(this.patient.patients.length / 10)
      ).fill(0)
        .map((x, i) => i + 1);  
        return this.a;
    }
    
    else {
      return [];
    }
  }
  a !:  number[] ;
  changePages(newPage : number) {
    debugger;
     //this.patient.pagination.CurrentPage  = newPage;
     
     //this.patient.SetPaging(newPage);
  }
}
