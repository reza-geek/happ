import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatheterdetailComponent } from './catheterdetail.component';

describe('CatheterdetailComponent', () => {
  let component: CatheterdetailComponent;
  let fixture: ComponentFixture<CatheterdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatheterdetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CatheterdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
