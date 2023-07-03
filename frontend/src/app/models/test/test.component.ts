import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router  } from '@angular/router';
import { Exception } from 'sass';
//import {MatDatepickerModulePersian} from '@angular-persian/material-date-picker';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  //Create FormGroup
  requiredForm!: FormGroup;

  constructor(private fb: FormBuilder) {
     this.myForm();
  }

  //Create required field validator for name
  myForm() {
     this.requiredForm = this.fb.group({
     name: ['', Validators.required ]
     });
     
    //  this.requiredForm = this.fb.group({
    //   email: ['', [Validators.required, 
    //      Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")] ]
    //   });
  }
  ngOnInit()
  {

  }
}