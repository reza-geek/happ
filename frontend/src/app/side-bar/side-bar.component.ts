import { Component, OnInit } from '@angular/core';

//import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
})
export class SideBarComponent implements OnInit {
  public userTitle !: string;
  
  constructor() { }

  ngOnInit(): void {
            
      const userJson = localStorage.getItem('UserFullName');
       this.userTitle =userJson !== null ?  userJson : "" ;
       
  }

}
