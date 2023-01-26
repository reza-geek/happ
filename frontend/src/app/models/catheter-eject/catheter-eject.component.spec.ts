import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatheterEjectComponent } from './catheter-eject.component';

describe('CatheterEjectComponent', () => {
  let component: CatheterEjectComponent;
  let fixture: ComponentFixture<CatheterEjectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatheterEjectComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CatheterEjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
