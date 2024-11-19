import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router  } from '@angular/router';
import { Exception } from 'sass';
import { ToastrService } from 'ngx-toastr';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';


//import {MatDatepickerModulePersian} from '@angular-persian/material-date-picker';

@Component({
  selector: 'app-part-detail',
  templateUrl: './part-detail.component.html',
  styleUrls: ['./part-detail.component.css']
})
export class PartDetailComponent implements OnInit {

  form: FormGroup = new FormGroup({
    part_Name: new FormControl(''),
    Comment: new FormControl(''),
    // email: new FormControl(''),
    // password: new FormControl(''),
    // confirmPassword: new FormControl(''),
    acceptTerms: new FormControl(false),
  });
  submitted = false;
  //////////////////////////////
  v_part: Part = {
    Part_Name: '',
    Part_ID: 0,
    Comment: '',
  };

  new_part :    Part = {
    Part_Name: '',
    Part_ID: 0,
    Comment: '',
  };
  parts :Part[] = [];
  public error: any;
  id!: number;
  op_edit!: boolean;

  constructor(private formBuilder: FormBuilder,private http: HttpClient, private actRoute: ActivatedRoute, private router: Router,
    private toaster: ToastrService) { }
  // this.id = this.actRoute.snapshot.params['id'];
  // this.http.get<Part>('/api/Part/GetPartById2/'+this.id).subscribe(v => { this.v_part = v; });
  // this.http.get<Part[]>("/api/Part/GetPart").
  // subscribe(x => { this.part = x; }, error => console.error(error) );

  //returns list by ID
  // this.http.get<any>('/api/Part/GetPartById/4').subscribe(    x => {  this.part = x ; } ,error => console.error(error)  );


  ngOnInit(): void {
    this.form = this.formBuilder.group(
      {
        part_Name: ['', Validators.required],
        comment: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(20)
          ]
        ],
        // email: ['', [Validators.required, Validators.email]],
        // password: [
        //   '',
        //   [
        //     Validators.required,
        //     Validators.minLength(6),
        //     Validators.maxLength(40)
        //   ]
        // ],
        // confirmPassword: ['', Validators.required],
        // acceptTerms: [false, Validators.requiredTrue]
      }
      // ,
      // {
      //   validators: [Validation.match('password', 'confirmPassword')]
      // }
    );


    this.actRoute.paramMap.subscribe((param) => {
      debugger
      var id = Number(param.get('id'));
      if(id!=0)
      {
        this.getById(id);
        this.v_part=new Part();
        this.op_edit = true;
      }
      
    });
  } 

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }  
  onSubmit():boolean {
     
    this.submitted = true;

    if (this.form.invalid) {
      return  false;
    }

    console.log(JSON.stringify(this.form.value, null, 2));
    return true;
  }  
  gotoList() {
    this.router.navigate(['/admin/part']);
  }
  getById(id: number) {
    this.http.get<Part>('/api/Part/' + id).subscribe(data => { this.v_part = data; });
    debugger;
    ;
  }
  createOrReplace(part: Part) {
    debugger
    if(this.onSubmit()) {
    if(this.op_edit)
    {
      this.update(part);
    }
    else
    {
      this.create(part);
    }
    // let p = new Part {part_Name = 'test',comment = 'test'};
    // this.new_part.part_Name = 'test';
    //  this.new_part.comment = 'test';
     this.http.post<Part>('/api/Part/CreatePart',   this.new_part)
    .subscribe(
      Response =>{ 
        this.new_part = Response;
        this.parts.push(this.new_part);
        this.router.navigate([Response]);
      } 
      );
   
  }
  }
  create(part: Part) {
    
    this.http.post<Part>('/api/Part', part).subscribe(
      (data)=>{        
        debugger
        this.toaster.info("!اطلاعات بخش جدید با موفقیت ثبت شد");
        console.log(data);
        this.v_part=new Part();

        //this.gotoList();
      },
      (error:Exception)=>{
        this.toaster.error(error.message);
        console.log(error.message);
      }
    );
  }
  update(part:Part){
    debugger;
    this.http.put('/api/Part', part).subscribe(
      (data)=>{
        this.toaster.success("!اطلاعات بخش با موفقیت ویرایش شد");
        console.log(data);

      },
      (error:Exception)=>{
        console.log(error.message);
      }
    );
   }
   delete (part : Part){
    debugger;
 
    this.http.delete('/api/Part/'+part.Part_ID ).subscribe(
      (data)=>{
        console.log(data);
        this.gotoList();
      },
      (error:Exception)=>{
        console.log(error.message);
      });
   }
  
}

  class Part {
  Part_Name?: string;
  Part_ID ?: number;
  Comment?: string;
}