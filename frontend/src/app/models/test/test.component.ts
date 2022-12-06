import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router  } from '@angular/router';
import { Exception } from 'sass';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})

export class TestComponent implements OnInit {
  v_part: Part = {
    part_Name: '',
    part_ID: 0,
    comment: '',
  };

  new_part :    Part = {
    part_Name: '',
    part_ID: 0,
    comment: '',
  };
  parts :Part[] = [];
  public error: any;
  id!: number;

  constructor(private http: HttpClient, private actRoute: ActivatedRoute, private router: Router) { }
  // this.id = this.actRoute.snapshot.params['id'];
  // this.http.get<Part>('/api/Part/GetPartById2/'+this.id).subscribe(v => { this.v_part = v; });
  // this.http.get<Part[]>("/api/Part/GetPart").
  // subscribe(x => { this.part = x; }, error => console.error(error) );

  //returns list by ID
  // this.http.get<any>('/api/Part/GetPartById/4').subscribe(    x => {  this.part = x ; } ,error => console.error(error)  );


  ngOnInit(): void {
    this.actRoute.paramMap.subscribe((param) => {
      var id = Number(param.get('id'));
      if(id!=0)
      this.getById(id);
      this.v_part=new Part();
    });
  }
  getById(id: number) {
    this.http.get<Part>('/api/Part/GetPartById2/' + id).subscribe(data => { this.v_part = data; });
    debugger;
    ;
  }
  createNew() {
    // let p = new Part {part_Name = 'test',comment = 'test'};
    // this.new_part.part_Name = 'test';
    //  this.new_part.comment = 'test';
     this.http.post<Part>('/api/Part/CreatePart',   this.new_part)
    .subscribe(Response =>{ this.new_part = Response; this.parts.push(this.new_part);} );
    debugger;
  }

  create(part: Part) {
    debugger
    this.http.post<Part>('/api/Part/CreatePart', part).subscribe(
      (data)=>{
        alert("Part Created Successfully!");
        console.log(data);
        this.v_part=new Part();
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
        alert("bbbbb");
        console.log(data);
      },
      (error:Exception)=>{
        console.log(error.message);
      }
    );
   }
  
}

  class Part {
  part_Name?: string;
  part_ID?: number;
  comment?: string;
}