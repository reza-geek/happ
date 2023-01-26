import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-catheter-event',
  templateUrl: './catheter-event.component.html',
  styleUrls: ['./catheter-event.component.css']
})
export class CatheterEventComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

class Catheter_event
    { 
 CatheterisationEvent_ID ?: BigInt;
 Event_Desc ?: string;
 Event_Date ?: string;
Catheterisation_ID ?: number  ;
Event_ID ?: number  ;
    }