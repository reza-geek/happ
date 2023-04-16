import { Component, OnInit } from '@angular/core';
import moment from 'jalali-moment';
import { FormControl } from '@angular/forms';

import {
  defaultTheme,
  IActiveDate,
  IDatepickerTheme
} from 'ng-persian-datepicker';
import { darkTheme } from './datepicker-theme/dark.theme';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  dateValue = new FormControl();
  uiIsVisible: boolean = false;
  uiTheme:  IDatepickerTheme = darkTheme;
  uiYearView: boolean = true;
  uiMonthView: boolean = true;
  uiHideAfterSelectDate: boolean = true;
  uiHideOnOutsideClick: boolean = true;
  uiTodayBtnEnable: boolean = true;
  timeEnable: boolean = false;
  timeShowSecond: boolean = false;
  timeMeridian: boolean = false;

  private _theme: string = 'dark';

  get theme(): string {
    return this._theme;
  }
  set theme(value: string) {
    this._theme = value;

    switch (value) {
      case 'dark':
        this.uiTheme = darkTheme;
        break;
      case 'default':
        this.uiTheme = defaultTheme;
        break;
    }
  }

  onSelect(date: IActiveDate) {
    console.log(date);
  }

  tval=true;
  constructor() {   }

  ngOnInit(): void {
  }

}
