import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router  } from '@angular/router';
import { Exception } from 'sass';
import {MatDatepicker} from '@angular/material/datepicker';
//import {MatDatepickerModulePersian} from '@angular-persian/material-date-picker';

@Component({
  selector: 'app-part-detail',
  templateUrl: './part-detail.component.html',
  styleUrls: ['./part-detail.component.css']
})
export class PartDetailComponent implements OnInit {
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

  constructor(private http: HttpClient, private actRoute: ActivatedRoute, private router: Router) { }
  // this.id = this.actRoute.snapshot.params['id'];
  // this.http.get<Part>('/api/Part/GetPartById2/'+this.id).subscribe(v => { this.v_part = v; });
  // this.http.get<Part[]>("/api/Part/GetPart").
  // subscribe(x => { this.part = x; }, error => console.error(error) );

  //returns list by ID
  // this.http.get<any>('/api/Part/GetPartById/4').subscribe(    x => {  this.part = x ; } ,error => console.error(error)  );


  ngOnInit(): void {
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
  gotoList() {
    debugger;
    this.router.navigate(['/Part']);
  }
  getById(id: number) {
    this.http.get<Part>('/api/Part/GetPartById2/' + id).subscribe(data => { this.v_part = data; });
    debugger;
    ;
  }
  createOrReplace(part: Part) {
    debugger
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
    .subscribe(Response =>{ this.new_part = Response; this.parts.push(this.new_part);} );
    debugger;
  }

  create(part: Part) {
    
    this.http.post<Part>('/api/Part/CreatePart', part).subscribe(
      (data)=>{
        alert("Part Created Successfully!");
        console.log(data);
        this.v_part=new Part();
        this.gotoList();
      },
      (error:Exception)=>{
        console.log(error.message);
      }
    );
  }

  update(part:Part){
    debugger;
    this.http.post('/api/Part/UpdatePart', part).subscribe(
      (data)=>{
        alert("Update Done");
        console.log(data);
      },
      (error:Exception)=>{
        console.log(error.message);
      }
    );
   }

   delete (part : Part){
    debugger;
    this.http.delete('/api/Part/DeletePart/' +part.Part_ID ).subscribe(
      (data)=>{
        alert("Deleted");
        console.log(data);
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