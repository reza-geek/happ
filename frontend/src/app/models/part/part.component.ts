import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { AppModule } from 'src/app/app.module';
import { RouterModule } from '@angular/router';


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
  part!: Part[]; v_part!: Part;
  public error: any;
  id!: number;

  constructor(private http: HttpClient,private router: RouterModule) {

    this.http.get<Part[]>("/api/Part/GetPart").
    subscribe(x => { this.part = x; }, error => console.error(error) );
    //returns list by ID
    // this.http.get<any>('/api/Part/GetPartById/4').subscribe(    x => {  this.part = x ; } ,error => console.error(error)  );

  }

  selectPart(id: number) {
    this.http.get<Part>('/api/Part/GetPartById2/'+ id).subscribe(v => { this.v_part = v; });    
  }

  
}