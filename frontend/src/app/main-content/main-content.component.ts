import { Component, OnInit,Input } from '@angular/core';
import moment from 'jalali-moment';
import { FormControl } from '@angular/forms';
import { SideBarComponent } from '../side-bar/side-bar.component';
import {
  defaultTheme,
  IActiveDate,
  IDatepickerTheme
} from 'ng-persian-datepicker';
import { darkTheme } from './datepicker-theme/dark.theme';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.css']
})
export class MainContentComponent implements OnInit {
  

  @Input() public sideBarComponent :SideBarComponent =new SideBarComponent() ;  
  constructor(private toaster: ToastrService) {
    
    // debugger
    //   const userJson = localStorage.getItem('UserFullName');
    //    this.sideBarComponent.userTitle = "reza";
    //    userJson !== null ?  userJson : "";
    //    alert('test');
   }
  

  ngOnInit(): void {
  }
  test() {
    this.toaster.success("I'm a toast!", "Success!");
  }

  ShowMsg():void  { 
     
   // this.toaster.success("Hello world!", "Toastr fun!");
    // this.toaster.error("خطایی رخ داد. لطفا مجدد امتحان کنید");
     this.toaster.success('Hello world!', 'Toastr fun!')
     
    ;
     //this.location.back();
    // alert("alert خطایی رخ داد. لطفا مجدد امتحان کنید");
    }
}
