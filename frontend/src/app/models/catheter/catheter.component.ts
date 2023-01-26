import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-catheter',
  templateUrl: './catheter.component.html',
  styleUrls: ['./catheter.component.css']
})
export class CatheterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}


class Catheter
  {
      Catheter_ID?: Int32Array ;       
      Catheter_Name ?:  string;  
      //public ICollection<Catheterisation> Catheterisation { get; set; }
  }