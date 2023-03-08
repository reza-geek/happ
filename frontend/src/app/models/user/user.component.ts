import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { User } from './User';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  
  o_user ?: User;

  constructor(private http : HttpClient,private router:RouterModule) { }

  ngOnInit(): void {}

  GetPatientByName(I_Username : string,I_Password : string): void {
    debugger
    this.http.get<User>('/api/Patient/GetPatientByName?Username='+I_Username+'Password'+I_Password ).
    subscribe(p => {this.o_user = p;},
      error =>{ console.error(error)});
  }

  login(username, password): Observable<any> {
    return this.httpClient.post<any>('/api/User/GetUerInfo?',
      {
        username,
        password,
        loadWithPermissions: true,
        
      }
    );

}

