import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router  } from '@angular/router';
import { Exception } from 'sass';
import { Patient} from './../Patient';
import { Location } from '@angular/common';
import { IActiveDate } from 'ng-persian-datepicker';
import moment from 'jalali-moment';
import { FormControl } from '@angular/forms';
import { IDatepickerTheme    } from 'ng-persian-datepicker';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-patient-detail',
  templateUrl: './patient-detail.component.html',
  styleUrls: ['./patient-detail.component.css']
})
export class PatientDetailComponent implements OnInit {

  dateValue = new FormControl();
  constructor(
    private http: HttpClient,
    private actRoute: ActivatedRoute,
    private router:Router,
    private location:Location
    ,private toaster: ToastrService
    ) { }
    
  op_edit : Boolean =false;
  v_patient !:Patient;
  gender = ["زن"  ,"مرد"];
  
  onSelect(event: IActiveDate): void {
    const viaTimestampValue = new Date(event.timestamp);
    const viaGregorianDate = new Date(event.gregorian);
  }
  ngOnInit(): void {
    // debugger
    this.actRoute.paramMap.subscribe(
      (param) => {
        //اینو اول باید داشته باشی بعد یا پرکنی یا خالی بمونه برای جدید 
        
        this.v_patient=new Patient(); 
        var id = Number(param.get('id'));
        if(id != 0)
        {                  
          this.getById(id);
          this.op_edit = true; 
        }
      }
    );

  }
   
  getById(id : Number)
  {
    this.http.get<Patient>('/api/Patient/GetPatientById/'+ id).subscribe(
      data => { this.v_patient = data; }
    )
    
  }

  gotoList():void  { 
    this.router.navigate(['./admin/patient'])
   //this.location.back();
  }
ShowMsg():void  { 
  this.toaster.error("خطایی رخ داد. لطفا مجدد امتحان کنید");
   //this.location.back();
  }
  createOrReplace(patient: Patient) {
    debugger
    if(this.op_edit)
    {
      this.update(patient);
    }
    else
    {
      this.create(patient);
    }         
  }

  create(patient:Patient) {
    
    this.http.post<Patient>('/api/Patient/CreatePatient', patient).subscribe(
      (data)=>{
        alert("Patient Created Successfully!");
        console.log(data);
        this.v_patient=new Patient();
        this.gotoList();
      },
      (error:Exception)=>{
        console.log(error.message);
      }
    );
  }

  update(patient:Patient){
    debugger;
    this.http.put('/api/Patient/UpdatePatient', patient).subscribe(
      (data)=>{
        alert("Update Done");
        console.log(data);
        this.gotoList();
      },
      (error:Exception)=>{
        console.log(error.message);
      }
    );
   }
}
