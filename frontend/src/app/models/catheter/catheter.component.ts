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


interface Catheter
{
	Catheter_ID  ? : number ;
	Catheter_Name  ? : string;
}
@Component({
  selector: 'app-catheter',
  templateUrl: './catheter.component.html',
  styleUrls: ['./catheter.component.css']
})
export class CatheterComponent implements OnInit {
  response !: Observable<any>;
  catheter!: Catheter[]; 
  v_catheter!: Catheter;
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
this.GetCatheter(); 
} 

ngOnInit(): void {
}

 

GetCatheter()
{
    this.http.get<Catheter[]>("/api/Catheter").
    subscribe(x => { this.catheter = x; },
      error => console.error(error) 
      );
    
};

delete (id : number) {
  this.confirmationService.confirm({
    message: "آیا مطمئن هستید؟",
    accept: () => {
      debugger;
       

      this.http.delete('/api/Catheter/'+id    ).subscribe(
        (data)=>{
          this.toaster.info("کاتتر مورد نظر با موفقیت حذف شد");
          console.log(data);
          this.GetCatheter();
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
}
//**************************************************** */
class Catheterz
  {
      Catheter_ID?: number ;       
      Catheter_Name ?:  string;  
      //public ICollection<Catheterisation> Catheterisation { get; set; }
  }