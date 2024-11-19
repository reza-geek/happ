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

interface Clearance
{
	Clearance_ID  ? : number ;
	Clearance_Type  ? : string;
}

@Component({
  selector: 'app-clearance',
  templateUrl: './clearance.component.html',
  styleUrls: ['./clearance.component.css']
})
export class ClearanceComponent implements OnInit {

  response !: Observable<any>;
  clearance!: Clearance[]; 
  v_clearance!: Clearance;
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
      this.GetClearance(); 
    }

  ngOnInit(): void {
  }

  GetClearance()
  {
    this.http.get<Clearance[]>("/api/Clearance").
    subscribe(x => { this.clearance = x; },
      error => console.error(error) 
      );
  }

  delete (id : number) {
    this.confirmationService.confirm({
      message: "آیا مطمئن هستید؟",
      accept: () => {
        debugger;
         
  
        this.http.delete('/api/Clearance/'+id    ).subscribe(
          (data)=>{
            this.toaster.info("علت ترخیص مورد نظر با موفقیت حذف شد");
            console.log(data);
            this.GetClearance();
            //this.router.navigate(['/admin/part']);
          },
          (error)=>{
            this.toaster.error("علت مورد نظر در سیستم استفاده شده است حذف این علت ترخیص امکانپذیر نیست");
            console.log(error.message);
          }); 
  
      },
      key: "userCrudConfirmation",
    });
  }

}
