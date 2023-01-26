import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatheterEventComponent } from './catheter-event.component';

describe('CatheterEventComponent', () => {
  let component: CatheterEventComponent;
  let fixture: ComponentFixture<CatheterEventComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatheterEventComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CatheterEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
