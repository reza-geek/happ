import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router  } from '@angular/router';
import { Exception } from 'sass';
import { ToastrService } from 'ngx-toastr';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators  } from '@angular/forms';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.css']
})
export class EventDetailComponent implements OnInit {

  
  submitted = false;
  form: FormGroup = new FormGroup(
    {
    event_Name: new FormControl(''),
    acceptTerms: new FormControl(false),
  }); 
  //*********************************************** */
  v_event: Event = {
    Event_Name: '',
    Event_ID: 0,    
  };
    
  public error: any;
  id!: number;
  op_edit!: boolean;

  constructor(private formBuilder: FormBuilder,private http: HttpClient, private actRoute: ActivatedRoute, private router: Router,
    private toaster: ToastrService) { }
 

  ngOnInit(): void 
  {
    this.form = this.formBuilder.group(
      {
        event_Name: ['', Validators.required]
       
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
        this.v_event=new Event();
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
    this.router.navigate(['/admin/event']);
  }
  getById(id: number) {
    this.http.get<Event>('/api/event/' + id).subscribe(data => { this.v_event = data; });
    debugger;
    ;
  }
  createOrReplace(event: Event) {
    debugger
    if(this.onSubmit()) 
    {
      if(this.op_edit)
      {
        this.update(event);
      }
      else
      {
        this.create(event);
      }
    }
  }

  create(event: Event) {
    
    this.http.post<Event>('/api/Event', event).subscribe(
      (data)=>{        
        debugger
        this.toaster.info("!عارضه جدید با موفقیت ثبت شد");
        console.log(data);
        this.v_event=new Event();

        //this.gotoList();
      },
      (error:Exception)=>{
        this.toaster.error(error.message);
        console.log(error.message);
      }
    );
  }

  update(event: Event){
  debugger;
  this.http.put('/api/event', event).subscribe(
    (data)=>{
      this.toaster.success("!اطلاعات بخش با موفقیت ویرایش شد");
      console.log(data);

    },
    (error:Exception)=>{
      console.log(error.message);
    }
  );
  }

  delete (event : Event){
  debugger;

  this.http.delete('/api/event/'+event.Event_ID ).subscribe(
    (data)=>{
      console.log(data);
      this.gotoList();
    },
    (error:Exception)=>{
      console.log(error.message);
    });
  }
}

class Event{
  Event_ID?: number;
  Event_Name?: string
}