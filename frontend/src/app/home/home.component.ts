import { Component, Input, OnInit } from '@angular/core';
import moment from 'jalali-moment';
import { FormControl } from '@angular/forms';
import { SideBarComponent } from '../side-bar/side-bar.component';
import { Observable, BehaviorSubject , throwError } from "rxjs";
import { UserComponent } from '../models/user/user.component';
import { HttpClient ,HttpErrorResponse} from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { AppModule } from 'src/app/app.module';
import { RouterModule } from '@angular/router';
import { ActivatedRoute, Router  } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdminDashboardService } from '../Services/admin-dashboard.service';
import {
  defaultTheme,
  IActiveDate,
  IDatepickerTheme
} from 'ng-persian-datepicker';
import { darkTheme } from './datepicker-theme/dark.theme';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
 })
export class HomeComponent implements OnInit {
  
  constructor(
    private actRoute: ActivatedRoute,
    private router1:Router,
    private http: HttpClient,
    private router: RouterModule,
    private dashboardServices: AdminDashboardService,
    private toaster: ToastrService) 
  { 
    //this.router1.navigate(["/admin"]);
   // this.userco.fullName.subscribe((x) => { this.userTitle = x;  });
    
  }
  v_reload = true;
  mostSearchData: any;
  mostSearchVisible = true;   
  
  GetPartCount(size: number) {
    this.dashboardServices.GetPartCount(5).subscribe(
      (v) => { this.mostSearchData = 
      {
        labels: v.map( m => m.Key)  ,
        dataset: [{
          label: "Search count",
          backgroundColor: [
            "#42A5F5",
            "#28A745",
            "#FFC107",
            "#DC3545",
            "#565656",
          ],
          borderColor: "#1E88E5",
          data: v.map((m) => m.DocCount),
        },]
      }  ;
   },
   (err: HttpErrorResponse) => {
    if (err.status == 401) this.mostSearchVisible = false;
  }
   );    
  }

  
  ngOnInit(): void {
    if(this.v_reload)
      {
        this.v_reload = false;
       // location.reload();
      }
    
  }

}
