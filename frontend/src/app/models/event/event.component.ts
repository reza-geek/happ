import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient ,HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { AppModule } from 'src/app/app.module';
import { RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import {ConfirmationService} from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';
import { ActivatedRoute, Router  } from '@angular/router';

interface Event {
  Event_Name: string;
  Event_ID: number;   
}

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})

export class EventComponent implements OnInit {
  
  response !: Observable<any>;
  event!: Event[]; 
  v_event!: Event;
  public error: any;
  id!: number;
  public auth_token: any;

  constructor(private ConfirmService: ConfirmationService,
              private confirmationService: ConfirmationService,
              private primengConfig: PrimeNGConfig,
              private toaster: ToastrService,
              private http: HttpClient,
              private router: Router) 
    {
      this.GetEvent(); 
    }

  ngOnInit(): void {
  }

  delete (id : number) {
    this.confirmationService.confirm({
      message: "آیا مطمئن هستید؟",
      accept: () => {
        debugger;
         
 
        this.http.delete('/api/Event/'+id    ).subscribe(
          (data)=>{
            this.toaster.info("بخش مورد نظر با موفقیت حذف شد");
            console.log(data);
            this.GetEvent();
            //this.router.navigate(['/admin/part']);
          },
          (error)=>{
            this.toaster.error("در بخش مورد نظر پذیرش صورت گرفته شده است امکان حذف بخش وجود ندارد");
            console.log(error.message);
          }); 

      },
      key: "userCrudConfirmation",
    });
  }

  GetEvent()
    {
       this.http.get<Event[]>("/api/Event").
       subscribe(x => { this.event = x; },
          error => console.error(error) 
          );
       
    };
  
    selectEvent(id: number) {
      this.http.get<Event>('/api/Event/'+ id).subscribe(v => { this.v_event = v; });    
    }  
}
