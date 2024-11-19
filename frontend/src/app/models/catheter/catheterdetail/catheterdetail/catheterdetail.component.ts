import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router  } from '@angular/router';
import { Exception } from 'sass';
import { ToastrService } from 'ngx-toastr';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators  } from '@angular/forms';
 
class Catheter
{
	Catheter_ID  ? : number ;
	Catheter_Name  ? : string;
}

@Component({
  selector: 'app-catheterdetail',
  templateUrl: './catheterdetail.component.html',
  styleUrls: ['./catheterdetail.component.css']
})


export class CatheterdetailComponent implements OnInit {  

  constructor(private formBuilder: FormBuilder,private http: HttpClient, private actRoute: ActivatedRoute, private router: Router,
    private toaster: ToastrService) { }

  
    submitted = false;
    form: FormGroup = new FormGroup(
      {
      event_Name: new FormControl(''),
      acceptTerms: new FormControl(false),
    }); 
    //*********************************************** */
    v_catheter: Catheter = {
      Catheter_Name: '',
      Catheter_ID: 0,    
    };
      
    public error: any;
    id!: number;
    op_edit!: boolean;

  ngOnInit(): void 
  {
    this.form = this.formBuilder.group(
      {
        catheter_Name: ['', Validators.required]        
      }       
    );

    this.actRoute.paramMap.subscribe((param) => {
      debugger
      var id = Number(param.get('id'));
      if(id!=0)
      {
        this.getById(id);
        this.v_catheter=new Catheter();
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
    debugger
    this.router.navigate(['/admin/catheter']);
  }
  getById(id: number) {
    this.http.get<Catheter>('/api/Catheter/' + id).subscribe(data => { this.v_catheter= data; });
    debugger;
    ;
  }
  createOrReplace(catheter: Catheter) {
    debugger
    if(this.onSubmit()) 
    {
      if(this.op_edit)
      {
        this.update(catheter);
      }
      else
      {
        this.create(catheter);
      }
    }
  }

  create(catheter: Catheter) {
    
    this.http.post<Catheter>('/api/Catheter', catheter).subscribe(
      (data)=>{        
        debugger
        this.toaster.info("!کاتتر جدید با موفقیت ثبت شد");
        console.log(data);
        this.v_catheter=new Catheter();

        //this.gotoList();
      },
      (error:Exception)=>{
        this.toaster.error(error.message);
        console.log(error.message);
      }
    );
  }

  update(catheter: Catheter){
  debugger;
  this.http.put('/api/Catheter', catheter).subscribe(
    (data)=>{
      this.toaster.success("!اطلاعات کاتتر با موفقیت ویرایش شد");
      console.log(data);

    },
    (error:Exception)=>{
      console.log(error.message);
    }
  );
  }

  delete (catheter: Catheter){
  debugger;

  this.http.delete('/api/Catheter/'+catheter.Catheter_ID ).subscribe(
    (data)=>{
      console.log(data);
      this.gotoList();
    },
    (error:Exception)=>{
      console.log(error.message);
    });
  }
}