import { HttpClient ,HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core'; 

interface Model {
    name:string;
}
// interface Part {
//   part_Name: string;
//   part_ID: number;
//   comment: string;
// }

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Management Panel';
  

  constructor(private http : HttpClient) {     
  }

  // httpOptions = {
  //   headers: new HttpHeaders({
  //     'Content-Type': 'application/json',
  //     "Access-Control-Allow-Origin": "*"
  //   }), responseType: 'text' as 'json'
  // };

  ngOnInit(){  
       

  }
}
