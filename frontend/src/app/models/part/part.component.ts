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

interface Part {
  Part_Name: string;
  Part_ID: number;
  Comment: string;
}

@Component({
  selector: 'app-part',
  templateUrl: './part.component.html',
  styleUrls: ['./part.component.css']
})

export class PartComponent {
  response !: Observable<any>;
  part!: Part[]; 
  v_part!: Part;
  public error: any;
  id!: number;
  public auth_token: any;

  constructor(private ConfirmService: ConfirmationService,
    private confirmationService: ConfirmationService,
    private primengConfig: PrimeNGConfig,
    private toaster: ToastrService,
    private http: HttpClient,
     private router: Router) {

    this.GetPart();
    //returns list by ID
    // this.http.get<any>('/api/Part/GetPartById/4').subscribe(    x => {  this.part = x ; } ,error => console.error(error)  );

  }
  delete (id : number) {
    this.confirmationService.confirm({
      message: "آیا مطمئن هستید؟",
      accept: () => {
        debugger;
         
 
        this.http.delete('/api/Part/'+id    ).subscribe(
          (data)=>{
            this.toaster.info("بخش مورد نظر با موفقیت حذف شد");
            console.log(data);
            this.GetPart();
            //this.router.navigate(['/admin/part']);
          },
          (error)=>{
            this.toaster.error("در بخش مورد نظر پذیرش صورت گرفته شده است امکان حذف بخش وجود ندارد");
            console.log(error.message);
          }); 

      },
      key: "userCrudConfirmation",
    });
    // this.confirmationService.confirm({
    //     message: 'Angular PrimeNG ConfirmDialog Component',
    //     header: 'GeeksforGeeks',
    // });
}
// get_token(){
//   alert( localStorage.getItem("User"));

// }
// request() {
//   let auth_token = localStorage.getItem("User" );
  
//     const headers = new HttpHeaders({
//         'Content-Type': 'application/json',
//         'Authorization': `Bearer ${auth_token}`
//       });

//     const requestOptions = { headers: headers };
//     this.http.get<Part[]>("/api/Part",requestOptions).
//     subscribe(
//         x => { this.part = x; },
//         error => console.error(error) 
//         );
// }
  GetPart()
  {
    debugger
    
     this.http.get<Part[]>("/api/Part").
     subscribe(x => { this.part = x; },
        error => console.error(error) 
        );
     
  }

  selectPart(id: number) {
    this.http.get<Part>('/api/Part/GetPartById2/'+ id).subscribe(v => { this.v_part = v; });    
  }

  delete1 (id : number){
    ////////////////////////////////
    debugger;
    this.ConfirmService.confirm({
      message: "آیا مطمئن هستید؟",
      accept: () => {
      //-------------------
      this.http.delete('/api/Part/DeletePart/' + id ).subscribe(
        (data)=>{
          alert("Deleted");
          console.log(data);
          this.GetPart();
        },
        (error)=>{
          console.log(error.message);
        });   
      //-------------------

      },
      key: "userCrudConfirmation",
    });
    ////////////////////////////////
  
   
   }

   test() {
    this.toaster.info("اطلاعات با موفقیت ثبت شد",);
    this.toaster.success("I'm a toast!", "Success!");
  }
}